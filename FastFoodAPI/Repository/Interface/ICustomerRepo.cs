using FastFoodHouse_API.Data;
using FastFoodHouse_API.Models;
using FastFoodHouse_API.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FastFoodHouse_API.Repository.Interface
{
    public interface ICustomerRepo
    {
        public Task<ApplicationUser> GetAllCustomers();
        public Task<ApplicationUser> GetCustomerById(string customerId);
        public Task<string> DeleteCustomerById(string customrId);
        public Task<ApplicationUser> UpdateCustomerById(string customerId, ApplicationUser user);


    }
}
