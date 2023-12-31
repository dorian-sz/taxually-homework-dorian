﻿using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistration;
using Taxually.TechnicalTest.Helpers.Interfaces.VatRegistrationFactory;
using Taxually.TechnicalTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        readonly IVatRegistrationFactory<IVatRegistration<VatRegistrationModel>> _factory;

        public VatRegistrationController(IVatRegistrationFactory<IVatRegistration<VatRegistrationModel>> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationModel request)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var vatRegistration = _factory.GetRegistrationInstance(request.Country);
            if (vatRegistration == null)
            {
                return BadRequest("Invalid country code");
            }
            var success = await vatRegistration.Register(request);
            if (success)
            {
                return Ok();
            }
            return BadRequest("Invalid model");
        }
    }
}
