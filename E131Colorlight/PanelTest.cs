using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E131Colorlight
{
    public partial class PanelTest : Form
    {
        private byte[] _channelData;
        private int _width;
        private int _height;
        private int _index = 0;

        public PanelTest(ref byte[] channelData, int width, int height)
        {
            InitializeComponent();
            _channelData = channelData;
            _height = height;
            _width = width;
            timer1.Interval = Decimal.ToInt32(numericUpDown1.Value);
            comboBox1.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
            if (!checkBox1.Checked)
            {
                for (int i = 0; i < _channelData.Length; i++)
                {
                    _channelData[i] = 0;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DrawTestPattern();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawTestPattern();
        }

        private void DrawTestPattern()
        {
            //_channelData
            _index = _index % 3;
            _index++;

            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < _channelData.Length / 3; i++)
                {
                    if (_index == 1)
                    {
                        _channelData[(i * 3)] = 255;
                        _channelData[(i * 3) + 1] = 0;
                        _channelData[(i * 3) + 2] = 0;
                    }
                    else if (_index == 2)
                    {
                        _channelData[(i * 3)] = 0;
                        _channelData[(i * 3) + 1] = 255;
                        _channelData[(i * 3) + 2] = 0;
                    }
                    else if (_index == 3)
                    {
                        _channelData[(i * 3)] = 0;
                        _channelData[(i * 3) + 1] = 0;
                        _channelData[(i * 3) + 2] = 255;
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i <= _height; i++)
                {
                    int rowOffset = _width * 3 * i;
                    int offset = i % 3;
                    //offset--;
                    for (int j = 0; j < _width; j++)
                    {
                        if (_index == 1)
                        {
                            _channelData[rowOffset + (j * 3) + offset] = 255;
                            _channelData[rowOffset + (j * 3) + offset + 1] = 0;
                            _channelData[rowOffset + (j * 3) + offset + 2] = 0;
                        }
                        else if (_index == 2)
                        {
                            _channelData[rowOffset + (j * 3) + offset] = 0;
                            _channelData[rowOffset + (j * 3) + offset + 1] = 255;
                            _channelData[rowOffset + (j * 3) + offset + 2] = 0;
                        }
                        else if (_index == 3)
                        {
                            _channelData[rowOffset + (j * 3) + offset] = 0;
                            _channelData[rowOffset + (j * 3) + offset + 1] = 0;
                            _channelData[rowOffset + (j * 3) + offset + 2] = 255;
                        }
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < _channelData.Length / 9; i++)
                {
                    if (_index == 1)
                    {
                        _channelData[(i * 9)] = 255;
                        _channelData[(i * 9) + 1] = 0;
                        _channelData[(i * 9) + 2] = 0;

                        _channelData[(i * 9) + 3] = 0;
                        _channelData[(i * 9) + 4] = 255;
                        _channelData[(i * 9) + 5] = 0;

                        _channelData[(i * 9) + 6] = 0;
                        _channelData[(i * 9) + 7] = 0;
                        _channelData[(i * 9) + 8] = 255;
                    }
                    else if (_index == 2)
                    {
                        _channelData[(i * 9)] = 0;
                        _channelData[(i * 9) + 1] = 255;
                        _channelData[(i * 9) + 2] = 0;

                        _channelData[(i * 9) + 3] = 0;
                        _channelData[(i * 9) + 4] = 0;
                        _channelData[(i * 9) + 5] = 255;

                        _channelData[(i * 9) + 6] = 255;
                        _channelData[(i * 9) + 7] = 0;
                        _channelData[(i * 9) + 8] = 0;
                    }
                    else if (_index == 3)
                    {
                        _channelData[(i * 9)] = 0;
                        _channelData[(i * 9) + 1] = 0;
                        _channelData[(i * 9) + 2] = 255;

                        _channelData[(i * 9) + 3] = 255;
                        _channelData[(i * 9) + 4] = 0;
                        _channelData[(i * 9) + 5] = 0;

                        _channelData[(i * 9) + 6] = 0;
                        _channelData[(i * 9) + 7] = 255;
                        _channelData[(i * 9) + 8] = 0;
                    }
                }
            }
        }

        private void PanelTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            for (int i = 0; i < _channelData.Length; i++)
            {
                _channelData[i] = 0;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Decimal.ToInt32(numericUpDown1.Value);
        }
    }
}
