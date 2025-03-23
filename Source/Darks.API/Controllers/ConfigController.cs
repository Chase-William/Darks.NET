using Darks.API.Infrastructure.Repositories;
using Darks.API.Logic.Services;
using Darks.Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers
{
    public abstract class ConfigController<TViewModel>(
        ILogger<ConfigController<TViewModel>> logger,
        IConfigService<TViewModel> configService) : ControllerBase
    {
        private readonly ILogger<ConfigController<TViewModel>> _logger = logger;
        private readonly IConfigService<TViewModel> _configService = configService;

        public virtual async Task<IActionResult> GetAsync()
        {
            var resolutionClaim = User.FindFirst("rid");

            if (resolutionClaim is null)
            {
                return BadRequest(Result<TViewModel>.Failure("Failed to acquire resolution id claim from authorization token."));
            }

            if (!int.TryParse(resolutionClaim.Value, out int rid))
            {
                return BadRequest(Result<TViewModel>.Failure($"The provided resolution id claim of {resolutionClaim.Value} failed to parse."));
            }

            var result = await _configService.GetViewModelByResolutionIdAsync(rid);

            if (result.HasError())
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
