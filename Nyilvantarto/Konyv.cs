using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantarto
{
    class Konyv
    {
        public int ID { set; get; }
        public string Szerzo { set; get; }
        public string Cim { set; get; }
        public int KiadasEv { set; get; }
        public string Kiado { set; get; }
        public bool Kolcsonzes { set; get; }

        public Konyv(string sor1)
        {
            try
            {
                string[] KonyvIze = sor1.Split(';');
                ID = Convert.ToInt32(KonyvIze[0]);
                Szerzo = Convert.ToString(KonyvIze[1]);
                Cim = Convert.ToString(KonyvIze[2]);
                KiadasEv = Convert.ToInt32(KonyvIze[3]);
                Kiado = Convert.ToString(KonyvIze[4]);
                Kolcsonzes = Convert.ToBoolean(KonyvIze[5]);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
