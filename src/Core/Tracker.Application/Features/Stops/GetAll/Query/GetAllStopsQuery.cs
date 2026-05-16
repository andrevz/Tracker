using Tracker.Application.Common.Contracts.CQRS;
using Tracker.Application.Features.Stops.GetAll.DTO;
using Tracker.Domain.Common;

namespace Tracker.Application.Features.Stops.GetAll.Query;

public class GetAllStopsQuery : IQuery<Result<IEnumerable<GetAllStopResponse>>>
{
}