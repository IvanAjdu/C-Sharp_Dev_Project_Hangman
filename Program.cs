using AsciiArt;

namespace Jeu_Du_Pendu
{
    internal class Program
    {

        static void AfficherMot(string mot, List<char> lettresDevinees)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettresDevinees.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else
                {
                    Console.Write("_ ");
                }

            }
            Console.WriteLine();
        }

        static char DemanderUneLettre()
        {
            while (true)
            {
                Console.Write("Choisisez une lettre : ");
                string reponse = Console.ReadLine();
                if (reponse.Length == 1)
                {
                    reponse = reponse.ToUpper();

                    return reponse[0];
                }
                else
                {
                    Console.WriteLine("Veuillez saisir une lettre");

                }
                Console.WriteLine();
            }
        }

        static bool winCondition(string mot, List<char> lettres)
        {
            foreach (var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }

            if (mot.Length == 0)
            {
                return true;
            }
            return false;
        }

        static void DevinerMot(string mot)
        {
            List<char> lettres = new List<char>();
            List<char> lettresDevinees = new List<char>();
            List<char> lettreTestees = new List<char>();
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;


            while (viesRestantes>0)
            {
                int penduShow = 6 - viesRestantes;
                Console.WriteLine(Ascii.PENDU[penduShow]);
                Console.WriteLine();
                AfficherMot(mot, new List<char>(lettres));
                Console.WriteLine();
                char lettre = DemanderUneLettre();
                lettres.Add(lettre);

                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot.");
                    lettresDevinees.Add(lettre);
                    if (winCondition(mot, lettres))
                    {
                        break;
                    }
                }
                else
                {
                    lettreTestees.Add(lettre);
                    viesRestantes--;
                    Console.WriteLine("Cette lettre n'est pas dans le mot.");
                    Console.WriteLine("Il vous reste " + viesRestantes + " essais.");
                }

                Console.WriteLine();
                if (lettreTestees.Count > 0)
                {
                    Console.Write("Autre(s) Lettre(s) : " + string.Join(", ", lettreTestees));
                    Console.WriteLine();
                }
            }

            if (viesRestantes == 0)
            {
                Console.WriteLine(Ascii.PENDU[6]);
                Console.WriteLine();
                Console.WriteLine("Vous n'avez plus d'essais disponibles, vous avez perdu !");
                Console.WriteLine("Le bon mot était " + mot + ".");
            }
            else 
            {
                Console.WriteLine("Félicitations ! Vous avez trouvé le mot en entier !");
                Console.WriteLine("Le mot était " + mot + ".");
            }

        }

        static void Main(string[] args)
        {
            string mot = "ELEPHANT";
            DevinerMot(mot);
        }
    }
}