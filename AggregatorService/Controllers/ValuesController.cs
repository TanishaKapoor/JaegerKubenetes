using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AggregatorService.Controllers
{
    [Route("orderdetails")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
  
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<string>>> Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var userurl = Environment.GetEnvironmentVariable("UserURL")?? "http://localhost:61942";
                var orderurl = Environment.GetEnvironmentVariable("OrderURL")?? "http://localhost:61975";

                var tasks = new[]
                {
                    GetResponse($"{userurl}/user/{id}",client),
                    GetResponse($"{orderurl}/orders/{id}",client)
                };
                var responses = await  Task.WhenAll(tasks);
                var user = JsonConvert.DeserializeObject(responses[0].Value);
                var order = JsonConvert.DeserializeObject(responses[1].Value);
                return Ok(new {userDetails=user ,orders=order });
            }
        }
        public async Task<ActionResult<string>> GetResponse(string url, HttpClient client)
        {
            using (var response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;

                }
                else
                {
                    Console.Write("error");
                }
            }
            return null;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
