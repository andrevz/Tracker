using Tracker.Application.Common.Contracts.CQRS;
using Tracker.Application.Features.Stops.Update.Command;
using Tracker.Domain.Common;

namespace Tracker.Application.Features.Stops.Update.Handler;

public class UpdateStopCommandHandler : ICommandHandler<UpdateStopCommand, Result>
{
    public Task<Result> HandleAsync(UpdateStopCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
