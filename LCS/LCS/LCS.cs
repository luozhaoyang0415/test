using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    class LCS
    {
        /// <summary>
        /// b[i,j]记录指示c[i,j]的值是由哪一个子问题的解达到的
        /// c[i,j]存储Xi与Yj的最长公共子序列的长度
        /// </summary>
        string[,] b;
        int[,] c;

        public void LCS_LENGTH(int[] X, int[] Y)
        {
            b = new string[X.Length, Y.Length];
            c = new int[X.Length + 1, Y.Length + 1];
            for (int i = 0; i <= X.Length; i++)
            {
                c[i, 0] = 0;//j=0,c[i,j]=0;表示最长公共子序列的长度为0
            }
            for (int j = 0; j <= Y.Length; j++)
            {
                c[0, j] = 0;//i=0,c[i,j]=0;表示最长公共子序列的长度为0
            }
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < Y.Length; j++)
                {
                    if (X[i] == Y[j])
                    {
                        c[i + 1, j + 1] = c[i, j] + 1;
                        b[i, j] = "left_up";//lu表示左上↖
                    }
                    else if (c[i, j + 1] >= c[i + 1, j])
                    {
                        c[i + 1, j + 1] = c[i, j + 1];
                        b[i, j] = "up";//up表示↑
                    }
                    else
                    {
                        c[i + 1, j + 1] = c[i + 1, j];
                        b[i, j] = "left"; //left表示←
                    }
                }
            }
        }
        public void LCSP(string[,] b, int[] X, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return;
            }
            if (b[i, j] == "left_up")
            {
                LCSP(b, X, i - 1, j - 1);
                Console.WriteLine("{0}", X[i]);
            }
            else if (b[i, j] == "up")
            {
                LCSP(b, X, i - 1, j);
            }
            else
            {
                LCSP(b, X, i, j - 1);
            }
        }
        static void Main(string[] args)
        {
            int[] list1 = { 34, 72, 13, 44, 25, 30, 10,7 };
            int[] list2 = { 34, 13, 44, 7, 25 };
            LCS lcs = new LCS();
            lcs.LCS_LENGTH(list1, list2);
            for (int i = 0; i < list1.Length; i++)
            {
                for (int j = 0; j < list2.Length; j++)
                {
                    //lcs.LCSP(lcs.b, list1, i, j);
                    if (lcs.b[i, j] == "left_up")
                    {
                        Console.WriteLine("{0}", list1[i]);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
