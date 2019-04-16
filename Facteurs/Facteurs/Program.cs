using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facteurs
{
    class Program
    {
        static bool DiviseurEntier(int Div, int Nb)
            // Renvoie true si Div est un diviseur entier de Nb et false sinon
        {
            int Reste = Nb % Div;
            bool Divise;

            if (Reste == 0) Divise = true;
            else Divise = false;

            return true;
        }

        static void Facteurs(int n)
            // Affiche toutes les décompositions de n en produit de 2 facteurs entiers
        {
            int a, b;
            int i = 0;
            while(i<=n)
            {
                if (DiviseurEntier(i,n))
                {
                    a = n / i;
                    b = i;
                    Console.WriteLine(n + " = " + a + "*" + b);
                }
            }
            i++;
        }

        static void Main(string[] args)
        {
            int Nb;
            string S;
            Console.Write("Entrez le nombre à décomposer: ");
            S = Console.ReadLine();
            int.Parse(S);
            Facteurs(S);
        }
    }
}
