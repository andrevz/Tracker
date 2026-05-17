using Tracker.Domain.Common;
using Tracker.Domain.ValueObjects;

namespace Tracker.Domain.Entities;

public class Stop : Entity
{
    public string Name { get; private set; }
    public Location Location { get; private set; }
    public short DisplayOrder { get; private set; }

    protected Stop()
    {
        Name = string.Empty;
        Location = null!;
    }

    private Stop(string name, Location location, short displayOrder)
    {
        Name = name;
        Location = location;
        DisplayOrder = displayOrder;
    }

    public static Result<Stop> Create(string name, Location location, short displayOrder)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(name))
            errors.Add("Name is required.");

        return errors.Count > 0 
            ? Result.Failure<Stop>(errors) 
            : Result.Success(new Stop(name, location!, displayOrder));
    }
}
