using CustomerSupport.API.Common;
using CustomerSupport.Application.Interfaces;
using CustomerSupport.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerSupport.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : ApiBaseController
    {
        public ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Json(_customerService.GetAll().ToList());
        }

        [HttpGet]
        [Route("get/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_customerService.GetById(id));
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] CustomerViewModel viewModelRequest)
        {
            return JsonOrError(_customerService.Add(viewModelRequest));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] CustomerViewModel viewModelRequest)
        {
            return JsonOrError(_customerService.Update(viewModelRequest));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            return JsonOrError(_customerService.Remove(id));
        }

        [HttpGet]
        [Route("inquiries")]
        public IActionResult GetInquiries()
        {
            var inquiries = new[] 
            { 
                new { Id = 1, Description = "App not work" },
                new { Id = 2, Description = "Improper billing"},
                new { Id = 3, Description = "Change bill"}
            };
            return Ok(inquiries);
        }
    }
}
