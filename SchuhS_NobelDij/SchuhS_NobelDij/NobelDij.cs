using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_NobelDij
{
    class NobelDij
    {
        //év;típus;keresztnév;vezetéknév
        public int Ev;
        public string Tipus;
        public string Keresztnev;
        public string Vezeteknev;
        public string Nev;

        public NobelDij(string sor)
        {
            var dbok = sor.Split(';');
            this.Ev = int.Parse(dbok[0]);
            this.Tipus = dbok[1];
            this.Keresztnev = dbok[2];
            this.Vezeteknev = dbok[3];
            this.Nev = dbok[2] + " " + dbok[3];
        }

    }
}
