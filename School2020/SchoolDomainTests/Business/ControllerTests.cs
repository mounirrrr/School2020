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
        public void MaakComponentTest()
        {
            Controller c = new Controller();
            Vak so = c.NieuwVak("softwareontwikkeling");
            Component dw = c.MaakComponent("Dagelijks werk", 40, "TA");
            Component ex = c.MaakComponent("Examen", 60, "EX");
            c.NieuweEvaluatie(so.Id, "compositie", 21.0, 60.0, dw.Id);
            c.NieuweEvaluatie(so.Id, "aggregatie", 30.0, 40.0, ex.Id);
            Assert.AreEqual(so.Resultaat, 55); // gewogen resultaat in % in plaats van 51%
        }
    }
}