using Microsoft.AspNetCore.Mvc;
using PharmacyDelivery.Models;
using PharmacyDelivery.Services;

namespace PharmacyDelivery.Controllers
{
    public class RequestBody
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ZipCode { get; set; }
    }

    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;
        private readonly ILogger<PharmacyController> _logger;

        public PharmacyController
        (
            IPharmacyService pharmacyService,
            ILogger<PharmacyController> logger
        )
        {
            _pharmacyService = pharmacyService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/api/pharmacy/{id}")]
        public Task<Pharmacy> Get(string id)
        {
            return _pharmacyService.GetPharmacy(id);
        }

        [HttpGet]
        [Route("/api/pharmacy/pharmacies")]
        public Task<List<Pharmacy>> Get()
        {
            return _pharmacyService.GetPharmacies();
        }

        [HttpPost]
        [Route("/api/pharmacy/create")]
        public async Task<IActionResult> Post([FromBody] RequestBody data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _pharmacyService.CreatePharmacy(data.Name, data.ImagePath, data.ZipCode);
            if (result != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("/api/pharmacy/delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                await _pharmacyService.DeletePharmacy(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("/api/pharmacy/update/{id}")]
        public async Task<IActionResult> Update([FromBody] RequestBody newData, string id)
        {
            if (!ModelState.IsValid || id == null)
            {
                return BadRequest();
            }

            var result = await _pharmacyService.UpdatePharmacy(id, newData.Name, newData.ImagePath, newData.ZipCode);
            if (result != null)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}