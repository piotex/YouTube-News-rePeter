using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using YT_Master.Communication.Slaves;

namespace Tests_YT_Master
{
    [TestClass]
    public class CommunicationTests
    {
        [TestMethod]
        public void TestCommGetBody()
        {
            var tmp = new CommunicationBankier();
            string actual = tmp.GetBodyBankierNews(0);


            Assert.AreNotEqual("", actual, "Blad: CommunicationTests -> TestCommGetBody -> zwrucono pusta strone");
        }
    }
}
