using Darks.API.Infrastructure.Interfaces.ParasaurAlarm;
using Darks.API.Logic.Interfaces;
using Darks.Core.Models.ParasaurAlarm;
using Darks.Core.ViewModels.ParasaurAlarm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.ParasaurAlarm
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParasaurAlarmConfigController(
        ILogger<ParasaurAlarmConfigController> logger,
        IParasaurConfigService parasaurAlarmService
        ) : ConfigController<ParasaurAlarmConfigViewModel>(logger, parasaurAlarmService)
    {        
        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            return await base.GetAsync();
        }
    }
}
