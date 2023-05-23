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

            Console.WriteLine(mot);

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
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;

            while (viesRestantes>0)
            {
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
                    Console.WriteLine("Cette lettre n'est pas dans le mot");
                    viesRestantes--;
                    Console.WriteLine("Il vous reste " + viesRestantes + " essais.");
                }

                Console.WriteLine();
                Console.Write("Lettres testées : ");
                for (int i = 0; i < lettres.Count; i++)
                {
                    Console.Write(lettres[i] + " ");
                }
                Console.WriteLine();
            }

            if (viesRestantes == 0)
            {
                Console.WriteLine("Vous n'avez plus d'essais disponibles, vous avez perdu !");
                Console.WriteLine("Le bon mot était " + mot + ".");
            }
            else { Console.WriteLine("Félicitations ! Vous avez trouvé le mot !"); }
        }

        static void Main(string[] args)
        {
            string mot = "ELEPHANT";
            DevinerMot(mot);
        }
    }
}