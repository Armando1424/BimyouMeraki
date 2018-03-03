using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BimyouMeraki.Properties;

namespace BimyouMeraki
{
    public partial class GestorVentanas : Form
    {
        int posMouseFormY,posActImageY,myTope=20,myBase=454, mover=0,MValX, MValY;
        bool ImagePresionada = false, TogMove;
        List<PictureBox> listPictureBox = new List<PictureBox>();

        public GestorVentanas()
        {
            InitializeComponent();
            MouseWheel += Form1_MouseWheel;
            List<Bitmap> listImages = new List<Bitmap>();
            listImages.Add(Resources.images1);
            listImages.Add(Resources.images2);
            listImages.Add(Resources.images3);
            listImages.Add(Resources.images4);
            listImages.Add(Resources.images5);
            listImages.Add(Resources.images6);
            listImages.Add(Resources.images7);
            listImages.Add(Resources.images8);
            listImages.Add(Resources.images9);
            listImages.Add(Resources.images10);

            int ini, fin;
            if (true)
            {
                ini = 0;
                fin = 6;
            }
            else
            {
                ini = 5;
                fin = 10;
            }

            for (int i = ini; i < fin; i++)
            {
                PictureBox picture = new PictureBox();
                picture.BackColor = System.Drawing.Color.Transparent;
                picture.Image = listImages[i];
                picture.Location = new System.Drawing.Point(71, 25+i*30);
                picture.Name = "imgMover"+i;
                picture.Size = new System.Drawing.Size(128, 128);
                picture.TabIndex = i;
                picture.TabStop = false;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgMover_MouseDown);
                picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgMover_MouseMove);
                picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgMover_MouseUp);
                picture.DoubleClick += Picture_DoubleClick;
                this.Controls.Add(picture);

                listPictureBox.Add(picture);
            }           
            
        }

        private void Picture_DoubleClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            switch (picture.Name)
            {
                case "imgMover0"://g. Backups
                    
                    break;
                case "imgMover1"://g. Empleados

                    break;
                case "imgMover2"://g. Inventarios
                    new GestionarInventarios().Show();
                    break;
                case "imgMover3"://g. Proveedoes

                    break;
                case "imgMover4"://o. Reportes

                    break;
                case "imgMover5"://g. Clientes
                    new GestionarClientes().Show();
                    break;
                case "imgMover6"://r. Venta

                    break;
                case "imgMover7"://r. Consultas

                    break;
                case "imgMover8"://r. Compras

                    break;
                case "imgMover9"://r. Corte

                    break;
            }
        }

        private void imgMover_MouseMove(object sender, MouseEventArgs e)
        {
            if (ImagePresionada)
            {
                foreach (var item in listPictureBox)
                {
                    if (e.Location.Y >= 0)
                    {
                        mover = 1;
                    }
                    else
                    {
                        mover = -1;
                    }
                    posMouseFormY = item.Location.Y + mover;

                    if (item.Location.Y + 128 > myBase)
                    {
                        posMouseFormY = 21;
                    }

                    if (item.Location.Y < myTope)
                    {
                        posMouseFormY = 325;
                    }

                    moverImage(item, posMouseFormY);
                }
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void moverImage(PictureBox picture, int valuey)
        {
            int valueX;
            if (picture.Location.Y < 60)
            {
                picture.BringToFront();
                picture.Width = 140;
                picture.Height = 140;
                valueX = 65;
            }
            else
            {
                picture.Width = 128;
                picture.Height = 128;
                valueX = 71;
            }

            picture.Location = new System.Drawing.Point(valueX, valuey);            
            
            posActImageY = picture.Location.Y;
        }

        private void imgMover_MouseDown(object sender, MouseEventArgs e)
        {
            ImagePresionada = true;
        }

        private void imgMover_MouseUp(object sender, MouseEventArgs e)
        {
            ImagePresionada = false;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            foreach (var item in listPictureBox)
            {
                if (e.Delta > 0)
                {
                    mover = 10;
                }
                else
                {
                    mover = -10;
                }
                posMouseFormY = item.Location.Y + mover;

                if (item.Location.Y + 128 > myBase)
                {
                    posMouseFormY = 21;
                }

                if (item.Location.Y < myTope)
                {
                    posMouseFormY = 325;
                }

                moverImage(item, posMouseFormY);
            }
        }
    }
}
