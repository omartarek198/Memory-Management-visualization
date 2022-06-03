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
    class Optimal
    {


        public int frames, faults, hits;
        public int[] values;
        public int n;
        public List<Block> blocks = new List<Block>();
        public List<PointF> Lpoints = new List<PointF>();
        Timer T = new Timer();
        PointF point = new PointF();
        public DDALine line = new DDALine();
        public int currIndex = 0;
        public bool connect = true;
        public Optimal( int n_values, int n_frames)
        {
            n = n_values;
            frames = n_frames;
            values = new int[n];


            for (int i = 0; i < n; i++)
            {

                values[i] = 0;
            }
            MakeBlocks();
            T.Tick += T_Tick;




        }

        private void T_Tick(object sender, EventArgs e)
        {




          
        }


        public void ConnectLine()
        {


            point.X = 300 + (currIndex * 100);
            point.Y = 300;
            line.SetVals(point.X, point.Y, blocks[currIndex].x, blocks[currIndex].y);
         



                               }

        public int setVals(int []vals)
        {
            for (int i = 0; i < n; i++)
            {

                if (vals[i] < 0)
                {
                    return  -1; // error
                }
                else
                {
                    values[i] = vals[i];
                    PointF pn = new PointF(300 + (i * 100),300);
                    Lpoints.Add(pn);

                }


            }


            return 0;



        }

        public void Visualize(Graphics  screen)

        {
            screen.Clear(Color.White);
             line.MoveStep();
            Lpoints[0] = new PointF(line.currX, line.currY); 
            string fontName = "Cambria";
            Font  font = new Font(fontName, 20.0f, FontStyle.Regular,
                                     GraphicsUnit.Pixel);

            for (int i=0;i<n;i++)
            {
                screen.DrawString(values[i].ToString(), font, Brushes.Black ,Lpoints[i]);
            }

            DrawBlocks(screen);

            if (connect)
            {
                ConnectLine();
                connect = false;
            }
      
            line.DrawLine(screen    );
        }

        public void MakeBlocks()
        {

            for (int i=0;i<5;i++)
            {
                Block pn = new Block(frames, 200 + (i * 100), 500);

                //for (int j=0; j <frames;j++)
                //{
                //    pn.AttachValToBlock(j);
                //}
                blocks.Add(pn);
              

            
            }
//blocks.Add(Block.ReplaceCell(blocks[4], 0, 5));
        }
       
        public void DrawBlocks(Graphics screen)
        {
            for (int i=0;i<blocks.Count;i++)
            {
                blocks[i].Draw(screen);
            }
        }
        
    }

}
