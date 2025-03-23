using Darks.API.Infrastructure.Interfaces.MainMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.MainMenu
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MainMenuController(IMainMenuConfigRepository repo) : ControllerBase
    {
        private readonly IMainMenuConfigRepository _repo = repo;
    }
}
