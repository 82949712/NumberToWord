using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWord.Common;
using NumberToWord.Web.Controllers;
using Rhino.Mocks;

namespace NumberToWord.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private INumberToWordService<decimal> _numberToWordService ;
        private HomeController _homeController;

        [TestInitialize]
        public void Initialize()
        {
            _numberToWordService = MockRepository.GenerateStub<INumberToWordService<decimal>>();
            _numberToWordService.Stub(s => s.Convert(Arg<int>.Is.Anything)).Return("Success");
            _homeController = new HomeController(_numberToWordService);
        }

        [TestMethod]
        public void Index_Post_ReturnJsonResult()
        {
            var result = _homeController.Index("2");
            Assert.IsTrue(result is JsonResult);
        }

        [TestMethod]
        public void Index_Post_NotNumber()
        {
            var result = _homeController.Index("Not_A_Number") as JsonResult; 
            Assert.AreEqual(result.Data.ToString(), "No a valid number.");
        }

        [TestMethod]
        public void Index_Post_CorrectNumber()
        {
            var result = _homeController.Index("100") as JsonResult; 
            Assert.AreEqual(result.Data.ToString(), "Success");
        }

        [TestMethod]
        public void Index_Post_ExceptionFromService()
        {
            //clear stub
            _numberToWordService.BackToRecord(BackToRecordOptions.All);
            _numberToWordService.Replay();

            _numberToWordService.Stub(s => s.Convert(Arg<int>.Is.Anything)).Throw(new FormatException("Format Exception"));
            var result = _homeController.Index("100") as JsonResult;
            Assert.AreEqual(result.Data.ToString(), "Format Exception");
        }

    }
}
