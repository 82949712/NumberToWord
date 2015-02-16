using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using NumberToWord.DB;
using System.Web.Http.Description;

namespace NumberToWord.API.Controllers
{
    public class CalculationController : ApiController
    {
        //
        // GET: /Calculation/
        public IHttpActionResult Get()
        {
            CalculationDbContext dbContext = new CalculationDbContext();
            return this.Ok(dbContext.Calculations);
        }

        public HttpResponseMessage Post([FromBody]Calculation calculation)
        {
            var response = Request.CreateResponse();
            CalculationDbContext dbContext = new CalculationDbContext();
            dbContext.Calculations.Add(calculation);
            dbContext.SaveChanges();
            response.Content = new StringContent("Record added...");
            response.StatusCode = HttpStatusCode.Created; //status code 201
            return response;
        }


        public HttpResponseMessage Put([FromBody] Calculation calculation)
        {
            var response = Request.CreateResponse();
            CalculationDbContext dbContext = new CalculationDbContext();
            
            if (ModelState.IsValid)
            {
                dbContext.Calculations.Attach(calculation);

                dbContext.Entry(calculation).State = EntityState.Modified;
                dbContext.SaveChanges();
                response.Content = new StringContent("Updated by attaching...");
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            return response;
        }


    }
}
