using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    public class Evaluatie
    {
        public String Titel { get; internal set; }
        public Double Behaald { get; internal set; }
        public Double Maximum { get; internal set; }
        public Int32 ComponentId { get; internal set; }

        public Component Component
        {
            get
            {
                return ComponentRepository.GetItem(ComponentId);
            }
        }

        internal Evaluatie(String titel, Double behaald, Double maximum, Int32 componentId)
        {
            Titel = titel;
            Behaald = behaald;
            Maximum = maximum;
            ComponentId = componentId;
        }

    }
}
