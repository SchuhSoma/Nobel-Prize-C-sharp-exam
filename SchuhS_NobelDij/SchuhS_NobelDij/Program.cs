using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_NobelDij
{
    class Program
    {
        static List<NobelDij> NobelDijList;
        static List<string> TipusList;
        static Dictionary<string, int> NobelStatisztika;
        static List<int> EvekList;
        static void Main(string[] args)
        {
            Feladat2AdatokBeolvasasa(); Console.WriteLine("\n------------------------------\n");
            Feladat3MilyenNobelDij(); Console.WriteLine("\n------------------------------\n");
            Feladat42017IrodalmiNobel(); Console.WriteLine("\n------------------------------\n");
            Feladat5BekeNobel(); Console.WriteLine("\n------------------------------\n");
            Feladat6Curie(); Console.WriteLine("\n------------------------------\n");
            Feladat7Statisztika(); Console.WriteLine("\n------------------------------\n");
            Feladat8Orvosi(); Console.WriteLine("\n------------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat8Orvosi()
        {
            Console.WriteLine("8.Feladat: Orvosi Nobel-díjak adatai kiirtva txt-be");
            var sw = new StreamWriter(@"orvosi.txt", false, Encoding.UTF8);
            EvekList = new List<int>();
            foreach (var n in NobelDijList)
            {
                if(!EvekList.Contains(n.Ev))
                {
                    EvekList.Add(n.Ev);
                }
            }
            EvekList.Sort();
            //EvekList.Reverse();
            foreach (var e in EvekList) 
            {
                foreach (var n in NobelDijList)
                {
                    if (n.Tipus == "orvosi" && n.Ev==e)
                    {
                        Console.WriteLine("\t{0}:{1}", n.Ev, n.Nev);
                        sw.WriteLine("{0}:{1}", n.Ev, n.Nev);
                    }
                }
                
            }
            sw.Close();
        }

        private static void Feladat7Statisztika()
        {
            Console.WriteLine("7.Feladat: határozza meg, melyik Nóbel-díjból hány darabot osztottak ki");
            TipusList = new List<string>();
            NobelStatisztika = new Dictionary<string, int>();
            foreach (var n in NobelDijList)
            {
                if(!TipusList.Contains(n.Tipus))
                {
                    TipusList.Add(n.Tipus);
                }
            }
            
            foreach (var t in TipusList) 
            {
                int db = 0;
                foreach (var n in NobelDijList)
                {                    
                    if (t==n.Tipus)
                    {
                        db++;
                        
                    }
                }
                if (!NobelStatisztika.ContainsKey(t))
                {
                    NobelStatisztika.Add(t, db);
                }
            }
            foreach (var ns in NobelStatisztika)
            {
                Console.WriteLine("\t{0,-15} : {1} db",ns.Key, ns.Value);
            }
        }

        private static void Feladat6Curie()
        {
            Console.WriteLine("6.Feladat: Határozza meg, hogy a Curie család mely tagjai kaptak Nobel-díjat");
            foreach (var n in NobelDijList)
            {
                if(n.Vezeteknev.ToLower().Contains("curie"))
                {
                    Console.WriteLine("\t{0} év : {1,-35} : {2}",n.Ev, n.Nev,n.Tipus);
                }
            }
        }

        private static void Feladat5BekeNobel()
        {
            Console.WriteLine("5.Feladat: Mely szervezetek kaptak napjainkig Béke Nobel-díjat");
            foreach (var n in NobelDijList)
            {
                if(n.Ev>=1990 && n.Tipus=="béke" && n.Nev.ToLower().Contains('(') 
                    || n.Ev >= 1990 && n.Tipus == "béke" && n.Nev.ToLower().Contains("co")
                    || n.Ev >= 1990 && n.Tipus == "béke" && n.Nev.ToLower().Contains("nati") 
                    || n.Ev >= 1990 && n.Tipus == "béke" && n.Nev.ToLower().Contains("med"))
                {
                    Console.WriteLine("{0} Béke Nobel-díjat kapott : {1} ",n.Ev, n.Nev);
                }
            }
        }

        private static void Feladat42017IrodalmiNobel()
        {
            Console.WriteLine("4.Feladat: ki kapott 2017-ben irodalmi Nobel-díjat");
            foreach (var n in NobelDijList)
            {
                if(n.Ev==2017 && n.Tipus.ToLower()=="irodalmi")
                {
                    Console.WriteLine("\tA 2017-es irodalmi Nobel-díjat: {0} kapta",n.Nev);
                }
            }
        }

        private static void Feladat3MilyenNobelDij()
        {
            Console.WriteLine("3.Feladat: Határozza meg milyen Nobel-díjat kapott Arthur B. McDonald");
            int szamlalo = 0;
            string kulcsszo = "Arthur B. McDonald";
            while(szamlalo<NobelDijList.Count && kulcsszo!=NobelDijList[szamlalo].Nev)
            {
                szamlalo++;
            }
            if(szamlalo==NobelDijList.Count)
            {
                Console.WriteLine("\tSajnos nincs ilyen személy a listában");
            }
            else
            {
                Console.WriteLine("\t{0} -> {1} Nobel-díjat kapott",kulcsszo, NobelDijList[szamlalo].Tipus);
            }
        }

        private static void Feladat2AdatokBeolvasasa()
        {
            Console.WriteLine("2.Feladat: Adatok beolvasása");
            var sr = new StreamReader(@"nobel.csv", Encoding.UTF8);
            NobelDijList = new List<NobelDij>();
            int db = 0;
            while(!sr.EndOfStream)
            {
                db++;
                NobelDijList.Add(new NobelDij(sr.ReadLine()));
            }
            sr.Close();
            if(0<db)
            {
                Console.WriteLine("\tSikeres beolvasás, {0} sor beolvasva", db);
            }
            else
            {
                Console.WriteLine("\tSikeretelen beolvasás próbálja újra.");
            }
        }
    }
}
