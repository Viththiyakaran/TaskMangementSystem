using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessInterface _businessService;

        public BusinessController(IBusinessInterface businessService)
        {
            _businessService = businessService;
        }
        [HttpGet("BusinessInfo")]
        public async Task<IEnumerable<TblCustomerBusiness>> GetAllBusinessDetails()
        {
            return await _businessService.GetAllBusinessDetails();
        }

        [HttpGet("BusinessInfo/{businessId}")]
        public async Task<ActionResult<TblCustomerBusiness>> GetAllBusinessDetails(int businessId)
        {
            var business = await _businessService.GetAllBusinessDetailsById(businessId);
            if (business == null)
            {
                return NotFound();
            }
            return Ok(business);
        }

    }

}