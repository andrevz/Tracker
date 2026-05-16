using Tracker.Application.Common.Contracts.CQRS;
using Tracker.Application.Common.Contracts.Repositories;
using Tracker.Application.Features.Stops.GetAll.DTO;
using Tracker.Application.Features.Stops.GetAll.Query;
using Tracker.Domain.Common;

namespace Tracker.Application.Features.Stops.GetAll.Handler;

public class GetAllStopsQueryHandler(IStopRepository stopRepository)
    : IQueryHandler<GetAllStopsQuery, Result<IEnumerable<GetAllStopResponse>>>
{
    public async Task<Result<IEnumerable<GetAllStopResponse>>> HandleAsync(GetAllStopsQuery query, CancellationToken cancellationToken)
    {
        var stops = await stopRepository.GetAllSync();
        var responseData = stops.Select(s => new GetAllStopResponse
        {
            Name = s.Name,
            Latitude = s.Location.Latitude,
            Longitude = s.Location.Longitude,
            DisplayOrder = s.DisplayOrder
        });
        
        return Result.Success(responseData);
    }
}