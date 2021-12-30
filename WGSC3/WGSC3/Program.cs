using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣀⣀⣀⠄⠄⠄⠄⡀⠄⠄⡀⠠⣤⣄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠉⢉⡏⠄⠄⠄⢸⡇⠄⣼⠇⠄⢀⡏⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣸⣧⡤⣤⡀⠈⠓⠚⣿⠄⠄⣸⠳⠶⢶⡀⠄⠄
⠄⠄⠄⠄⣀⡀⠄⠄⠄⠄⠄⠄⣿⠁⠄⣸⡇⣀⣠⡴⠟⠄⠄⣿⣀⣀⣼⠇⠄⠄
⠄⣠⣶⣿⣿⣿⣿⠆⠄⠄⠄⠄⠻⠦⠶⠋⠄⠉⠄⠄⠄⠄⠄⠉⠉⠉⠁⠄⠄⠄
⢰⣿⣿⡿⠛⠉⠉⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⢸⣿⣿⡇⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⣀⣠⣤⣀⣀⠄⠄⠄⠄⢀⣀⣀⣀⡀⠄⠄
⠄⢿⣿⣧⠄⠄⠄⠄⠄⠄⢀⣴⣿⣿⣿⣿⣿⣿⣿⣷⣄⠄⣼⣿⣿⣿⣿⣿⣦⠄
⠄⠘⣿⣿⣧⡀⠄⠄⠄⢠⣾⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⡀⠹⠿⠛⠉⢹⣿⣿⡄
⠄⠄⠈⢿⣿⣿⣄⠄⢠⣿⣿⣿⣇⣍⢹⣿⣯⣰⣼⣿⡿⠁⠄⠄⠄⢀⣾⣿⣿⠃
⠄⠄⠄⠈⢿⣿⣿⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠁⠄⠄⢀⣴⣾⣿⡿⠃⠄
⠄⠄⠄⠄⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣤⣶⣿⣿⣿⠟⠋⠄⠄⠄
⠄⠄⠄⠄⠄⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠉⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⢸⣿⣿⣿⣿⠋⠉⠉⠉⠘⣿⣿⣿⣿⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⢸⣿⣿⣿⡏⠄⠄⠄⠄⠄⢹⣿⣿⣿⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⢸⣿⣿⣿⡇⠄⠄⠄⠄⠄⠸⣿⣿⣿⡄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⣿⣿⣿⣿⠄⠄⠄⠄⠄⠄⠄⣿⣿⣿⣷⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⣿⣿⣿⡇⠄⠄⠄⠄⠄⠄⠄⢸⣿⣿⣿⡆⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⢰⣿⣿⣿⣄⠄⠄⠄⠄⠄⠄⠄⠈⣿⣿⣿⣿⣶⡄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠈⠻⣿⣿⡟⠄⠄⠄⠄⠄⠄⠄⠄⢿⣿⣿⣿⠿⠃⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄*/

namespace WGSC3
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

        public bool ObjContains(int x)
        {
            for(int i = 0; i < obj.Length;i++)
            {
                if (obj[i] == x) return true;
            }
            return false;
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

            for (int i = 0; i < k; i++)
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



            char[] alphabet1 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
            char[] newAlphabet1 = new char[5];

            // 3.1 C(6,1) * C(5,2) * A(5,3) = 6*600 = 3600

            CombinatorialObject obj1 = new CombinatorialObject(5, 3); //Размещение с повторениями из 5 по 3
            //obj1.SetAlphabet(new char[] { 'b', 'c', 'd', 'e', 'f' });
            obj1.SetObj(new int[] { 0, 0, 0 });


            CombinatorialObject obj2 = new CombinatorialObject(5, 2); //Сочетание из 5 по 2
            obj2.SetAlphabet(new char[] { '0', '1', '2', '3', '4' });
            obj2.SetObj(new int[] { 0, 1 });




            StreamWriter sw = new StreamWriter(@"problem3-1.txt");
            sw.WriteLine(DateTime.Now.ToString());


            for(int w = 0; w < 6; w++)
            {
                for (int w2 = 0, t = 0; w2 < 6; w2++)
                {
                    if(w2 != w)
                    {
                        newAlphabet1[t] = alphabet1[w2];
                        t++;
                    }
                }

                obj1.SetAlphabet(newAlphabet1);
                obj1.SetObj(new int[] { 0, 0, 0 });
                obj2.SetObj(new int[] { 0, 1 });

                do
                {
                    do
                    {
                        for (int i = 0, k = 0; i < 5; i++)
                        {
                            if ((Convert.ToChar(i + "") == obj2.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj2.GetCharByNumber(1)))
                            {
                                sw.Write(alphabet1[w]);
                            }
                            else
                            {
                                sw.Write(obj1.GetCharByNumber(k));
                                k++;
                            }
                        }
                        sw.WriteLine();

                    } while (obj1.NextA());
                } while (obj2.NextC());

            }

            

            sw.WriteLine();
            sw.Close();




            // 3.2 C(6,2) * C(6,2) * C(4,2) * A(4,2) = 16200

            newAlphabet1 = new char[4];

            char[] alphabet2 = new char[] { '0', '1', '2', '3', '4', '5' };
            char[] newAlphabet2 = new char[4];

            CombinatorialObject obj_C62_Letters = new CombinatorialObject(6, 2); //Сочетание из 4 по 2
            obj_C62_Letters.SetAlphabet(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' }); 
            obj_C62_Letters.SetObj(new int[] { 0, 1 });

            CombinatorialObject obj_A42_Letters = new CombinatorialObject(4, 2); //Размещение из 4 по 2
            obj_A42_Letters.SetAlphabet(new char[] { 'b', 'c', 'd', 'e', 'f' }); 
            obj_A42_Letters.SetObj(new int[] { 0, 1});


            CombinatorialObject obj2_C62 = new CombinatorialObject(6, 2); //Сочетание из 5 по 2
            obj2_C62.SetAlphabet(alphabet2); 
            obj2_C62.SetObj(new int[] { 0, 1 });

            CombinatorialObject obj_C42 = new CombinatorialObject(4, 2); //Сочетание из 4 по 2
            //obj_C42.SetAlphabet(new char[] { '0', '1', '2', '3' }); 
            obj_C42.SetObj(new int[] { 0, 1 });


            StreamWriter sw2 = new StreamWriter(@"problem3-2.txt");
            sw2.WriteLine(DateTime.Now.ToString());





            obj_A42_Letters.SetAlphabet(newAlphabet1);
            obj_A42_Letters.SetObj(new int[] { 0, 0});
            obj2_C62.SetObj(new int[] { 0, 1 });

            do
            {

                for (int i = 0, t = 0; i < 6; i++)
                {
                    if (obj_C62_Letters.GetCharByNumber(0) != alphabet1[i] && obj_C62_Letters.GetCharByNumber(1) != alphabet1[i])
                    {
                        newAlphabet1[t] = alphabet1[i];
                        t++;
                    }
                }

                obj_A42_Letters.SetAlphabet(newAlphabet1);
                obj_A42_Letters.SetObj(new int[] { 0, 1 });
                obj2_C62.SetObj(new int[] { 0, 1 });
                do
                { 
                    
                    for (int i = 0, t = 0; i < 6; i++)
                    {
                        if(obj2_C62.GetCharByNumber(0) != Convert.ToChar(i+"") && obj2_C62.GetCharByNumber(1) != Convert.ToChar(i + ""))
                        {
                            newAlphabet2[t] = Convert.ToChar(i + "");
                            t++;
                        }
                    }

                    obj_C42.SetAlphabet(newAlphabet2);
                    obj_C42.SetObj(new int[] { 0, 1 });

                    do
                    {
                        do
                        {
                            for (int i = 0, k = 0; i < 6; i++)
                            {
                                if ((Convert.ToChar(i + "") == obj2_C62.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj2_C62.GetCharByNumber(1)))
                                {
                                    sw2.Write(obj_C62_Letters.GetCharByNumber(0));
                                }
                                else if ((Convert.ToChar(i + "") == obj_C42.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj_C42.GetCharByNumber(1)))
                                {
                                    sw2.Write(obj_C62_Letters.GetCharByNumber(1));
                                }
                                else
                                {
                                    sw2.Write(obj_A42_Letters.GetCharByNumber(k));
                                    k++;
                                }
                            }
                            sw2.WriteLine();

                        } while (obj_A42_Letters.NextA());
                    } while (obj_C42.NextC());
                } while (obj2_C62.NextC());
            } while (obj_C62_Letters.NextC());
            
            //4:28 ночи, оно заработало.. Я молодец.
          

            sw2.WriteLine();
            sw2.Close();
        }
    }
}