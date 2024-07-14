using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_resz
{
    class Program
    {
        static List<string> AngolKarakterek = new List<string>
        { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
          "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };

        static string Rejtjelezo(string r_Uzenet, string r_Kulcs, List<string> AngolKarakterek)
        {
            string Rejt_Uzenet = "";
            int UzenetR_, KulcsR_;

            for (int i = 0; i < r_Uzenet.Length; i++)
            {
                UzenetR_ = AngolKarakterek.IndexOf(r_Uzenet[i].ToString());
                KulcsR_ = AngolKarakterek.IndexOf(r_Kulcs[i].ToString());

                if (UzenetR_ == -1)
                {
                    throw new ArgumentException("Az üzenet az angol abc szerinti kisbetűkből (a-z) és szóközből (' ') állhat!"); //(ToLower)
                }

                if (KulcsR_ == -1)
                {
                    throw new ArgumentException("A kulcsnak legalább akkorának kell lennie mint az üzenetnek!");
                }

                int R_Osszesitve = (UzenetR_ + KulcsR_) % 27;
                Rejt_Uzenet += AngolKarakterek[R_Osszesitve];
            }

            return Rejt_Uzenet;
        }

        static string RejtjelezoMegoldas(string m_RejtjelezettUzenet, string m_Kulcs, List<string> AngolKarakterek)
        {
            string EredetiUzenet = "";
            int R_Kod, KulcsM_;

            for (int j = 0; j < m_RejtjelezettUzenet.Length; j++)
            {
                R_Kod = AngolKarakterek.IndexOf(m_RejtjelezettUzenet[j].ToString());
                KulcsM_ = AngolKarakterek.IndexOf(m_Kulcs[j].ToString());

                if (R_Kod == -1)
                {
                    throw new ArgumentException("A rejtjelezett üzenet az angol abc szerinti kisbetűkből (a-z) és szóközből (' ') állhat!");
                }

                if (KulcsM_ == -1)
                {
                    throw new ArgumentException("A kulcsnak legalább akkorának kell lennie mint az üzenetnek!");
                }

                int M_Osszesitve = (R_Kod - KulcsM_ + 27) % 27;
                EredetiUzenet += AngolKarakterek[M_Osszesitve];
            }

            return EredetiUzenet;
        }

        static void Main(string[] args)
        {
            List<string> AngolKarakterek = new List<string>
            { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
              "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };

            Console.Write("Adja meg a kívánt üzenetet: "); // helloworld
            string Uzenet = Console.ReadLine().ToLower();

            Console.Write("Adja meg a kulcsot hozzá: "); // abcdefgijkl
            string Kulcs = Console.ReadLine().ToLower();

            string rejtjelzettuzenet = Rejtjelezo(Uzenet, Kulcs, AngolKarakterek);
            Console.WriteLine("A rejtjelezett üzenet: " + rejtjelzettuzenet + "\n"); //hfnosauzun

            Console.Write("Adja meg a rejtjelezett üzenetet:");
            string Uzenetujra = Console.ReadLine().ToLower();

            Console.Write("Adja meg a rejtjelezett üzenet kulcsát:");
            string KulcsUjra = Console.ReadLine().ToLower();

            string rejtjelzetfejtett = RejtjelezoMegoldas(Uzenetujra, KulcsUjra, AngolKarakterek);
            Console.WriteLine("A rejtjelezett üzenet megfejtve: " + rejtjelzetfejtett);

            Console.ReadKey();
        }
    }
}
