using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WGSC2
{
    class CombinatorialObject
    {
        private int n, k;


        private int[] tObj;
        private int[] obj;
        public bool SetObj(int[] obj)
        {
            if (this.obj.Length != obj.Length)
                return false;

            for (int i = 0; i < obj.Length; i++)
            {
                this.obj[i] = obj[i];
            }

            return true;
        }


        public char[] alphabet;
        public bool SetAlphabet(char[] alphabet)
        {
            if (this.alphabet.Length != alphabet.Length)
                return false;

            for (int i = 0; i < alphabet.Length; i++)
            {
                this.alphabet[i] = alphabet[i];
            }

            return true;
        }

        public char GetCharByNumber(int x)
        {
            return alphabet[obj[x]];
        }



        
        
        
        void Swap(int i, int j)
        {
            int b = tObj[i];
            tObj[i] = tObj[j];
            tObj[j] = b;
        }

        
        public bool NextAr()
        {
            bool b = false;
            for (int i = k - 1; i >= 0; i--)
            {
                if (obj[i] != n - 1)
                {
                    b = true;
                    break;
                }
            }
            
            for (int i = k - 1; i >= 0; i--)
            {
                if (obj[i] == n - 1)
                {
                    obj[i] = 0;
                    continue;
                }
                obj[i]++;
                break;
            }

            return b;
        }

        public bool NextA()
        {
            int j;
            do
            {
                j = n - 2;
                while (j != -1 && tObj[j] >= tObj[j + 1])
                {
                    j--;
                }

                if (j == -1)
                {
                    for (int i = 0; i < n; i++)
                        tObj[i] = i;
                    
                    return false; 
                }

                int l = n - 1;
                while (tObj[j] >= tObj[l])
                {
                    l--;
                }

                Swap(j, l);

                int t = j + 1;
                int h = n - 1;

                while (t < h)
                {
                    Swap(t++, h--);
                }
            } while (j > k - 1);

            for(int i = 0; i < k; i++)
                obj[i] = tObj[i];

            return true;
        }

        public bool NextC()
        {
            
            for (int i = k - 1; i >= 0; i--)
            {
                if (obj[i] < n - k + i)
                {
                    obj[i]++;
                    for (int j = 0; i + j < k; j++)
                        obj[i + j] = obj[i] + j;
                    return true;
                }
            }
                
            return false;
        }

        public CombinatorialObject(int n, int k)
        {
            this.n = n;
            this.k = k;

            alphabet = new char[n];
            obj = new int[k];
            tObj = new int[n];
            for (int i = 0; i < n; i++)
                tObj[i] = i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 2.1 C(5,2)* ~A(5,3) = 1250

            CombinatorialObject obj1 = new CombinatorialObject(5, 3); //Размещение с повторениями из 5 по 3
            obj1.SetAlphabet(new char[] { 'b', 'c', 'd', 'e', 'f' });
            obj1.SetObj(new int[] { 0, 0, 0 });


            CombinatorialObject obj2 = new CombinatorialObject(5, 2); //Сочетание из 5 по 2
            obj2.SetAlphabet(new char[] { '0', '1', '2', '3', '4' });
            obj2.SetObj(new int[] { 0, 1 });




            StreamWriter sw = new StreamWriter(@"problem2-1.txt");
            sw.WriteLine(DateTime.Now.ToString());

            do
            {
                do
                {
                    for (int i = 0, k = 0; i < 5; i++)
                    {
                        if ((Convert.ToChar(i + "") == obj2.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj2.GetCharByNumber(1)))
                        {
                            sw.Write('a');
                        }
                        else
                        {
                            sw.Write(obj1.GetCharByNumber(k));
                            k++;
                        }
                    }
                    sw.WriteLine();

                } while (obj1.NextAr());
            } while (obj2.NextC());

            sw.WriteLine();
            sw.Close();




            // 2.2 C(5,2)*A(5,3) = 600



            obj1 = new CombinatorialObject(5, 3);
            obj1.SetAlphabet(new char[] { 'b', 'c', 'd', 'e', 'f' }); //Размещение из 5 по 3
            obj1.SetObj(new int[] { 0, 1, 2 });


            obj2 = new CombinatorialObject(5, 2);
            obj2.SetAlphabet(new char[] { '0', '1', '2', '3', '4' }); //Сочетание из 5 по 2
            obj2.SetObj(new int[] { 0, 1 });


            StreamWriter sw2 = new StreamWriter(@"problem2-2.txt");
            sw2.WriteLine(DateTime.Now.ToString());

            do
            {
                do
                {
                    for (int i = 0, k = 0; i < 5; i++)
                    {
                        if ((Convert.ToChar(i + "") == obj2.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj2.GetCharByNumber(1)))
                        {
                            sw2.Write('a');
                        }
                        else
                        {
                            sw2.Write(obj1.GetCharByNumber(k));
                            k++;
                        }
                    }
                    sw2.WriteLine();

                } while (obj1.NextA());
            } while (obj2.NextC());


            sw2.WriteLine();
            sw2.Close();
        }
    }
}