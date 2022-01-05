using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pendulumConsole
{
    internal class AlbumClass
    {
        private string azon;
        private string szerzonev;
        private string cim;
        private string megjel;

        public AlbumClass(string sor)
        {
            var t = sor.Split(';');
            azon = t[0];
            szerzonev = t[1];
            cim = t[2];
            megjel = t[3];
        }
        public string Azon { get => azon; set => azon = value; }
        public string Cim { get => cim; set => cim = value; }
        public string Megjel { get => megjel; set => megjel = value; }
        public string Szerzonev { get => szerzonev; set => szerzonev = value; }
    }
}
