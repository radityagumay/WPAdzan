using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpadzan.Models
{
    public class AdzanModel
    {
        private List<Adzan> adzan;
        public List<Adzan> Adzan
        {
            get { return adzan; }
            set { adzan = value; }
        }
    }

    public class Adzan
    {
        private string date;
        private string imsyak;
        private string shubuh;
        private string terbit;
        private string dzuhur;
        private string ashr;
        private string maghrib;
        private string isya;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Imsyak
        {
            get { return imsyak; }
            set { imsyak = value; }
        }
        public string Shubuh
        {
            get { return shubuh; }
            set { shubuh = value; }
        }
        public string Terbit
        {
            get { return terbit; }
            set { terbit = value; }
        }
        public string Dzuhur
        {
            get { return dzuhur; }
            set { dzuhur = value; }
        }
        public string Ashr
        {
            get { return ashr; }
            set { ashr = value; }
        }

        public string Maghrib
        {
            get { return maghrib; }
            set { maghrib = value; }
        }

        public string Isya
        {
            get { return isya; }
            set { isya = value; }
        }
    }
}
