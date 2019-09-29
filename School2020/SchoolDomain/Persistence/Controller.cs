using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolDomain.Business;

namespace SchoolDomain.Persistence
{
    internal static class Controller
    {
        private static string _connectionstring = "";
        private static string ConnectionString
        {
            get
            {
                if (_connectionstring == "")
                {
                    //instellen database en plaats database
                    _connectionstring = "server=localhost;port=3306;user id=root;pwd= usbw;database=school;";
                }
                return _connectionstring;
            }
        }

        #region vakken
        internal static List<Vak> GetAlleVakken()
        {
            VakMapper vm = new VakMapper(ConnectionString);
            return vm.GetVakkenFromDB();
        }

        internal static void AddVak(Vak vak)
        {
            VakMapper vm = new VakMapper(ConnectionString);
            vm.AddVakToDB(vak);
        }

        internal static void DeleteVak(Vak vak)
        {
            VakMapper vm = new VakMapper(ConnectionString);
            vm.DeleteVakFromDB(vak.Id);
        }
        internal static void UpdateVak(Vak vak)
        {
            VakMapper vm = new VakMapper(ConnectionString);
            vm.UpdateVakInDB(vak);
        }
        #endregion
        internal static List<Component> GetAlleComponenten()
        {
            ComponentMapper cm = new ComponentMapper(ConnectionString);
            return cm.GetComponentsFromDB();
        }

        internal static void AddComponent(Component component)
        {
            ComponentMapper cm = new ComponentMapper(ConnectionString);
            cm.AddComponentToDB(component);
        }

    }
}
