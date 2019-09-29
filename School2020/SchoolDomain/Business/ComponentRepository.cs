using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    internal static class ComponentRepository
    {
        private static List<Component> _items = new List<Component>();
        internal static List<Component> Items
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

        internal static void AddItem(Component item)
        {
            Items.Add(item);
        }

        internal static Component GetItem(Int32 id)
        {
            /*
            foreach (Vak i in Items)
            {
                if (i.Id == id) return i;
            }
            return null;
            */
            return Items.Find(i => i.Id == id);
        }

        internal static Component FindItem(string naam)
        {
            foreach (Component i in Items)
            {
                if (i.Naam == naam) return i;
            }
            return null;

        }

        internal static void DeleteItem(Int32 id)
        {
            Items.Remove(GetItem(id));
        }

        internal static Int32 GetNextId()
        {
            Int32 next_id = 0;
            foreach (Component item in Items)
            {
                if (item.Id > next_id) next_id = item.Id;
            }
            return next_id + 1;
        }

        internal static void Load(List<Component> items)
        {
            if (items == null)
                Items = new List<Component>();
            else
                Items = items;
        }
    }
}
