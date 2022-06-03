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


        int n_frames = 0;
        int x, y, w  ;
        public List<int>  Lvalues =     new List<int>() ;

        public Block(int n, int x_pos, int y_pos )
        {
            n_frames = n;
            x = x_pos;
            y = y_pos;
            w = 50;


        }


        public void Draw(Graphics screen)
        {
            for (int i=0;i<n_frames;i++)
            {
                screen.DrawRectangle(Pens.Black, x, y + (50 * i), w , w);



            }
        }

    }
}
