using FastFoodHouse_API.Models.Dtos;
using FastFoodHouse_API.Service;
using FastFoodHouse_API.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodHouse_API.Controller
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }






        //[HttpGet]
        //public async Task<IActionResult> GetAllUsers()
        //{
        //    var users = await _customerService.GetAllUsers();
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(users);
        //}


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserById(string id)
        //{
        //    var userToReturn = await _authService.GetCustomerById(id);
        //    if (userToReturn == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(userToReturn);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCustomerAsync(string id, UpdateCustomerDTO updateCustomerDTO)
        //{
        //    await _customerService.UpdateCustomer(id, updateCustomerDTO);
        //    return Ok();
        //}



        //[HttpDelete("{userId}")]
        //public async Task<IActionResult> DeleteUser(string userId)
        //{
        //    var user = await _authService.DeleteUser(userId);
        //    if (user == "")
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}


    }
}
