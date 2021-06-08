using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Maths_TP1
{
    public class RSA
    {
        int p;
        int q;
        int n;
        int e;
        int z;
        public int d;

        public RSA(int param1, int param2, int param3)
        {
            p = param1;
            q = param2;
            e = param3;
            n = p * q;
            z = (p - 1) * (q - 1);

            if (Premier.PremiersEntreEux(e, z) != 1)
            {
                Console.WriteLine("ERREUR : e et z ne sont pas premiers entre eux donc nous ne pouvons pas determiner d");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            List<double> zDecompositionFacteursPremiers = Premier.DecompositionFacteursPremiers(z);
            var o = from x in zDecompositionFacteursPremiers
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };

            // cette liste contient le resultat de la decomposition en facteurs premiers mais factorisée cad au lieu de 2*2^1 + 2*2^1 on a 2^2
            List<double> listPuissance = new List<double>();
            foreach (var x in o)
            {
                listPuissance.Add((x.Value-1) * Math.Pow(x.Value, x.Count-1));
            }
            double phiZ = 1;
            for (int i = 0; i < listPuissance.Count; i++)
            {
               phiZ *= listPuissance[i];
            }

            List<int> puissances = Premier.ExponentiationModulaire(Convert.ToInt32(phiZ - 1));
            double resultSecond = Premier.resultExponentationModulaire(puissances, z, e);
            d = (int)resultSecond;
        }

        public double chiffrement(int messageClair)
        {
            List<int> puissances = Premier.ExponentiationModulaire(e);
            double messageCrypte = (int)Premier.resultExponentationModulaire(puissances, n, messageClair);
            return messageCrypte;
        }

        public double dechiffrement(int messageCrypte)
        {
            List<int> puissances = Premier.ExponentiationModulaire(d);
            double messageDecrypte = (int)Premier.resultExponentationModulaire(puissances, n, messageCrypte);
            return messageDecrypte;
        }

        public List<string> wordToNumber(string word)
        {
            //int wordToInt = Convert.ToInt32(word);
            List<int> intList = new List<int>();
            List<string> strList = new List<string>();
            char[] characters = word.ToCharArray();


            // pour chaque char on check si c'est pas un espace, si c'est le cas on lui met 0 sinon on lui mets sa valeur correspondant a sa place dans l'alphabet
            foreach (char character in characters)
            {
                if (character == ' ')
                {
                    intList.Add(00);
                }
                else
                {
                    intList.Add(character - 64);
                } 
            }
            // on convertie chaque valeur int en str
            foreach (int character in intList)
            {
                if (character.ToString().Length < 2)
                {
                    strList.Add(character.ToString().Insert(0, "0"));
                }
                else
                {
                    strList.Add(character.ToString());
                }
            }
            return strList;
        }

        public List<BigInteger> cut(List<string> strList)
        {
            string concat = String.Join("", strList.ToArray());

            string nToStr = Convert.ToString(this.n);
            int blockSizeLength = nToStr.Length;
            int blockSize = blockSizeLength - 1;
            int length = concat.Length;
            int reste = length % blockSize;

            while (blockSize < length)
            {
                if (reste == 1)
                {
                    concat = concat.Insert(length, "00");
                    reste--;
                }
                else if (reste == 2)
                {                
                    concat = concat.Insert(length, "0");
                    reste -= 2;
                }
                else
                {
                    concat = concat.Insert(blockSize, " ");
                    blockSize += 4;
                    length++;
                }
            }
            Console.WriteLine("\n\n\nLe mot trié par block de n-1 chiffre est :\n" + concat + "\n");
            List<BigInteger> intList = new List<BigInteger>();
            string[] split = concat.Split(' ');
            foreach (string str in split)
            {
                intList.Add(BigInteger.Parse(str));
            }

            return intList;
        }
    }
}
