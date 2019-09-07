using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business
{
    public class Entity
    {
        Int32 id;

        public Int32 Id
        {
            get
            {
                return id;
            }
            internal set
            {
                id = value;
            }
        }

        internal Entity(Int32 id)
        {
            Id = id;
        }
    }
}
