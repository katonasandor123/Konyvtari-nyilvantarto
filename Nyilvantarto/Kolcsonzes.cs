using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantarto
{
    class Kolcsonzes
    {
        public int KolcsID { set; get; }
        public int KolcsKonyvID { set; get; }
        public int KolcsOlvasoID { set; get; }
        public string Kolcs1 { set; get; }
        public string Kolcs2 { set; get; }

        public Kolcsonzes(string sor2)
        {
            try
            {
                string[] KolcsIze = sor2.Split(';');
                KolcsID = Convert.ToInt32(KolcsIze[0]);
                KolcsKonyvID = Convert.ToInt32(KolcsIze[1]);
                KolcsOlvasoID = Convert.ToInt32(KolcsIze[2]);
                Kolcs1 = Convert.ToString(KolcsIze[3]);
                Kolcs2 = Convert.ToString(KolcsIze[4]);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
