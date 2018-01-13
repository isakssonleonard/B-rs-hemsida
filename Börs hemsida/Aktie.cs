using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Börs_hemsida
{
    public class Aktie
    {
        public string namn { get; set; }
        public double kostar { get; set; }
        public double säljs { get; set; }
        public string aktieslag { get; set; }
        public string börslista { get; set; }

        public Aktie(string namn, double kostar, double säljs, string aktieslag, string börslista)
        {
            this.namn = namn;
            this.kostar = kostar;
            this.säljs = säljs;
            this.aktieslag = aktieslag;
            this.börslista = börslista;
        }
    }
}