using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    class Program
    {
        static int[,] ChargerGrille(int Nb)
        // Charge la grille précalculée n° Nb (où Nb est un nombre entre 1 et 20) et renvoie cette grille sous la forme d'un tableau de 9*9 entiers
        {
            string FileName = @"..\..\..\Grilles\Grille";
            if (Nb < 10) FileName += "0";
            FileName += Nb;
            int[,] Tab = new int[9, 9];

            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    string line = sr.ReadLine();
                    string[] TabString = line.Split(' ');

                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            Tab[i, j] = int.Parse(TabString[i * 9 + j]);
                    return Tab;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        static bool ChiffreValide (int a)
        {
 // TODO : Virer le boléen, returner false ou true directement  DONE

            if (a > 0 || a < 9)
            {
                return true;
            }
            return false;
        }
        static void Afficher (int [,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i,j] + " ");
                }
                Console.WriteLine(" ");
            }
        }
        static void TraduireCoordonnees (int bloc, out int ligne, out int colonne)
        {
            ligne = 3 * (bloc / 3);
            colonne = (bloc % 3) * 3;
        }
// TODO : Ligne, 0, 3, 6 puis col 0, 3, 6 ? Probablement un moyen de les grouper par 3 facilement, 0, 3, 6 se répète toujours, optimisation possible, réfléchir à un meilleur algo
        static List<int> LigneVersListe(int [,] tab, int ligne)
        {
            List<int> LigneListe = new List<int>();

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                LigneListe.Add(tab[ligne, i]);
            }
            return LigneListe;
        }
        static List<int> ColonneVersListe(int [,] tab, int colonne)
        {
            List<int> ColonneListe = new List<int>();

            for (int j = 0; j < tab.GetLength(1); j++)
            {
                ColonneListe.Add(tab[j, colonne]);
            }
            return ColonneListe;
        }
        static List<int> BlocVersListe(int [,] tab, int bloc)
        {
            List<int> BlocListe = new List<int>();
            TraduireCoordonnees(bloc, out int ligne, out int colonne);
            int ligneTab = ligne;
            int colonneTab = colonne;
            for (int i = ligneTab; i < ligneTab+3; i++)
            {
                for (int j = colonneTab; j < colonneTab+3; j++)
                {
                    BlocListe.Add(tab[i, j]);   
                }
            }
            return BlocListe;
        }
        static bool ListeCorrecte (List<int> listeRecue)
        {

// TODO : Refactorer en virant ATester (tu peux return true / false directement) > DONE
            int ValeurCorrect = 45;

            if (listeRecue.Count == 9 && listeRecue.Sum() == ValeurCorrect)
            {
                return true;
            }
            return false;
        }
        static bool VerifierGrille(int [,] tab)
        {
            bool GrilleOk = true;
            int compteur = 0;
            int bloc = 0;

            while (compteur < 9 && GrilleOk == true)
            {
                GrilleOk = ListeCorrecte(BlocVersListe(tab, bloc));
// TODO : if (!GrilleOk) à tester DONE
                if (!GrilleOk)
                {
                    break;
                }
                bloc++;
                compteur++;
            }
            Console.WriteLine(GrilleOk);
            return GrilleOk;
        }
        static void Main(string[] args)
        {
            // Exemple
            int[,] Grille = ChargerGrille(3);

            // 5 : ChiffreValide
            int NbreChoix = 3;
            bool correct = ChiffreValide(NbreChoix);

            // 6 : Afficher
            Afficher(Grille);

            // 7 : TraduireCoordonnees 
            int bloc = 0;
            int ligne, colonne;
            TraduireCoordonnees(bloc, out ligne, out colonne);
            Console.WriteLine(ligne);
            Console.WriteLine(colonne);

            // 8 : LigneVersListe
            int ligneListe = 3;
            List<int> ListeLigne = LigneVersListe(Grille, ligneListe);

            // 9 : ColonneVersListe
            int colonneListe = 6;
            List<int> ListeColonne = ColonneVersListe(Grille, colonneListe);

            // 10 : BlocVersListe
            List<int> ResultBloc = BlocVersListe(Grille, bloc);

            // 11 : ListeCorrecte 
            bool ResultListe = ListeCorrecte(ResultBloc);

            // 12 : VerifierGrille
            bool ResultGrille = VerifierGrille(Grille);

            // 13 : Vérifier toutes les grilles 1 à 20
            // TODO : Boucles à faire ici > DONE.
            // Grilles correctes 

            int NbreTest = 0;
            while (NbreTest <=20)
            {
                ResultGrille = VerifierGrille(Grille = ChargerGrille(NbreTest));
            }
        }
    }
}
