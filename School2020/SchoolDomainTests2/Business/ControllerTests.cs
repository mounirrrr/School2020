using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolDomain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain.Business.Tests
{
    [TestClass()]
    public class ControllerTests
    {
        [TestMethod()]
        public void GetAlleVakkenTest()
        {
            Controller c = new Controller();
            Assert.AreEqual(c.GetAlleVakken().Count,1);
        }
    }
}