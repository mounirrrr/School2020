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
        public void NieuwVakTest()
        {
            Controller c = new Controller();
            Vak _vak = c.NieuwVak("wiskunde");
            c.NieuweEvaluatie(_vak.Id, "priemgetallen", 18, 20);
            c.NieuweEvaluatie(_vak.Id, "ontbinden in factoren", 14, 20);
            Assert.AreEqual(_vak.Resultaat, 80.0);
        }
    }
}