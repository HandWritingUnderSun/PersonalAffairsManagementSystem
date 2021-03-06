﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS.IServices;
using PAMS.Services;

namespace PersonalAffairsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        // GET: api/Operation
        [HttpGet]
        public int Get(int i,int j)
        {
            IAdvertisementServices advertisementServices = new AdvertisementServices();
            return advertisementServices.Sum(i,j);
        }

        // GET: api/Operation/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Operation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Operation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
