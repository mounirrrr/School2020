using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    public class Component: Entity
    {
        public string Naam { get; private set; }
        public string Afkorting { get; private set; }
        public Int32 Gewicht { get; private set; }
        internal Component(Int32 id, string naam, Int32 gewicht, string afkorting = "") : base(id)
        {
            Naam = naam;
            Gewicht = gewicht;
            if (afkorting != "")
                Afkorting = afkorting.ToUpper();
            else
            {
                Afkorting = naam.Substring(0, 2).ToUpper();
            }
        }
    }
}
