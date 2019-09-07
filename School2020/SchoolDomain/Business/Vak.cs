using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    public class Vak: Entity
    {
        public String Naam { get; internal set; }

        internal Vak( Int32 id, String naam): base(id)
        {
            Naam = naam;
        }

        public override string ToString()
        {
            return Naam + ": resultaat onbekend";
        }
    }
}
