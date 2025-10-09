using CarCrud.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarCrud.Presentation.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = _carService;
        }


       

    } 
}
