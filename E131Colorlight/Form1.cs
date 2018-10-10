using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;

using Acn.Sockets;
using System.Net;
using Acn.Packets.sAcn;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace E131Colorlight
{
    public partial class Form1 : Form
    {
        IList<LivePacketDevice> _allDevices;
        int _startUniverse;
        int _panelWidth;
        int _panelHeight;
        int _selectedOutput;
        string _selectedInput;
        int _universeSize;
        int _brightness;
        //int _refresh;

        byte[] _channelData;

        Stopwatch _swMain = new Stopwatch();
        Stopwatch sw = new Stopwatch();

        private StreamingAcnSocket _socket = new StreamingAcnSocket(Guid.NewGuid(), "Streaming ACN Snoop");

        public Form1()
        {
#if !DEBUG
            bool isDupeFound = false;
            foreach (Process myProcess in Process.GetProcesses())
            {
                if (myProcess.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    if (isDupeFound)
                        Process.GetCurrentProcess().Kill();
                    isDupeFound = true;
                }
            }
#endif
            _swMain.Start();
            _selectedOutput = Properties.Settings.Default.Output;
            _startUniverse = Properties.Settings.Default.Universe;
            _panelHeight = Properties.Settings.Default.PanelHeight;
            _panelWidth = Properties.Settings.Default.PanelWidth;
            _universeSize = Properties.Settings.Default.UniverseSize;
            _brightness = Properties.Settings.Default.Brightness;
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (adapter.SupportsMulticast && adapter.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipProperties = adapter.GetIPProperties();

                    for (int n = 0; n < ipProperties.UnicastAddresses.Count; n++)
                    {
                        //adapter.GetIPProperties().UnicastAddresses[n].Address
                        if (adapter.GetIPProperties().UnicastAddresses[n].Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            inputComboBox.Items.Add(adapter.GetIPProperties().UnicastAddresses[n].Address);
                        }
                    }
                }
            }

            _allDevices = LivePacketDevice.AllLocalMachine;

            if (_allDevices.Count == 0)
            {
                listBox1.Items.Add("No interfaces found! Make sure WinPcap is installed.");
            }
            else
            {
                for (int i = 0; i != _allDevices.Count; ++i)
                {
                    LivePacketDevice device = _allDevices[i];
                    string fullName = device.Name;
                    if (device.Description != null)
                        fullName += (" (" + device.Description + ")");
                    outputComboBox.Items.Add(fullName);
                }
            }

            outputComboBox.SelectedIndex = _selectedOutput;
            startUniversNumUpDwn.Value = _startUniverse;
            panelHeightNumUpDwn.Value = _panelHeight;
            panelWidthNumUpDwn.Value = _panelWidth;
            refreshNumericUpDown.Value = timer1.Interval = Properties.Settings.Default.Refresh;
            universeSizeNumericUpDown.Value = _universeSize;
            brightnessNumericUpDown.Value = _brightness;

            string test = Properties.Settings.Default.Input;
            _selectedInput = inputComboBox.Text = test;

            CalculateEndUniveres();

            Start(IPAddress.Parse(_selectedInput), Decimal.ToInt32(startUniversNumUpDwn.Value), Decimal.ToInt32(endUniversNumUpDwn.Value));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _socket.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _selectedOutput = Properties.Settings.Default.Output = outputComboBox.SelectedIndex;
            _startUniverse = Properties.Settings.Default.Universe = Decimal.ToInt32(startUniversNumUpDwn.Value);
            _panelHeight = Properties.Settings.Default.PanelHeight = Decimal.ToInt32(panelHeightNumUpDwn.Value);
            _panelWidth = Properties.Settings.Default.PanelWidth = Decimal.ToInt32(panelWidthNumUpDwn.Value);
            //_selectedInput = Properties.Settings.Default.Input = inputComboBox.Items[inputComboBox.SelectedIndex].ToString();
            _brightness = Properties.Settings.Default.Brightness = Decimal.ToInt32(brightnessNumericUpDown.Value);

            Properties.Settings.Default.Refresh = timer1.Interval = Decimal.ToInt32(refreshNumericUpDown.Value);
            _universeSize = Properties.Settings.Default.UniverseSize = Decimal.ToInt32(universeSizeNumericUpDown.Value);

            Properties.Settings.Default.Save();
            CalculateEndUniveres();

            Start(IPAddress.Parse(_selectedInput), Decimal.ToInt32(startUniversNumUpDwn.Value), Decimal.ToInt32(endUniversNumUpDwn.Value));
        }

        private void startUniversNumUpDwn_ValueChanged(object sender, EventArgs e)
        {
            CalculateEndUniveres();
        }

        private void panelHeightNumUpDwn_ValueChanged(object sender, EventArgs e)
        {
            CalculateEndUniveres();
        }

        private void panelWidthNumUpDwn_ValueChanged(object sender, EventArgs e)
        {
            CalculateEndUniveres();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sw.Restart();
            timer1.Stop();
            OutputToPanel();
            timer1.Start();
            sw.Stop();
            _swMain.Stop();
            textBoxOutput.Text = String.Format("Write Time={0}ms Step Delay={1}ms", sw.Elapsed.TotalMilliseconds, _swMain.Elapsed.TotalMilliseconds);
            _swMain.Restart();
            //Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        void socket_NewPacket(object sender, NewPacketEventArgs<StreamingAcnDmxPacket> e)
        {
            StreamingAcnDmxPacket dmxPacket = e.Packet as StreamingAcnDmxPacket;
            if (dmxPacket != null)
            {
                DecodeDmxData(dmxPacket);
            }
        }

        /// <summary>
        /// This function builds the Ethernet 0x0101 Packet.
        /// </summary>
        private Packet BuildFirstPacket(MacAddress source, MacAddress destination)
        {
            EthernetLayer ethernetLayer = new EthernetLayer
            {
                Source = source,
                Destination = destination,
                EtherType = ((EthernetType)0x0101)
            };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(new byte[98])
                };

            PacketBuilder builder = new PacketBuilder(ethernetLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }

        /// <summary>
        /// This function builds the Ethernet 0x0AFF Packet.
        /// </summary>
        private Packet BuildSecondPacket(MacAddress source, MacAddress destination)
        {
            EthernetLayer ethernetLayer = new EthernetLayer
            {
                Source = source,
                Destination = destination,
                EtherType = ((EthernetType)0x0AFF)
            };

            byte[] mainByte = new byte[63];

            mainByte[0] = 0xFF;
            mainByte[1] = 0xFF;
            mainByte[2] = 0xFF;

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(mainByte)
                };

            PacketBuilder builder = new PacketBuilder(ethernetLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }

        /// <summary>
        /// This function builds the Test Color Paterns.
        /// </summary>
        private Packet BuildPixelPacket(MacAddress source, MacAddress destination, int row, int width, Color color)
        {
            EthernetLayer ethernetLayer = new EthernetLayer
            {
                Source = source,
                Destination = destination,
                EtherType = ((EthernetType)0x5500)
            };

            int offset = 0;
            int pixels = width;

            byte[] mainByte = new byte[(pixels*3) + 7];

            mainByte[0] = Convert.ToByte(row);
            mainByte[1] = Convert.ToByte(offset >> 8);
            mainByte[2] = Convert.ToByte(offset & 0xFF);
            mainByte[3] = Convert.ToByte(pixels >> 8);
            mainByte[4] = Convert.ToByte(pixels & 0xFF);
            mainByte[5] = 0x08;
            mainByte[6] = 0x80;

            for(int i= 0; i<pixels; i++)
            {
                int index = 7 + (i * 3);
                mainByte[index] = color.R;
                mainByte[index + 1] = color.G;
                mainByte[index + 2] = color.B;
            }

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(mainByte)
                };

            PacketBuilder builder = new PacketBuilder(ethernetLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }

        /// <summary>
        /// This function builds the Ethernet Row Data Packet.
        /// </summary>
        private Packet BuildPixelPacket(MacAddress source, MacAddress destination, int row, int pixelsWidth, byte[] data, int dataOffset)
        {
            int offset = 0;
            int width = pixelsWidth * 3;

            byte[] mainByte = new byte[(width) + 7];

            EthernetType type = ((EthernetType)0x5500);

            if (row < 256)
            {
                type = ((EthernetType)0x5500);
                mainByte[0] = Convert.ToByte(row);
            }
            else
            {
                type = ((EthernetType)0x5501);
                mainByte[0] = Convert.ToByte(row % 256);
            }

            EthernetLayer ethernetLayer = new EthernetLayer
            {
                Source = source,
                Destination = destination,
                EtherType = type
            };

            //mainByte[0] = Convert.ToByte(row);
            mainByte[1] = Convert.ToByte(offset >> 8);
            mainByte[2] = Convert.ToByte(offset & 0xFF);
            mainByte[3] = Convert.ToByte(pixelsWidth >> 8);
            mainByte[4] = Convert.ToByte(pixelsWidth & 0xFF);
            mainByte[5] = 0x08;
            mainByte[6] = 0x80;

            for (int i = 0; i < width; i++)
            {
                int indexwHead = 7 + i;
                byte oldValue = data[i + (dataOffset * 3)];
                int oldint = Convert.ToInt32(data[i + (dataOffset * 3)]);
                int newint = ((oldValue * _brightness) / 100);
                byte newValue = Convert.ToByte(newint);
                mainByte[indexwHead] = newValue;
                //mainByte[indexwHead] = 0x88;
            }

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(mainByte)
                };

            PacketBuilder builder = new PacketBuilder(ethernetLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }

        /// <summary>
        /// Calc End Universe and data size.
        /// </summary>
        void CalculateEndUniveres()
        {
            int width = Decimal.ToInt32(Properties.Settings.Default.PanelWidth);
            int height = Decimal.ToInt32(Properties.Settings.Default.PanelHeight);

            int total = width * height * 3;
            double length = Math.Ceiling(total / (double)_universeSize);

            int start = Decimal.ToInt32(startUniversNumUpDwn.Value);

            int end = start + (int)length + -1;
           endUniversNumUpDwn.Value = end;

            int newTotal = (int)length * (int)_universeSize;

            _channelData = new byte[newTotal];
        }

        /// <summary>
        /// Start the E.131 Lisener.
        /// </summary>
        private void Start(IPAddress networkCard, int startUniverse, int endUniverse)
        {
            _socket = new StreamingAcnSocket(Guid.NewGuid(), "Streaming ACN Snoop");
            _socket.NewPacket += new EventHandler<NewPacketEventArgs<Acn.Packets.sAcn.StreamingAcnDmxPacket>>(socket_NewPacket);
            _socket.Open(networkCard);

            for(int universe = startUniverse; universe<= endUniverse; universe++)
                _socket.JoinDmxUniverse(universe);
        }

        /// <summary>
        /// Start the E.131 Lisener.
        /// </summary>
        void DecodeDmxData(StreamingAcnDmxPacket data)
        {
            int incomingUniverse = data.Framing.Universe;

            int startUniverse = _startUniverse;
            int universeOffset = incomingUniverse - startUniverse;

            int tempUniversSize = _universeSize;
            if(_universeSize> data.Dmx.Data.Length)
            {
                MethodInvoker action5 = delegate
                {
                    listBox1.Items.Add("UniverseSize is larger than Incoming Data Size");
                };
                listBox1.BeginInvoke(action5);
                //listBox1.Items.Add("UniverseSize is larger than Incoming Data Size");
                tempUniversSize = data.Dmx.Data.Length - 1;
            }

            int offset = universeOffset * tempUniversSize;

            if (offset < 0 || _channelData.Length < (offset + tempUniversSize))
                return;

            //based on universe store data to channel data array
            for (int i=0;i< tempUniversSize; i++ )
            {
                _channelData[i + offset] = data.Dmx.Data[i+1];
            }
        }

        /// <summary>
        /// Output Channel Data to Color Light Card.
        /// </summary>
        void OutputToPanel()
        {
            try
            {
                PacketDevice selectedDevice = _allDevices[_selectedOutput];
                using (PacketCommunicator communicator = selectedDevice.Open(100, // name of the device
                                                                         PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                                         100)) // read timeout
                {
                    MacAddress source = new MacAddress("22:22:33:44:55:66");

                    // set mac destination to 02:02:02:02:02:02
                    MacAddress destination = new MacAddress("11:22:33:44:55:66");

                    // Ethernet Layer
                    int pixelWidth = _panelWidth;
                    int pixelHeight = _panelHeight;

                    communicator.SendPacket(BuildFirstPacket(source, destination));
                    communicator.SendPacket(BuildSecondPacket(source, destination));
                    for (int i = 0; i < pixelHeight; i++)
                    {
                        int offset = pixelWidth * i;
                        communicator.SendPacket(BuildPixelPacket(source, destination, i, pixelWidth, _channelData, offset));
                    }
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelTest test = new PanelTest(ref _channelData, _panelWidth, _panelHeight);
            test.ShowDialog();
        }
    }
}
