using Tracker.Application.Common.Contracts.CQRS;
using Tracker.Domain.Common;

namespace Tracker.Application.Features.Stops.Update.Command;

public class UpdateStopCommand : ICommand<Result>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public short DisplayOrder { get; set; }
}