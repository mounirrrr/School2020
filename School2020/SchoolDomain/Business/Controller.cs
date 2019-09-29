using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    public class Controller
    {
        /// <summary>
        /// _loaded zorgt er voor dat als we 2 controller-objecten aanmaken,
        /// de vakken van de eerste controller niet verwijderd worden als we de 2de controller aanmaken
        /// zie constructor en methode Load van de VakRepository!
        /// </summary>
        private Boolean _loaded = false;

        public Controller()
        {
            if (!_loaded) {
                VakRepository.Load(Persistence.Controller.GetAlleVakken());
                ComponentRepository.Load(Persistence.Controller.GetAlleComponenten());
                _loaded = true; // slechts 1X load-operatie uitvoeren
            //Wat als we het programma opnieuw opstarten?
            }
        }

        #region Vakken
        public Vak NieuwVak(string naam)
        {
            Int32 _id = VakRepository.GetNextId();
            Vak _vak = new Vak(_id,naam);
            VakRepository.AddItem(_vak);
            //Is dit vak opgeslagen in de database
            Persistence.Controller.AddVak(_vak);
            return _vak;
        }

        public List<Vak> GetAlleVakken()
        {
            return VakRepository.Items;
        }

        public Vak ZoekVak(string naam)
        {
            //Is er werk in de database?
            return VakRepository.FindItem(naam);
        }
        #endregion

        #region Component
        public Component MaakComponent(string naam, Int32 gewicht, string afkorting = "")
        {
            Int32 cId = ComponentRepository.GetNextId();
            Component c = new Component(cId, naam, gewicht, afkorting);
            ComponentRepository.AddItem(c);
            return c;
        }

        public List<Component> GetComponents()
        {
            return ComponentRepository.Items;
        }
        #endregion

        #region Evaluatie
        public Evaluatie NieuweEvaluatie(Int32 vakId, string titel, double behaald, double maximum, Int32 componentId)
        {
            Vak _vak = VakRepository.GetItem(vakId);
            Evaluatie _ev = _vak.NieuweEvaluatie(titel, behaald, maximum, componentId);
            return _ev;
            //Is er werk in de database?
        }

        public List<Evaluatie> GetAlleEvaluaties(Int32 vakId)
        {
            Vak _vak = VakRepository.GetItem(vakId);
            return _vak.Evaluaties;
        }
        #endregion
    }
}
