using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using Ninject.Infrastructure.Language;
using NumberToWord.Common;
using NumberToWord.DB;

namespace NumberToWord.API.Controllers
{
    public class NumberToWordController : ApiController
    {
        private readonly INumberToWordService<decimal> _numberToWordService;

        public NumberToWordController(INumberToWordService<decimal> numberToWordService) 
        {
            _numberToWordService = numberToWordService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        //Content-Type: application/json; charset=utf-8
        public HttpResponseMessage Post([FromBody]string number)
        {
            var response = Request.CreateResponse();
           
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
            response.StatusCode = HttpStatusCode.Accepted;
            response.Content = new StringContent(result);
            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}