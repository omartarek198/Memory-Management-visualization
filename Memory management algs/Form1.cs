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
        Timer T = new Timer
            ();
        public Form1()
        {
            this.Load += Form1_Load;

            this.Paint += Form1_Paint;
            T.Tick += T_Tick;
            T.Start();


        }

        private void T_Tick(object sender, EventArgs e)
        {

            op.Visualize(CreateGraphics());
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            op.Visualize(CreateGraphics());


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


            int[] pg = { 7, 0, 1, 2, 0, 3, 0, 4, 2, 3, 0, 3, 2 };
            op.setVals(pg);
        

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


