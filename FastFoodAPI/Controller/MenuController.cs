using FastFoodHouse_API.Data;
using FastFoodHouse_API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FastFoodHouse_API.Controller
{
    [Route("api/v1/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ApiResponse _apiResponse;

        // Constructor: Initializes the MenuController with an instance of ApplicationDbContext.
        // Also initializes an ApiResponse object for handling API responses.
        public MenuController(ApplicationDbContext db)
        {
            _db = db;
            _apiResponse = new ApiResponse();
        }

        // HTTP GET endpoint for retrieving menu items.
        [HttpGet]
        public IActionResult GetMenuItems()
        {
            try
            {
                // Try to retrieve menu items from the database and assign them to ApiResponse.Result.
                _apiResponse.Result = _db.Menu;

                // Set the HTTP status code to 200 OK.
                _apiResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // If an exception occurs, set ApiResponse properties to indicate an error.
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.Message };
            }

            // Return an OkObjectResult with the ApiResponse, which includes menu items or error information.
            return Ok(_apiResponse);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            if(id == 0) 
            {
                _apiResponse.IsSuccess=false;
                _apiResponse.StatusCode=HttpStatusCode.NotFound;
                return Ok(_apiResponse);
            }
       
                _apiResponse.StatusCode =HttpStatusCode.OK;
                _apiResponse.Result = await _db.Menu.FindAsync(id);
          
            return Ok(_apiResponse);
        }


        
    }
}

