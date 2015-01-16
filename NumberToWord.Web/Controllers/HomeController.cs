using System;
using System.Web.Mvc;
using NumberToWord.Common;

namespace NumberToWord.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INumberToWordService<decimal> _numberToWordService;

        public HomeController(INumberToWordService<decimal> numberToWordService)
        {
            _numberToWordService = numberToWordService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string number)
        {
            string result = "";
            try
            {
                decimal value;
                if (decimal.TryParse(number, out value) && value > 0)
                {
                    result = _numberToWordService.Convert(value);
                }
                else
                {
                    result = "No a valid number.";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
    }
}
