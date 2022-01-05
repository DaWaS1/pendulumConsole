using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pendulumConsole
{
    internal class TrackClass
    {
        private string cim;
        private TimeSpan hossz;
        private string azon;
        private string url;

        public TrackClass(string sor)
        {
            var t = sor.Split(';');
            cim = t[0];
            hossz = TimeSpan.Parse(t[1]);
            azon = t[2];
            url = t[3];
        }
        public string Cim { get => cim; set => cim = value; }
        public TimeSpan Hossz { get => hossz; set => hossz = value; }
        public string Azon { get => azon; set => azon = value; }
        public string Url { get => url; set => url = value; }
    }
}
