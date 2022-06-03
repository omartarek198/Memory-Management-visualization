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

                }
            }


            return 0;



        }

        public void Visualize(Graphics  screen)

        {
            string fontName = "Cambria";
            Font  font = new Font(fontName, 20.0f, FontStyle.Regular,
                                     GraphicsUnit.Pixel);

            for (int i=0;i<n;i++)
            {
                screen.DrawString(values[i].ToString(), font, Brushes.Black, 300 + (i * 100), 500);
            }

            DrawBlocks(screen);
        }

        public void MakeBlocks()
        {

            for (int i=0;i<5;i++)
            {
                Block pn = new Block(frames, 200 + (i * 100), 500);
                blocks.Add(pn);
            }

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
