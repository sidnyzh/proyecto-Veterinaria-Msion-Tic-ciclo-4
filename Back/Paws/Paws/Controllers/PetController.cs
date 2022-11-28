using Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Paws.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetApplication _petApplication;

        public PetController(IPetApplication petApplication)
        {
            _petApplication = petApplication;
        }


    }
}
