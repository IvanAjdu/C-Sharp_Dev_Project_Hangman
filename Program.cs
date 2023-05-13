namespace Jeu_Du_Pendu
{
    internal class Program
    {

        static void AfficherMot(string mot, List<char> lettres)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
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


        static void DevinerMot(string mot)
        {
            List<char> lettres = new List<char>();

            while (true)
            {
                AfficherMot(mot, new List<char>(lettres));
                Console.WriteLine();
                char lettre = DemanderUneLettre();
                lettres.Add(lettre);
                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot.");
                }
                else
                {
                    Console.WriteLine("Cette lettre n'est pas dans le mot");
                }

                Console.Write("Lettres testées : ");
                for (int i = 0; i < lettres.Count; i++)
                {
                    Console.Write(lettres[i] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string mot = "ELEPHANT";
            DevinerMot(mot);
        }
    }
}