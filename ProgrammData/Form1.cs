using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;


namespace WindowsFormsApp1
{

    public partial class Screenshot : Form
    {

        public Screenshot()
        {
            InitializeComponent();

        }

        private void Screenshot_Load(object sender, EventArgs e)
        {

        }
        public static void pause()
        {
            Console.Read();
        }

        private void Quit_click(object sender, EventArgs e)
        {
            this.Close();
        }
    

        private void button1_Click_1(object sender, EventArgs e)
            {
                string ordner = (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\" + "Bildschirmfotos");

                DirectoryInfo di = Directory.CreateDirectory(ordner);

                this.WindowState = FormWindowState.Minimized;
                System.Threading.Thread.Sleep(1000);

                Bitmap memoryImage;
                memoryImage = new Bitmap(1920, 1080);
                Size s = new Size(memoryImage.Width, memoryImage.Height);

                Graphics memoryGraphics = Graphics.FromImage(memoryImage);

                memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

                string str = "";
                try
                {
                    str = string.Format(ordner) +
                          (@"\" + textBox1.Text + ".png");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Sorry, there was an error: " + er.Message);

                }
            
                memoryImage.Save(str);
               
                Process.Start("explorer.exe", ordner);
                // Pause the program to show the message. 
                pause();
            }
        }
}

