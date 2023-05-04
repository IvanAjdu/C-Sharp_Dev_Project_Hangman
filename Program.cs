namespace Jeu_Du_Pendu
{
    internal class Program
    {

        static void AfficherMot(string mot, List<char> lettres)
        {
            // _ _ _ _ _ _ _ _ 
            for (int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else { Console.Write("_ "); }
            }
            Console.WriteLine();
        }

        /*static void DevinerMot(string mot)
        {
            /// _ _ _ _ _ _ _ _
            /// E _ E _ _ _ _ _
            AfficherMot(mot);
            // DemanderLettre();
        }*/


        static void Main(string[] args)
        {
            string mot = "ELEPHANT";

            //DevinerMot(mot);
            AfficherMot(mot, new List<char> { 'E', 'L', 'A'});
        }
    }
}