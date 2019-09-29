using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    public class Vak : Entity
    {
        /// <summary>
        /// compositie: evaluaties behoren tot het vak. Daarom: declaratie IN het vak-object zelf!
        /// </summary>
        /// <remarks>
        /// De _evaluaties horen bij het object en niet bij de klasse. Waarom niet?
        /// </remarks>
        private List<Evaluatie> _evaluaties;

        public String Naam { get; internal set; }

        /// <summary>
        /// Eigenschap bij veld _evaluaties
        /// </summary>
        /// <remarks>Kan ook met {get; private set;}</remarks>
        public List<Evaluatie> Evaluaties
        {
            get
            {
                return _evaluaties;
            }
            private set
            {
                _evaluaties = value;
            }
        }

        /// <summary>
        /// Constructor Vak
        /// </summary>
        /// <param name="id">id van het vak</param>
        /// <param name="naam">naam van het vak</param>
        /// <remarks>Initialiseer voor een nieuw vak de lijst met evaluaties: nog geen evaluaties</remarks>
        internal Vak(Int32 id, String naam) : base(id)
        {
            Naam = naam;
            //Een lege lijst is niet hezelfde als null
            Evaluaties = new List<Evaluatie>();
        }

        public double Resultaat { get { return VakResultaat(); } }

        /// <summary>
        /// Bereken het GEWOGEN resultaat van de evaluaties bij dit vak
        /// </summary>
        /// <returns>het behaalde percentage voor dit vak</returns>
        private double VakResultaat()
        {
            double totaalBehaald = 0, totaalMaximum = 0;
            foreach (Evaluatie ev in Evaluaties)
            {
                totaalBehaald += ev.Behaald * ev.Component.Gewicht / 100;
                totaalMaximum += ev.Maximum * ev.Component.Gewicht / 100;
            }
            return Math.Round(totaalBehaald / totaalMaximum * 100, 2);
        }

        /// <summary>
        /// Voeg een nieuwe evaluatie toe aan dit vak
        /// </summary>
        /// <param name="titel">titel</param>
        /// <param name="behaald">behaald</param>
        /// <param name="maximum">maximum</param>
        /// <returns>het goedgekeurd evaluatie-object</returns>
        /// <exception cref="ArgumentException">Controle van de ingevoerde waarden</exception>
        internal Evaluatie NieuweEvaluatie(string titel, double behaald, double maximum, Int32 componentId)
        {
            if (behaald < 0 || maximum < 0)
                throw new ArgumentException("Punten mogen niet negatief zijn voor " + titel);
            else if (behaald > maximum)
                throw new ArgumentException("Te hoge punten voor evaluatie " + titel);
            Evaluatie evaluatie = new Evaluatie(titel, behaald, maximum, componentId);
            Evaluaties.Add(evaluatie);
            return evaluatie;
        }

        /// <summary>
        /// Verwijder de evaluatie met de opgegeven titel
        /// </summary>
        /// <param name="titel"></param>
        internal void DeleteEvaluatie(string titel)
        {
            Evaluatie evaluatie = Evaluaties.Find(e => e.Titel == titel);
            Evaluaties.Remove(evaluatie);
        }

        /// <summary>
        /// Wijzig de evaluatie met de opgegeven titel
        /// </summary>
        /// <param name="titel">titel van de te wijzigen evaluatie</param>
        /// <param name="behaald">aangepaste behaalde punten</param>
        /// <param name="maximum">aangepast maximum</param>
        internal void WijzigEvaluatie(string titel, double behaald, double maximum, Int32 componentId)
        {
            Evaluatie evaluatie = Evaluaties.Find(e => e.Titel == titel);
            if (!(evaluatie == null))
            {
                evaluatie.Maximum = maximum;
                evaluatie.Behaald = behaald;
                evaluatie.ComponentId = componentId;
            }
        }

        /// <summary>
        /// Het is mogelijk om de evaluaties in te laden
        /// </summary>
        /// <param name="evaluaties">een lijst met evaluaties</param>
        internal void Load(List<Evaluatie> evaluaties)
        {
            Evaluaties = evaluaties;
        }

        public override string ToString()
        {
            return Naam + ": " + Resultaat + "%";
        }
    }
}
