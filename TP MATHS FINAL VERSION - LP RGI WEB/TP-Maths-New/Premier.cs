using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Maths_TP1
{
    public static class Premier
    {
        public static List<double> NombrePremier(double n)
        {
            // on racine carre le n et on l'arrondi a l'entier du dessous
            double numberSqrt = (double)Math.Floor(Math.Sqrt(n));

            //on genere tous les nombres entier de 2 a n-1 (car on commence a 2 et non 1)
            List<double> nombresNonPremiers = new List<double>();
            List<double> nombresNonPremiersTotal = new List<double>();
            List<double> nombresPremiers;
            int nToInt = Convert.ToInt32(n);
            List<int> range = Enumerable.Range(2, nToInt - 1).ToList();
            List<double> rangeDouble = new List<double>();
            range.ForEach(x => rangeDouble.Add(x));

            // on commence a boucler pour pouvoir diviser tout les nombres par 2 jusqu'au nombre entré. On verifie de tester les divisions uniquement jusqu'a la partie entiere de la racine carré du nombre entier.
            for (int i = 2; i <= numberSqrt; i++)
            {

                // on boucle donc ici sur chaque nombre entier jusqu'au nombre entier entré
                for (int u = i; u <= n; u++)
                {
                    // on verifie que le diviseur est different que le nombre sur lequel on fait le test et que le resultat du modulo de ces deux nombres est bien different de 0 pour eliminer les nombre non premiers.
                    if (u != i && u % i == 0)
                    {
                        nombresNonPremiers.Add(u);
                    }

                    // les nombres non premiers filtrés par le premier diviseur on etait mis dans une liste (juste au dessus). Une fois avoir tester tout les nombres pour le meme diviseur on ajoute la nouvelle liste de nombre non premiers a ceux reperer precedemment (avec un autre diviseur)
                    nombresNonPremiersTotal = nombresNonPremiersTotal.Union(nombresNonPremiers).ToList();
                }

            }

            // on initialise une variable contenant tout les nombre jusqu'au nombre saisi exceptés ceux repérer comme non premiers de facon a obtenir uniquement les nombres premiers.
            nombresPremiers = rangeDouble.Except(nombresNonPremiers).ToList();

            // on trie ces nombres pour qu'il se remettent dans l'ordre croissant
            nombresPremiers.Sort();

            // on retourne le resultat
            return nombresPremiers;

        }

        public static List<int> NombrePremier2(int n, int p)
        {
            // on racine carre le n et on l'arrondi a l'entier du dessous
            int numberSqrt = (int)Math.Floor(Math.Sqrt(p));

            //on genere tous les nombres entier de 2 a n-1 (car on commence a 2 et non 1)
            List<int> range = Enumerable.Range(2, p - 1).ToList();
            List<int> nombresNonPremiers = new List<int>();
            List<int> nombresNonPremiersTotal = new List<int>();
            List<int> nombresPremiers;

            // on commence a boucler pour pouvoir diviser tout les nombres par 2 jusqu'au nombre entré. On verifie de tester les divisions uniquement jusqu'a la partie entiere de la racine carré du nombre entier.
            for (int i = 2; i <= numberSqrt; i++)
            {

                // on boucle donc ici sur chaque nombre entier jusqu'au nombre entier entré
                for (int u = i; u <= p; u++)
                {
                    // on verifie que le diviseur est different que le nombre sur lequel on fait le test et que le resultat du modulo de ces deux nombres est bien different de 0 pour eliminer les nombre non premiers.
                    if (u != i && u % i == 0)
                    {
                        nombresNonPremiers.Add(u);
                    }

                    // les nombres non premiers filtrés par le premier diviseur on etait mis dans une liste (juste au dessus). Une fois avoir tester tout les nombres pour le meme diviseur on ajoute la nouvelle liste de nombre non premiers a ceux reperer precedemment (avec un autre diviseur)
                    nombresNonPremiersTotal = nombresNonPremiersTotal.Union(nombresNonPremiers).ToList();
                }

            }

            // on initialise une variable contenant tout les nombre jusqu'au nombre saisi exceptés ceux repérer comme non premiers de facon a obtenir uniquement les nombres premiers.
            nombresPremiers = range.Except(nombresNonPremiers).ToList();

            // on ne garde que les nombres entier situés entre les 2 valeurs choisi plus tot.
            nombresPremiers.RemoveAll(i => i < n);

            // on trie ces nombres pour qu'il se remettent dans l'ordre croissant
            nombresPremiers.Sort();

            // on retourne le resultat
            return nombresPremiers;

        }

        public static int PremiersEntreEux(int n, int p)
        {
/*          1) On effectue la division euclidienne du plus grand des deux nombres par le plus petit.
            2) On effectue la division euclidienne du diviseur par le reste de la division précédente, jusqu’à ce que le reste de la division soit égal à zéro.
            3) Le PGCD est le dernier reste non nul dans la succession des divisions euclidiennes.*/

            while (n % p > 0)
            {
                int reste = n % p;
                if (reste > 0)
                {
                    n = p;
                    p = reste;
                }
                else if (reste == 0)
                {
                    return p;

                }
            }
            return p;
        }

        public static List<double> DecompositionFacteursPremiers(double n)
        {
            List<double> NombrePremiers = NombrePremier(n);
            List<double> FacteursPremiers = new List<double>();
            double NbNombrePremiers = NombrePremiers.Count;


            for (int i = 0; i < NbNombrePremiers & n != 0;)
            {
                double result = n / NombrePremiers[i];
                if (result % 1 == 0)
                {
                    FacteursPremiers.Add(NombrePremiers[i]);
                    n = result;
                }
                else
                {
                    i++;
                }
            }

            return FacteursPremiers;
        }

        public static int IndicateurEuler(int n)
        {
            List<int> nbPremiersEntreEux = new List<int>();

            for (int i=1; i <= n; i++)
            {
                if(PremiersEntreEux(n,i) == 1)
                {
                    nbPremiersEntreEux.Add(i);
                }
            }
            int result = nbPremiersEntreEux.Count();
            return result;
        }

        public static List<int> ExponentiationModulaire(int p)
        {
            //List<string> listBloc3 = new List<string>(); 
            List<int> puissances = new List<int>();
            string pString = Convert.ToString(p);
            //int blocSize = 3;

            //boucle qui permet de couper de couper par block de 3 le nombre entrer en parametre de la fonction ExponentationModulaire() et de les ajouter dans la liste listBloc3
           /* for (var i = 0; i < pString.Length; i += blocSize)
            { 
                listBloc3.Add(pString.Substring(i, Math.Min(blocSize, pString.Length - i)));
            }*/

            //pour chaque string representant un bloc de 3 chiffres dans la liste listBloc3
            //foreach (string bloc3 in listBloc3)
            //{
                int intBloc3 = Convert.ToInt32(pString);

                //On obtient dans cette variable la version en base 2 du nombre intBloc3
                string bloc3Base2 = Convert.ToString(intBloc3, 2);

                string reverse = "";
                int Length = bloc3Base2.Length - 1;

                //on inverse l'ordre de bloc3Base2 car necessaire pour nos calculs (ex : 10111 devient 11101) On commence donc de la fin, et on decremente pour retranscrir le nombre a l'envers
                //on en profite pour mettre un point entre chaque valeur de facon a ce que la string soit facilement decomposable par la suite
                while (Length >= 0)
                {
                    reverse += bloc3Base2[Length] + ".";
                    Length--;
                }

                //cette ligne permet de supprimer le dernier "." (ex: 1.0.1.1. devient 1.0.1.1)
                reverse = reverse.Remove(reverse.Length - 1, 1);

                //on separe chaque valeur en fonction des points dans la string, on obtient donc un tableau de string comme ca : [0,1,1,0,1,1] sur lequel on pourra boucler.
                string[] subs = reverse.Split('.');

                //pour chaque chiffre (0 ou 1) on 
                int compteurPuissance = 0;
                for (int compteurSubs = 0; compteurSubs < subs.Length; compteurSubs++)
                {
                    //on convertit chaque string (1 ou 0) en int
                    int subInt = int.Parse(subs[compteurSubs]);
                    
                    //on ajoute a la liste puissance le resultat du calcul suivant : (1 ou 0) x 2 puissance (1 puis 2 puis 2 puis... en fonction de leur place dans le tableau) (formule du cours, et x2 car base binaire)  
                    puissances.Add((int)(subInt * Math.Pow(2, compteurPuissance)));

                    //on incremente pour avoir a chaque fois une puissance superieur (la puissance correspond au rend du nombre dans le tableau)
                    compteurPuissance++;

                    
                }
            //}
            return puissances;
        }

        public static double resultExponentationModulaire(List<int> puissances, int modulo, double messageCrypte)
        {
           
            //liste contenant le resultat de "n" a chaque "puissance binaire" cad puissance 1, 2, 4, 8, 16 jusqu'a 1024 mais modulo "m" ex : 9^16 = 31 mod 55 si "n" = 9 et m = "55"
            List<double> resultPuissances = new List<double>();

            //equivaut à ajouter messageCrypte^1
            resultPuissances.Add(messageCrypte % modulo);


            // fait les multiplications pr chaque puissance cad par ex 79x79 = 6241 = 3021 mod 3220 puis 3021*3021 = 9126441 = 961 mod 3220 et ainsi de suite (dans le tableau il y a donc 3021, 961..)
            for (int i = 1; i < 12; i++)
            {
                resultPuissances.Add((resultPuissances[i-1] * resultPuissances[i-1]) % modulo);   
            }

            double result = 1;
            int r = 0;


            // parmis les sommes trouvées juste avant, on prend celle qui nous interesse uniquemement
            for (int y=0; y < puissances.Count; y++)
            {
                if (puissances[y] != 0)
                {
                    result *= resultPuissances[r];
                    result %= modulo;
                }    
                r++;
            }

            return result;
        }
    }
}
