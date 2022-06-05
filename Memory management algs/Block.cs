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
    class Block
    {


        public int n_frames = 0;
        public int x, y, w  ;
        public List<int>  Lvalues =     new List<int>() ;

     

        public Block(int n, int x_pos, int y_pos )
        {
            n_frames = n;
            x = x_pos;
            y = y_pos;
            w = 50;
            for (int i=0;i<n_frames;i++)
            {
                Lvalues.Add(-1);
            }

        }


        public bool IsBlockFull()
        {

            for (int i=0;i<n_frames;i++)
            {
                if (Lvalues[i] == -1)
                {
                    return false;
                }
            }
            return true;
        }


        public void Draw(Graphics screen)
        {

            string fontName = "Cambria";
            Font font = new Font(fontName, 20.0f, FontStyle.Regular,
                                     GraphicsUnit.Pixel);
            for (int i=0;i<n_frames;i++)
            {
                screen.DrawRectangle(Pens.Black, x, y + (50 * i), w , w);


                if(Lvalues[i] != -1)
                {
                    screen.DrawString(Lvalues[i].ToString(), font, Brushes.Black, x + 20,
                18 + y + (50 * i));

                }

            }
        }

        public void AttachValToBlock(int val)
        { 
            {
                for (int i=0;i<n_frames;i++)
                {
                    if (Lvalues[i] == -1 )
                    {
                        Lvalues[i] = val;
                        break;
                    }
                }
            }
            
        }


        public static Block ReplaceCell(Block block, int cellINdex , int newVal )

        {
            Block newBlock = new Block(block.n_frames, block.x + 100, block.y);


            for (int i=0;i< newBlock.n_frames;i++)
            {
                if ( i == cellINdex)
                {
                    newBlock.Lvalues[i] = newVal;
                }
                else
                {
                    newBlock.Lvalues[i] = block.Lvalues[i];
                }
            }

            return newBlock;
        }
       
    }
}
