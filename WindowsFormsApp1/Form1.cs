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

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static void pause()
        {
            Console.Read();
        }
       


        private void button1_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
            System.Threading.Thread.Sleep(1000);


            Bitmap memoryImage;
                memoryImage = new Bitmap(1920, 1080);
                Size s = new Size(memoryImage.Width, memoryImage.Height);


                Graphics memoryGraphics = Graphics.FromImage(memoryImage);



                memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

                //That's it! Save the image in the directory and this will work like charm. 
                string str = "";
                try
                {
                    str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) +
                          (@"\" + textBox1.Text + ".png"));
                }
                catch (Exception er)
                {
                    MessageBox.Show("Sorry, there was an error: " + er.Message);

                }


                memoryImage.Save(str);

                // Write the message, 
                
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                Process.Start("explorer.exe", path);
                // Pause the program to show the message. 
                pause();
            }
        }
    }

   
