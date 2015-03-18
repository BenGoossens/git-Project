using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Krekelhof.Controllers;
using Project_Krekelhof.Models.Domain;

namespace Project_KrekelhofTest.Controller
{
    [TestClass]
    public class UitleningControllerTest
    {
        ////[TestMethod]
        //public void GetBrouwersReturnsBrouwers()
        //{
        //    Brouwer[] brouwers = controller.GetBrouwers().ToArray();
        //    Assert.AreEqual(3, brouwers.Length);
        //    Assert.AreEqual("Bavik",brouwers[0].Naam);
        //    Assert.AreEqual( "De Leeuw", brouwers[1].Naam);
        //    Assert.AreEqual("Duvel Moortgat",brouwers[2].Naam);
        //}

        private UitleningController controller;

        [TestMethod]
        public void GetUitleningenReturnsUitleningen()
        {
            Uitlening[] uitlenings = controller.GetUitleningen().ToArray();
            Assert.AreEqual(1, uitlenings.Length);
            Assert.AreEqual(1, uitlenings[0].Id);
        }
    }
}
