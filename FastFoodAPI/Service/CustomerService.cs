using AutoMapper;
using FastFoodHouse_API.Data;
using FastFoodHouse_API.Models;
using FastFoodHouse_API.Models.Dtos;
using FastFoodHouse_API.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FastFoodHouse_API.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CustomerService(ApplicationDbContext db, IAuthService authService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _authService = authService;
            _mapper = mapper;
            _userManager = userManager;

        }
        //public async Task AddUser()
        //{
        //    IEnumerable<Customer> listUsers = _mapper.Map<IEnumerable<Customer>>(await _authService.GetAllUsers());
        //    foreach (var user in listUsers)
        //    {
        //        _db.Customer.Add(user);
        //        await _db.SaveChangesAsync();
        //    }

        //}

        //public async Task UpdateCustomer(string id, UpdateCustomerDTO updateCustomerDTO)
        //{
        //    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        //    user.Name = updateCustomerDTO.Name;
        //    IdentityResult x = await _userManager.UpdateAsync(user);
        //    if (x != null)
        //    {

        //    }
        //}



       
    }
}
