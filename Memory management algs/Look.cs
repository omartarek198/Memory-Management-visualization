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
    class Look
    {


        static int size = 8;


        public List<int> seek_sequence = new List<int>();
        Random R = new Random();
        public int seek_count = 0;
        public int firsThead = 0;
        public  void LOOK(int[] arr, int head,
                         string direction)
        {
           seek_count = 0;
            int distance, cur_track;
            firsThead = head;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            // Appending values which are
            // currently at left and right
            // direction from the head.
            for (int i = 0; i < size; i++)
            {
                if (arr[i] < head)
                    left.Add(arr[i]);
                if (arr[i] > head)
                    right.Add(arr[i]);
            }

            // Sorting left and right vectors
            // for servicing tracks in the
            // correct sequence.
            left.Sort();
            right.Sort();

            // Run the while loop two times.
            // one by one scanning right
            // and left side of the head
            int run = 2;
            while (run-- > 0)
            {
                if (direction == "left")
                {
                    for (int i = left.Count - 1; i >= 0; i--)
                    {
                        cur_track = left[i];

                        // Appending current track to
                        // seek sequence
                        seek_sequence.Add(cur_track);

                        // Calculate absolute distance
                        distance = Math.Abs(cur_track - head);

                        // Increase the total count
                        seek_count += distance;

                        // Accessed track is now the new head
                        head = cur_track;
                    }

                    // Reversing the direction
                    direction = "right";
                }
                else if (direction == "right")
                {
                    for (int i = 0; i < right.Count; i++)
                    {
                        cur_track = right[i];

                        // Appending current track to
                        // seek sequence
                        seek_sequence.Add(cur_track);

                        // Calculate absolute distance
                        distance = Math.Abs(cur_track - head);

                        // Increase the total count
                        seek_count += distance;

                        // Accessed track is now new head
                        head = cur_track;
                    }

                    // Reversing the direction
                    direction = "left";
                }
            }

            Console.WriteLine("Total number of seek " +
                               "operations = " + seek_count);

            Console.WriteLine("Seek Sequence is");

            for (int i = 0; i < seek_sequence.Count; i++)
            {
                Console.WriteLine(seek_sequence[i]);
            }



        }


        public void Randomize()
        {
            for (int i = 0; i < seek_sequence.Count(); i++)
            {
                seek_sequence[i] = R.Next(200);
            }
             
        }


        public void Draw(Graphics screen)
        {




            string fontName = "Cambria";
            Font font = new Font(fontName, 20.0f, FontStyle.Regular,
                                     GraphicsUnit.Pixel);

            screen.DrawString("Total number of seek " +
                               "operations = " + seek_count.ToString(), font, Brushes.Black, 1000 ,50
              );
            font = new Font(fontName, 12.0f, FontStyle.Regular,
                                    GraphicsUnit.Pixel);
            screen.DrawLine(Pens.Black,0, 100, 800, 100);


          
                for (int i = 0; i < seek_sequence.Count; i++)
                {
                    screen.DrawString(seek_sequence[i].ToString(), font, Brushes.Black, seek_sequence[i] * 4,
                 98);
                }

          

            for (int i=0;i<seek_sequence.Count;i++)
            {
                screen.DrawLine(Pens.Black, seek_sequence[i] * 4, 85, seek_sequence[i] * 4, 115);
            }
            int y = 50;
            screen.DrawLine(Pens.Blue, firsThead * 4, 50 + y, seek_sequence[0] * 4, 100 + y);
            for (int i=0;i<seek_sequence.Count-1;i++)
            {
                screen.DrawLine(Pens.Red, seek_sequence[i] * 4, 100 + y , seek_sequence[i+1] * 4,  150 + y);
                screen.FillEllipse(Brushes.Black,-5+ seek_sequence[i + 1] * 4, -5 +150 + y, 10, 10);
            y += 50;
            }
        }
    }


}