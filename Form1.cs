using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmapsLibCF;
using System.Runtime.InteropServices;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        private Viewer myViewer;

        public Form1()
        {
            InitializeComponent();
            myViewer = new Viewer();

            myViewer.useTemplate = false;

            GeoRectangle rect = new GeoRectangle(0, 0, 100, 100);

            try
            {
                ImageLayer mapLayer = new ImageLayer("\\Program Files\\SmartDeviceProject1\\map.gif", rect);

                myViewer.AddLayer(mapLayer);
            }
            catch (Exception ex) { }
            myViewer.Size = new Size(this.Width, this.Height);

            tabPage3.Controls.Add(myViewer);

            myViewer.KeyPress += new KeyPressEventHandler(myViewer_KeyPress);
        }

      void myViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Scaler scale = myViewer.getScale();

            GeoRectangle rect = scale.getMapExtent();

            switch (e.KeyChar)
            {
                case '2':
                    rect.y += 5;
                    break;
                case '4':
                    rect.x -= 5;
                    break;
                case '6':
                    rect.x += 5;
                    break;
                case '8':
                    rect.y -= 5;
                    break;
                case '1':
                    rect.width /= 2;
                    rect.height /= 2;
                    break;
                case '3':
                    rect.width *= 2;
                    rect.height *= 2;
                    break;
            }
            myViewer.setMapExtent(rect, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool female = radioButton1.Checked;
            bool male = radioButton2.Checked;
            String gender;
            if (female == true && male == false)
                gender = "female";
            else if (female == false && male == true)
                gender = "male";
            else
                gender = "not selected";
            listBox1.Items.Add(textBox1.Text + " " + gender);
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                // Populate lstReadL1Ints with lngVals
                
                for (int i = 0; i <= 50; i++)
                {
                    ListViewItem row = new ListViewItem(i.ToString());
                    int j = i * 2;
                    row.SubItems.Add(j.ToString());
                    listView1.Items.Add(row);
                }
                
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Cannot fill in Int listview. ex = ").Append(ex.Message);
                Console.WriteLine(sb.ToString());
            }
            //tabPage2.Dispose();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            
            if (myViewer.CurrentTool == "PanTool")
            {
                myViewer.setTool("ZoomTool");
            }
            else
            {
                myViewer.setTool("PanTool");
            }
        }
        
        [DllImport("coredll")]
        private static extern uint GetSystemPowerStatusEx2(SYSTEM_POWER_STATUS_EX2 lpSystemPowerStatus, uint dwLen,
                                                                                bool fUpdate);
   

        private void tabPage4_Disposed(object sender, EventArgs e)
        {
            SYSTEM_POWER_STATUS_EX2 baterry = new SYSTEM_POWER_STATUS_EX2();

            if (GetSystemPowerStatusEx2(baterry,
                (uint)Marshal.SizeOf(baterry), true) ==
                (uint)Marshal.SizeOf(baterry))
            {

                bateryLbl2.Text = (baterry.BatteryLifePercent/255.0).ToString()+"%";
                label3.Text = baterry.BatteryVoltage.ToString() + "mV";
                label5.Text = baterry.BatteryCurrent.ToString() + "mA";
                label7.Text = baterry.BatteryTemperature.ToString() + "C";

                byte chemistry = baterry.BatteryChemistry;
                switch (chemistry)
                {
                    case 0x01: label9.Text = "Alkaline"; break;
                    case 0x02: label9.Text = "NICD"; break;
                    case 0x03: label9.Text = "NIMH"; break;
                    case 0x04: label9.Text = "LION"; break;
                    case 0x05: label9.Text = "LIPOLY"; break;
                    case 0x06: label9.Text = "ZINCAIR"; break;
                    case 0xFF: label9.Text = "Unknown"; break;
                    default: label9.Text = chemistry.ToString(); break;
                }

                byte flag = baterry.BatteryFlag;
                switch (flag)
                {
                    case 0x01: label11.Text = "High"; break;
                    case 0x02: label11.Text = "Low"; break;
                    case 0x04: label11.Text = "Critical"; break;
                    case 0x08: label11.Text = "Charging"; break;
                    case 0x80: label11.Text = "NoBaterry"; break;
                    case 0xFF: label11.Text = "Unknown"; break;
                }
            }
            
        }
        
    }
}