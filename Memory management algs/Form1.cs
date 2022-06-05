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
        Optimal op;
        Timer T = new Timer

            ();

        bool Optimal = false;
        bool Look = false;
        Look look = new Look();
        Random R = new Random();
        public Form1()
        {
            this.Load += Form1_Load;

            this.Paint += Form1_Paint;
            T.Tick += T_Tick;
            this.KeyDown += Form1_KeyDown;   


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.O)
            {
               op = new Optimal(19, 3);
            

                int[] pg = { 7, 0, 1, 2, 0, 3, 0, 4, 2, 3, 0, 3, 2, 1, 2, 0, 1, 7, 0, 1 };
                op.setVals(pg);
                op.Visualize(CreateGraphics());
                Optimal = true;
                Look = false;

            }
            if (e.KeyCode == Keys.L)
            {
              Look = true;
                Optimal = false;

                // Request array
                int[] arr = { 176, 79, 34, 60,
                  92, 11, 41, 114 };
                int head = 50;
                string direction = "right";

       

                look.LOOK(arr, head, direction);
              


            }
            if (e.KeyCode == Keys.Enter)
            {
                T.Start();
            }

             if (e.KeyCode == Keys.R)
            {

                if (Look)
                {
                    int[] arr = { 176, 79, 34, 60,
                  92, 11, 41, 114 };
                    int head = 50;
                    string direction = "right";


                    look = new Look();
                    look.LOOK(RandomizeArray(arr,arr.Length), head, direction);



                }

                if (Optimal)
                {
                    op.Randomize();
                }
             
              //  op.Visualize(CreateGraphics());


            }
        }

        public int[] RandomizeArray(int []arr, int n)
        {
            for (int i=0;i < n;i++)
            {
                arr[i] = R.Next(200);
            }

            return arr; 
        }

        private void T_Tick(object sender, EventArgs e)
        {




            DrawDubb(CreateGraphics());
           
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            Off = new Bitmap(this.Width, this.Height);

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
            g.Clear(Color.White);

            if (Optimal)

            {
                op.Visualize(g);

            }

            if (Look)
            {
                look.Draw(g);
            }

        }




    }
}


