using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_ASSIGNMENT.Models;


namespace Web_API_ASSIGNMENT.Controllers
{
    public class CountryController : ApiController
        // I have used Postman for the execution of CRUD Operations cause i was having  installation
        // issues while installing swashbuckle in my VS2022....
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "INDIA", Capital = "NEW-DELHI" },
            new Country { ID = 2, CountryName = "NEPAL", Capital = "KATHMANDU" },
            new Country { ID = 3, CountryName = "USA", Capital = "WASHINGTON DC" },
            new Country { ID = 4, CountryName = "PAKISTAN", Capital = "KARACHI" },
        };

        // GET api/country
        public IHttpActionResult GetAllCountries()
        {
            return Ok(countries);
        }

        // GET api/country/1
        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No matching ID found"));
            }
            return Ok(country);
        }

       
        [HttpPost]
        public List<Country> PostAll([FromBody] Country country)
        {
            countries.Add(country);
            return countries;
        }
       


        
        [HttpPut]
        
        public void Put(int contid, [FromUri] Country country)
        {
            countries[contid - 1] = country;
        }

        //public IHttpActionResult UpdateCountry(int id, [FromBody] Country updatedCountry)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existingCountry = countries.FirstOrDefault(c => c.ID == id);
        //    if (existingCountry == null)
        //    {
        //        return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No matching ID found for Updation."));
        //    }

        //    existingCountry.CountryName = updatedCountry.CountryName;
        //    existingCountry.Capital = updatedCountry.Capital;
        //    return Ok(existingCountry);
        //}
        //-------------------------------------------------------------------------------------------------------
        // DELETE api/country/1
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No matching ID found for deletion."));
            }

            countries.Remove(country);
            return Ok(country);
        }
    }
}
