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
        public int currBlockIndex = 0;
        public bool fla = true;
        public bool first = true;
        public Random R = new Random();
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


            point.X = 100 + (currIndex * 50);
            point.Y = 300;
            line.SetVals(point.X, point.Y, blocks[currBlockIndex].x, blocks[currBlockIndex].y);
         



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
                    PointF pn = new PointF(100 + (i * 50),300);
                    Lpoints.Add(pn);

                }


            }


            return 0;



        }

        public int CalcIndexToReplace(List<int> valsOfBlock, int[] vals, int nVals, int valsIndex)

        {
            List<int> temp = new List<int>();

            for (int i=0;i<valsOfBlock.Count;i++)
            {
                if (valsOfBlock[i ] == -1)
                {
                    return i;
                }
                temp.Add(valsOfBlock[i]);
            }

            int result = 0;
            int[] posOfVal = new int[valsOfBlock.Count()];

            for (int i=0;i<valsOfBlock.Count;i++)
            {
                posOfVal[i] = temp[i];
            }

            for (int i = valsIndex+1; i < nVals; i++)
            {
                for (int j=0;j<temp.Count;j++)
                {
                    if (temp.Count == 1)
                    {
                        for (int k =0;k< valsOfBlock.Count;k++)
                        {
                            if (temp[0] == posOfVal[k])
                            {
                                return k;
                            }
                        }
                    }
                    if (temp[j] == vals[i] )
                    {

                        
                        temp.RemoveAt(j);
                        break;
                    }
                }
            }


            return result;

        }

        public void Visualize(Graphics  screen)

        {

            if (currIndex  == values.Length)
            {
                return;
            }
            screen.Clear(Color.White);
            
            string fontName = "Cambria";
            Font  font = new Font(fontName, 20.0f, FontStyle.Regular,
                                     GraphicsUnit.Pixel);


            line.MoveStep();
            Lpoints[currIndex] = new PointF(line.currX, line.currY);

            if (Math.Abs(Lpoints[currIndex].X - blocks[currBlockIndex].x) <5
                
              )

            {
                if (Math.Abs(Lpoints[currIndex].Y - blocks[currBlockIndex].y) < 5)
 
                {

                    if (first)
                    {
                        blocks[currBlockIndex].AttachValToBlock(values[currIndex]);
                        values[currIndex] = -1;
                        currIndex++;
                        connect = true;
                        first = false;
                    }
                    else
                    {

                        for (int j=0;j<frames;j++)
                        {
                            if (blocks[currBlockIndex].Lvalues[j] == values[currIndex])
                            {
                                hits++;
                                fla = false;
                                Lpoints[currIndex] = new PointF(-1000, 1000);
                                currIndex++;
                                connect = true;
                                break;
                            }
                            else
                            {
                                fla = true;
                            }
                        }


                        if (fla)
                        {
                            int[] temp = new int[frames];
                            for (int i = 0; i < frames; i++)
                            {
                                temp[i] = blocks[currBlockIndex].Lvalues[i];
                            }
                            Block pn = Block.ReplaceCell(blocks[currBlockIndex],
                                CalcIndexToReplace(blocks[currBlockIndex].Lvalues,  values, n, currIndex), values[currIndex]


                                );


                            blocks.Add(pn);
                            Lpoints[currIndex] = new PointF(-1000, 1000);
                            currIndex++;
                            connect = true;
                            currBlockIndex++;

                          
                          
                        }


                    }
                
                }
            
            }
            for (int i=0;i<n;i++)
            {

                if (values[i] != -1)
                {                
                    screen.DrawString(values[i].ToString(), font, Brushes.Black, Lpoints[i]);
                }
 
            }

            screen.DrawString("Total number of  hits: " + hits.ToString(), font, Brushes.Black, 1000, 100);
            screen.DrawString("Total number of  faults: " + blocks.Count, font, Brushes.Black, 1000, 120);
            DrawBlocks(screen);

            if (connect)
            {
                ConnectLine();
                connect = false;
            }

            //line.DrawLine(screen    );


        }
        public void Randomize()
        {
            for (int i=0;i<n;i++)
            {
                values[i] = R.Next(10);
            }
        }
        public void MakeBlocks()
        {

            for (int i=0;i<1;i++)
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
