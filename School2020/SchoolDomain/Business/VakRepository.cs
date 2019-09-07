using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    internal static class VakRepository
    {
        private static List<Vak> _items = new List<Vak>();
        /// <summary>
        /// Compositie: VakRepository houdt alle vakken bij
        /// </summary>
        /// <remarks>static: er kan slechts 1 vakrepository zijn. Geen objecten en dus geen new!</remarks>
        internal static List<Vak> Items
        {
            get
            {
                return _items;
            }
            private set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Voegt een nieuw vak toe aan de repository
        /// </summary>
        /// <param name="item">het vak dat je toevoegt aan de repository</param>
        internal static  void AddItem(Vak item)
        {
            if (GetItem(item.Id) == null && FindItem(item.Naam) == null)
                Items.Add(item);
            else
                throw new Exception("Dit vak bestaat reeds in de repository!");
        }

        /// <summary>
        /// Haalt een vak op uit de repository op basis van id
        /// </summary>
        /// <param name="id">de id van het gewenste vak</param>
        /// <returns>het vak met deze id, null indien niet aanwezig</returns>
        internal static Vak GetItem(Int32 id)
        {
            foreach (Vak i in Items)
            {
                if (i.Id == id) return i;
            }
            return null;
        }

        /// <summary>
        /// Zoekt een vak op in de repository op basis van de opgegeven naam
        /// </summary>
        /// <param name="naam">naam van het te zoeken vak</param>
        /// <returns>het vak indien gevonden, anders null</returns>
        internal static Vak FindItem(string naam)
        {
            foreach (Vak i in Items)
            {
                if (i.Naam == naam) return i;
            }
            return null;

        }

        /// <summary>
        /// Verwijdert het vak met het opgegeven id uit de repository
        /// </summary>
        /// <param name="id">id van het te verwijderen vak</param>
        internal static void DeleteItem(Int32 id)
        {
            Items.Remove(GetItem(id));
        }

        /// <summary>
        /// GetNextId bepaalt een vrij id voor een nieuw vak
        /// </summary>
        /// <returns>vrij id voor een nieuw vak</returns>
        internal static Int32 GetNextId()
        {
            Int32 next_id = 0;
            foreach (Vak item in Items)
            {
                if (item.Id > next_id) next_id = item.Id;
            }
            return next_id + 1;
        }

        /// <summary>
        /// Load laadt alle aangegeven vakken in de repository-klasse
        /// </summary>
        /// <param name="items">lijst met vakken</param>
        /// <remarks>indien items = null wordt een lege lijst aangemaakt</remarks>
        internal static void Load(List<Vak> items)
        {
            if (items != null)
                Items = items;
            else
                Items = new List<Vak>();
        }

    }
}
