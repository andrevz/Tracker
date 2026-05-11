using Tracker.Domain.Common;
using Tracker.Domain.ValueObjects;

namespace Tracker.Domain.Entities;

public class Stop : Entity
{
    public string Name { get; private set; }
    public Location Location { get; set; }
    public short DisplayOrder { get; private set; }

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

        if (location == null)
            errors.Add("Location is required.");

        if (errors.Count > 0)
            return Result.Failure<Stop>(errors);

        return Result.Success(new Stop(name, location!, displayOrder));
    }
}
