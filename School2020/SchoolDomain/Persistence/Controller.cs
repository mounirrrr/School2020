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

        internal static List<Vak> GetAlleVakken()
        {
            VakMapper vm = new VakMapper(ConnectionString);
            return vm.GetVakkenFromDB();
        }
        internal static List<Component> GetAlleComponenten()
        {
            return null;
        }

    }
}
