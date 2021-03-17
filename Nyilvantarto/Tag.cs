using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantarto
{
    class Tag
    {
        public int TID { set; get; }
        public string Nev { set; get; }
        public string Datum { set; get; }

        public Tag(string sor3)
        {
            try
            {
                string[] TagIze = sor3.Split(';');
                TID = Convert.ToInt32(TagIze[0]);
                Nev = Convert.ToString(TagIze[1]);
                Datum = Convert.ToString(TagIze[2]);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
