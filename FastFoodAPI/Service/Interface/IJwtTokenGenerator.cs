using FastFoodHouse_API.Models;


namespace FastFoodHouse_API.Service.Interface
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
