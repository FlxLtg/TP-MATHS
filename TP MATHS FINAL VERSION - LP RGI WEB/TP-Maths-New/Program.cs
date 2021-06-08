using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Maths_TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quel opération voulez vous executer ?\n- Calculer les nombres premiers d'un nombre [PRESS A]" +
                "\n\n- Calculer les nombres premiers situés entre deux nombres [PRESS B]" +
                "\n- Calculer le PGCD de deux nombres [PRESS C]" +
                "\n- Decomposer en produit de facteurs premiers [PRESS D]" +
                "\n- Calculer l'indicateur Euler d'un nombre [PRESS E]" +
                "\n- Calculer un nombre a grande puissance modulo n grace a l'exponensation modulaire [PRESS F]" +
                "\n- Calculer la clef de déchiffrement d'un modéle RSA [PRESS G]" +
                "\n- Chiffrer un message (selon un triplet donné p, q, e) [PRESS H]" +
                "\n- Dechiffrer un message (selon un triplet donné p, q, e) [PRESS I]" +
                "\n- Traduire un mot en suite de nombre (selon un triplet donné) [PRESS J]" +
                "\n");

            var userChoice = Console.ReadLine().ToUpper();

            if (userChoice == "A")
            {
                Console.WriteLine("\n\nVeuillez saisir un nombre entier : ");
                string input = Console.ReadLine();
                bool success = double.TryParse(input, out double n);
                bool success2 = n % 1 == 0;
                if (success & success2)
                {
                    List<double> result = Premier.NombrePremier(n);
                    if (result.Count > 0)
                    {
                        Console.WriteLine("\n\nLes nombres premiers de " + n + " sont :\n");
                        result.ForEach(i => Console.Write("{0}\t", i));
                        Console.WriteLine("\n\n\n\n\n\n\n\n");
                    }
                    else
                    {
                        Console.WriteLine("\n\nAucuns nombres premiers pour ce nombre..\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre entier..\n\n\n\n\n\n\n\n");
                }
            }
            else if (userChoice == "B")
            {
                Console.WriteLine("\n\nVeuillez saisir un premier nombre entier (le plus petit des deux) : ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int n);

                if (success)
                {
                    Console.WriteLine("\n\nVeuillez saisir un second nombre entier (le plus grand des deux) : ");
                    string input2 = Console.ReadLine();
                    bool success2 = int.TryParse(input2, out int p);
                    if (success2)
                    {
                        bool success3 = p > n;
                        if (success3)
                        {
                            List<int> result = Premier.NombrePremier2(n, p);
                            if (result.Count > 0)
                            {
                                Console.WriteLine("\n\nLes nombres premiers situés entre " + n + " et " + p + " sont :\n");
                                result.ForEach(i => Console.Write("{0}\t", i));
                                Console.WriteLine("\n\n\n\n\n\n\n\n");
                            }
                            else
                            {
                                Console.WriteLine("\n\nAucuns nombres premiers se situent entre ces deux nombres..\n\n\n\n\n\n\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nVous n'avez pas saisi un nombre plus grand que le precedent !\n\n\n\n\n\n\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");

                }

            }
            else if (userChoice == "C")
            {
                Console.WriteLine("\n\nVeuillez saisir un premier nombre entier (le plus grand des deux) : ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int n);

                if (success)
                {
                    Console.WriteLine("\n\nVeuillez saisir un second nombre entier (le plus petit des deux) : ");
                    string input2 = Console.ReadLine();
                    bool success2 = int.TryParse(input2, out int p);
                    if (success2)
                    {
                        bool success3 = p < n;
                        if (success3)
                        {
                            int result = Premier.PremiersEntreEux(n, p);
                            if (result == 1)
                            {
                                Console.WriteLine("\n\nLe PGCD de " + n + " et " + p + " est : " + result + "\n");
                                Console.WriteLine("\n" + n + " et " + p + " sont donc premiers entre eux.");
                                Console.WriteLine("\n\n\n\n\n\n\n\n");
                            }
                            else
                            {
                                Console.WriteLine("\n\nLe PGCD de " + n + " et " + p + " est : " + result + "\n");
                                Console.WriteLine("\n" + n + " et " + p + " ne sont donc pas premiers entre eux.");
                                Console.WriteLine("\n\n\n\n\n\n\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nVous n'avez pas saisi un nombre plus petit que le precedent !\n\n\n\n\n\n\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");

                }


            }
            else if (userChoice == "D")
            {
                Console.WriteLine("\n\nVeuillez saisir un premier nombre entier : ");
                string input = Console.ReadLine();
                bool success = double.TryParse(input, out double n);

                if (success)
                {
                    List<double> result = Premier.DecompositionFacteursPremiers(n);
                    Console.WriteLine("\n\nLa decomposition de " + n + " en produit de facteurs premiers est : ");
                    Console.Write("{0}", result[0]);
                    foreach (int x in result.Skip(1))
                    {
                        Console.Write("x{0}", x);
                    }
                    Console.WriteLine("\n\n\n\n\n\n\n\n");

                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                }
            }
            else if (userChoice == "E")
            {
                Console.WriteLine("\n\nVeuillez saisir un premier nombre entier : ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int n);

                if (success)
                {
                    int result = Premier.IndicateurEuler(n);
                    Console.WriteLine("\n\nL'indicateur Euler de " + n + " est : " + result);
                    Console.WriteLine("\n\n\n\n\n\n\n\n");

                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                }
            }
            else if (userChoice == "F")
            {
                Console.WriteLine("\n\nVeuillez saisir le nombre entier (sans sa puissance ni son modulo): ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int n);

                if (success)
                {
                    Console.WriteLine("\n\nVeuillez saisir la puissance du nombre entier (son exposant, sans le modulo): ");
                    string inputSecond = Console.ReadLine();
                    bool successSecond = int.TryParse(inputSecond, out int p);

                    if (successSecond)
                    {
                        Console.WriteLine("\n\nVeuillez saisir le modulo : ");
                        string inputThird = Console.ReadLine();
                        bool successThird = int.TryParse(inputThird, out int m);

                        if (successThird)
                        {
                            List<int> resultFirst = Premier.ExponentiationModulaire(p);
                            double resultSecond = Premier.resultExponentationModulaire(resultFirst, m, n);
                            Console.WriteLine("\n\nL'exponentation modulaire de : " + n + " puissance " + p + " modulo " + m + " est : ");
                            Console.Write(n + "x2^{0}", resultFirst.First());
                            foreach (int x in resultFirst.Skip(1))
                            {
                                Console.Write(" + " + n + "x2^{0}", x);
                            }
                            Console.WriteLine("\n\n" + n + "^" + p + " mod " + m + " est égale à : " + resultSecond + " mod " + m);
                            Console.WriteLine("\n\n\n\n\n\n\n\n");

                        }
                        else
                        {
                            Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                }
            }
            else if (userChoice == "G")
            {
                Console.WriteLine("\n\nVeuillez saisir p : ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int p);
                RSA newRSA;
                if (success)
                {
                    Console.WriteLine("\n\nVeuillez saisir q : ");
                    string inputSecond = Console.ReadLine();
                    bool successSecond = int.TryParse(inputSecond, out int q);

                    if (successSecond)
                    {
                        Console.WriteLine("\n\nVeuillez saisir e : ");
                        string inputThird = Console.ReadLine();
                        bool successThird = int.TryParse(inputThird, out int e);

                        if (successThird)
                        {
                            newRSA = new RSA(p, q, e);
                            Console.WriteLine("\n\nLa clef de chiffrement d pour p = " + p + ", q = " + q + " et e = " + e + " est : " + newRSA.d);
                            Console.WriteLine("\n\n\n\n\n\n\n\n");

                        }
                        else
                        {
                            Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                }
            }
            else if (userChoice == "H")
            {
                Console.WriteLine("\n\nVeuillez saisir p : ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int p);
                RSA result;
                if (success)
                {
                    Console.WriteLine("\n\nVeuillez saisir q : ");
                    string inputSecond = Console.ReadLine();
                    bool successSecond = int.TryParse(inputSecond, out int q);

                    if (successSecond)
                    {
                        Console.WriteLine("\n\nVeuillez saisir e : ");
                        string inputThird = Console.ReadLine();
                        bool successThird = int.TryParse(inputThird, out int e);

                        if (successThird)
                        {
                            Console.WriteLine("\n\nVeuillez saisir le message en clair : ");
                            string inputFour = Console.ReadLine();
                            bool successFour = int.TryParse(inputFour, out int messageClair);


                            if (successFour)
                            {
                                result = new RSA(p, q, e);
                                double messageCrypte = result.chiffrement(messageClair);
                                Console.WriteLine("\n\nLa clef de chiffrement d pour p = " + p + ", q = " + q + " et e = " + e + " est : " + result.d);
                                Console.WriteLine("\nLe message" + messageClair + " est maintenant chiffré en : " + messageCrypte);
                                Console.WriteLine("\n\n\n\n\n\n\n\n");
                            }
                            else
                            {
                                Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                }
            }
            else if (userChoice == "I")
            {
                Console.WriteLine("\n\nVeuillez saisir p : ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int p);
                RSA result;
                if (success)
                {
                    Console.WriteLine("\n\nVeuillez saisir q : ");
                    string inputSecond = Console.ReadLine();
                    bool successSecond = int.TryParse(inputSecond, out int q);

                    if (successSecond)
                    {
                        Console.WriteLine("\n\nVeuillez saisir e : ");
                        string inputThird = Console.ReadLine();
                        bool successThird = int.TryParse(inputThird, out int e);

                        if (successThird)
                        {
                            Console.WriteLine("\n\nVeuillez saisir le message chiffré : ");
                            string inputFour = Console.ReadLine();
                            bool successFour = int.TryParse(inputFour, out int messageCrypte);


                            if (successFour)
                            {
                                result = new RSA(p, q, e);
                                double messageClair = result.dechiffrement(messageCrypte);
                                Console.WriteLine("\n\nLa clef de chiffrement d pour p = " + p + ", q = " + q + " et e = " + e + " est : " + result.d);
                                Console.WriteLine("\nLe message " + messageCrypte + " est maintenant déchiffré en : " + messageClair);
                                Console.WriteLine("\n\n\n\n\n\n\n\n");
                            }
                            else
                            {
                                Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                }
            }
            else if (userChoice == "J")
            {
                Console.WriteLine("\n\nVeuillez saisir p : ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int p);
                RSA rsa;
                if (success)
                {
                    Console.WriteLine("\n\nVeuillez saisir q : ");
                    string inputSecond = Console.ReadLine();
                    bool successSecond = int.TryParse(inputSecond, out int q);

                    if (successSecond)
                    {
                        Console.WriteLine("\n\nVeuillez saisir e : ");
                        string inputThird = Console.ReadLine();
                        bool successThird = int.TryParse(inputThird, out int e);

                        if (successThird)
                        {
                            Console.WriteLine("\n\nVeuillez saisir le message chiffré : ");
                            string message = Console.ReadLine();
                            string messageSafe = message.ToUpper().Trim();
                                
                            rsa = new RSA(p, q, e);
                            //rsa = new RSA(47, 71, 79);
                            List<string> result = rsa.wordToNumber(messageSafe);

                            Console.WriteLine("\n\nLe mot " + messageSafe + "  en chiffres est : ");
                            result.ForEach(i => Console.Write("{0}\t", i));

                            List<BigInteger> resultFinal = rsa.cut(result);
                            Console.WriteLine("\n\nLe mot " + messageSafe + " dans sa version finale est : ");
                            resultFinal.ForEach(i => Console.Write("{0}\t", i));
                            Console.WriteLine("\n\n\n\n\n\n\n");
                        }
                        else
                        {
                            Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nVous n'avez pas saisi un nombre\n\n\n\n\n\n\n\n");
             }




            }
        }
    }
}
