using Darks.Core.Common;
using Darks.Core.Models.Resolution;

namespace Darks.API.Infrastructure.Interfaces
{
    public interface IResolutionRepository
    {
        Task<Result<ResolutionModel>> GetResolutionByWidthAndHeightAsync(int width, int height);
    }
}
