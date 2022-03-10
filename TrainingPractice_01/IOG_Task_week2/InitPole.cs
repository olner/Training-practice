using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOG_Task_week2
{
    class InitPole
    {
        public static int[] initNewGame()
        {
            int[] numLabel = new int[45];
            Random rnd = new Random();
            for (int i = 0; i < 45; i++)
            {
                numLabel[i] = i + 1;
            }

            for (int i = 0; i < 45; i++)
            {
                int j = rnd.Next(i + 1);
                if (j != i)
                {
                    int tmp = numLabel[i];
                    numLabel[i] = numLabel[j];
                    numLabel[j] = tmp;
                }
            }
            return numLabel;
        }
    }
}
