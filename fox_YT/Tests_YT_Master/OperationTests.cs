using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using YT_Master.Operations.Slaves;

namespace Tests_YT_Master
{
    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void TestOpGetLinks()
        {

            string path = @"..\..\..\Files\Wiadomości z rynków - Bankier.pl.html";
            string body = File.ReadAllText(path);
            var tmp = new OperationGetLinks();
            List<string> actual = tmp.MakeOperation(body);

            int expected_caount = 15;
            string expected_first_link = @"https://www.bankier.pl/wiadomosc/Modelowa-marza-rafineryjna-Grupy-Lotos-w-lipcu-spadla-do-2-46-USD-bbl-8163627.html";
            string expected_last_link = @"https://www.bankier.pl/wiadomosc/Banki-oczekuja-wzrostu-popytu-we-wszystkich-segmentach-rynku-kredytowego-8163361.html";

            Assert.AreEqual(expected_caount,     actual.Count, "Blad: OperationTests -> TestOpGetLinks -> ilosc linkow");
            Assert.AreEqual(expected_first_link, actual[0],    "Blad: OperationTests -> TestOpGetLinks -> pierwszy link");
            Assert.AreEqual(expected_last_link,  actual[14],   "Blad: OperationTests -> TestOpGetLinks -> ostatni link");
        }
    }
}
