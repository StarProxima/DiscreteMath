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

namespace WGSC4
{
    class CombinatorialObject
    {
        private int n, k;


        private int[] tObj;
        private int[] obj;
        public bool SetObj(int[] obj)
        {
            if (this.obj.Length != obj.Length)
            {
                throw new ArgumentException();
                return false;
            }
                

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
            for (int i = 0; i < obj.Length; i++)
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
            char[] newAlphabet15 = new char[5];
            char[] newAlphabet14 = new char[4];
            char[] newAlphabet13 = new char[3];
            
            



            char[] alphabet2 = new char[] { '0', '1', '2', '3', '4', '5', '6' };
            char[] newAlphabet27 = new char[7];
            char[] newAlphabet25 = new char[5];
            char[] newAlphabet23 = new char[3];



            // 4.1 C(6,1) * C(7,2) * C(5,1) * C(5,3) * A(4,2) = 75600
            

            CombinatorialObject obj_C61_Letters = new CombinatorialObject(6, 1); //Сочетание из 6 по 1
            obj_C61_Letters.SetAlphabet(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' });
            obj_C61_Letters.SetObj(new int[] { 0 });

            CombinatorialObject obj_C51_Letters = new CombinatorialObject(5, 1); //Сочетание из 5 по 1
            obj_C51_Letters.SetAlphabet(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' });
            obj_C51_Letters.SetObj(new int[] { 0 });

            CombinatorialObject obj_A42_Letters = new CombinatorialObject(4, 2); //Размещение из 3 по 2
            obj_A42_Letters.SetAlphabet(alphabet1);
            obj_A42_Letters.SetObj(new int[] { 0, 1 });


            CombinatorialObject obj_C72 = new CombinatorialObject(7, 2); //Сочетание из 7 по 2
            obj_C72.SetAlphabet(alphabet2);
            obj_C72.SetObj(new int[] { 0, 1 });

            CombinatorialObject obj_C53 = new CombinatorialObject(5, 3); //Сочетание из 5 по 3
            obj_C53.SetAlphabet(alphabet2);
            obj_C53.SetObj(new int[] { 0, 1, 2 });


            StreamWriter sw = new StreamWriter(@"problem4-1.txt");
            sw.WriteLine(DateTime.Now.ToString());
            
            do
            {
                
                for (int i = 0, t = 0; i < 6; i++)
                {
                    if (obj_C61_Letters.GetCharByNumber(0) != alphabet1[i])
                    {
                        newAlphabet15[t] = alphabet1[i];
                        t++;
                    }
                }

                obj_C51_Letters.SetAlphabet(newAlphabet15);
                obj_C51_Letters.SetObj(new int[] { 0 });
                obj_C72.SetObj(new int[] { 0, 1 });

                do
                {
                    
                    for (int i = 0, t = 0; i < 7; i++)
                    {
                        if (obj_C72.GetCharByNumber(0) != Convert.ToChar(i + "") && obj_C72.GetCharByNumber(1) != Convert.ToChar(i + ""))
                        {
                            newAlphabet25[t] = Convert.ToChar(i + "");
                            t++;
                        }
                    }

                    obj_C53.SetAlphabet(newAlphabet25);
                    obj_C53.SetObj(new int[] { 0, 1, 2 });
                    obj_C51_Letters.SetObj(new int[] { 0 });
                    do
                    {
                        
                        for (int i = 0, t = 0; i < 6; i++)
                        {
                            if (obj_C51_Letters.GetCharByNumber(0) != alphabet1[i] && obj_C61_Letters.GetCharByNumber(0) != alphabet1[i])
                            {
                                newAlphabet14[t] = alphabet1[i];
                                t++;
                            }
                        }

                        obj_A42_Letters.SetAlphabet(newAlphabet14);
                        obj_A42_Letters.SetObj(new int[] { 0, 1 });
                        obj_C53.SetObj(new int[] { 0, 1, 2 });

                        do
                        {
                            
                            do
                            {
                                
                                for (int i = 0, k = 0; i < 7; i++)
                                {
                                    if ((Convert.ToChar(i + "") == obj_C72.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj_C72.GetCharByNumber(1)))
                                    {
                                        sw.Write(obj_C61_Letters.GetCharByNumber(0));
                                    }
                                    else if ((Convert.ToChar(i + "") == obj_C53.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj_C53.GetCharByNumber(1)) || (Convert.ToChar(i + "") == obj_C53.GetCharByNumber(2)))
                                    {
                                        sw.Write(obj_C51_Letters.GetCharByNumber(0));
                                    }
                                    else
                                    {

                                        sw.Write(obj_A42_Letters.GetCharByNumber(k));
                                        k++;
                                    }
                                }
                                sw.WriteLine();

                            } while (obj_A42_Letters.NextA());
                        } while (obj_C53.NextC());
                    } while (obj_C51_Letters.NextC());
                } while (obj_C72.NextC());
            } while (obj_C61_Letters.NextC());

            sw.WriteLine();
            sw.Close();



            //4.2  C(6,2) * C(9,2) * C(7,2) * C(4,1) * C(5,3) * A(3,2) = 2 721 600
            

            alphabet1 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
            newAlphabet14 = new char[4];
            newAlphabet13 = new char[3];



            alphabet2 = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
            newAlphabet27 = new char[7];
            newAlphabet25 = new char[5];
            newAlphabet23 = new char[3];


            


            CombinatorialObject obj_C62_Letters = new CombinatorialObject(6, 2); //Сочетание из 6 по 2
            obj_C62_Letters.SetAlphabet(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' });
            obj_C62_Letters.SetObj(new int[] { 0, 1 });

            CombinatorialObject obj_C41_Letters = new CombinatorialObject(4, 1); //Сочетание из 4 по 1
            obj_C41_Letters.SetAlphabet(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' });
            obj_C41_Letters.SetObj(new int[] { 0 });

            CombinatorialObject obj_A32_Letters = new CombinatorialObject(3, 2); //Размещение из 3 по 2
            obj_A32_Letters.SetAlphabet(new char[] { 'b', 'c', 'd', 'e', 'f' });
            obj_A32_Letters.SetObj(new int[] { 0, 1 });


            CombinatorialObject obj_C92 = new CombinatorialObject(9, 2); //Сочетание из 9 по 2
            obj_C92.SetAlphabet(alphabet2);
            obj_C92.SetObj(new int[] { 0, 1 });

            obj_C72 = new CombinatorialObject(7, 2); //Сочетание из 7 по 2
            obj_C72.SetAlphabet(alphabet2);
            obj_C72.SetObj(new int[] { 0, 1 });

            obj_C53 = new CombinatorialObject(5, 3); //Сочетание из 5 по 3
            obj_C53.SetAlphabet(alphabet2);
            obj_C53.SetObj(new int[] { 0, 1, 2 });

           


            StreamWriter sw2 = new StreamWriter(@"problem4-2.txt");
            sw2.WriteLine(DateTime.Now.ToString());





            
            obj_C92.SetObj(new int[] { 0, 1 });

            
            do
            {
                

                for (int i = 0, t = 0; i < 6; i++)
                {
                    if (obj_C62_Letters.GetCharByNumber(0) != alphabet1[i] && obj_C62_Letters.GetCharByNumber(1) != alphabet1[i])
                    {
                        newAlphabet14[t] = alphabet1[i];
                        t++;
                    }
                }

                obj_C41_Letters.SetAlphabet(newAlphabet14);
                obj_C41_Letters.SetObj(new int[] { 0 });
                obj_C92.SetObj(new int[] { 0, 1 });

                do
                {
                    
                    for (int i = 0, t = 0; i < 9; i++)
                    {
                        if (obj_C92.GetCharByNumber(0) != Convert.ToChar(i + "") && obj_C92.GetCharByNumber(1) != Convert.ToChar(i + ""))
                        {
                            newAlphabet27[t] = Convert.ToChar(i + "");
                            t++;
                        }
                    }

                    obj_C72.SetAlphabet(newAlphabet27);
                    obj_C72.SetObj(new int[] { 0, 1 });


                    do
                    {
                        

                        for (int i = 0, t = 0; i < 9; i++)
                        {
                            if (obj_C92.GetCharByNumber(0) != Convert.ToChar(i + "") && obj_C92.GetCharByNumber(1) != Convert.ToChar(i + "")
                                && obj_C72.GetCharByNumber(0) != Convert.ToChar(i + "") && obj_C72.GetCharByNumber(1) != Convert.ToChar(i + ""))
                            {
                                newAlphabet25[t] = Convert.ToChar(i + "");
                                t++;
                            }
                        }

                        obj_C53.SetAlphabet(newAlphabet25);
                        obj_C53.SetObj(new int[] { 0, 1, 2 });
                        obj_C41_Letters.SetObj(new int[] { 0 });

                        do
                        {
                            
                            for (int i = 0, t = 0; i < 6; i++)
                            {
                                if (obj_C62_Letters.GetCharByNumber(0) != alphabet1[i] && obj_C62_Letters.GetCharByNumber(1) != alphabet1[i]
                                    && obj_C41_Letters.GetCharByNumber(0) != alphabet1[i])
                                {
                                    newAlphabet13[t] = alphabet1[i];
                                    t++;
                                }
                            }

                            obj_A32_Letters.SetAlphabet(newAlphabet13);
                            obj_A32_Letters.SetObj(new int[] { 0, 1 });
                            
                            obj_C53.SetObj(new int[] { 0, 1, 2 });

                            do
                            {
                                
                                do
                                {
                                    for (int i = 0, k = 0; i < 9; i++)
                                    {
                                        if ((Convert.ToChar(i + "") == obj_C92.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj_C92.GetCharByNumber(1)))
                                        {
                                            sw2.Write(obj_C62_Letters.GetCharByNumber(0));
                                        }
                                        else if ((Convert.ToChar(i + "") == obj_C72.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj_C72.GetCharByNumber(1)))
                                        {
                                            sw2.Write(obj_C62_Letters.GetCharByNumber(1));
                                        }
                                        else if ((Convert.ToChar(i + "") == obj_C53.GetCharByNumber(0)) || (Convert.ToChar(i + "") == obj_C53.GetCharByNumber(1)) || (Convert.ToChar(i + "") == obj_C53.GetCharByNumber(2)))
                                        {
                                            sw2.Write(obj_C41_Letters.GetCharByNumber(0));
                                        }
                                        else
                                        {
                                            sw2.Write(obj_A32_Letters.GetCharByNumber(k));
                                            k++;
                                        }
                                    }
                                    sw2.WriteLine();
                                } while (obj_A32_Letters.NextA());
                            } while (obj_C53.NextC());
                        } while (obj_C41_Letters.NextC());
                    } while (obj_C72.NextC());
                } while (obj_C92.NextC());
            } while (obj_C62_Letters.NextC());
            
            
            //15*36*21*4*10*6
            
            

            


            sw2.WriteLine();
            sw2.Close();
        }
    }
}