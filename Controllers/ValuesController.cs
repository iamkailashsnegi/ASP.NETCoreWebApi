﻿using CoreApi.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("Data").GetSection("ConnectionString").Value;
        }

        [HttpGet("Sample")]
        public IList<string> GetSample()
        {
            IList<string> _strList;
            var _repo = new Repo.SampleRepo();
            _strList = _repo.Sample(_connectionString);
            return _strList;
        }
    }
}
