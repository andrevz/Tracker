using Tracker.Domain.Common;

namespace Tracker.Domain.Entities;

public class Stop : Entity
{
    public string Name { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public short DisplayOrder { get; private set; }

    private Stop(string name, double latitude, double longitude, short displayOrder)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        DisplayOrder = displayOrder;
    }

    public static Result<Stop> Create(string name, double latitude, double longitude, short displayOrder)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(name))
            errors.Add("Name is required.");

        if (errors.Count > 0)
            return Result.Failure<Stop>(errors);

        return Result.Success(new Stop(name, latitude, longitude, displayOrder));
    }
}
