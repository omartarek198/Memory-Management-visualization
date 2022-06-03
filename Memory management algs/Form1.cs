using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_management_algs
{



    public partial class Form1 : Form
    {









        public Bitmap Off;
        Optimal op = new Optimal(10, 4);

        public Form1()
        {
            this.Load += Form1_Load;

            this.Paint += Form1_Paint;
    

        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            op.Visualize(e.Graphics);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }


        public void DrawDubb(Graphics g)
        {



            Graphics g2 = Graphics.FromImage(Off);
            DrawScene(g2);
            g.DrawImage(Off, 0, 0);


        }



        public void move()
        {




        }



        public void DrawScene(Graphics g)
        {



        }




    }
}


