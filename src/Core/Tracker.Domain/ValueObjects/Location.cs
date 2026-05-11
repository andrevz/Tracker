using Tracker.Domain.Common;

namespace Tracker.Domain.ValueObjects;

public record class Location
{
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    private Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Result<Location> Create(double latitude, double longitude)
    {
        var errors = new List<string>();

        if (latitude < -90 || latitude > 90)
            errors.Add("Latitude must be between -90 and 90.");

        if (longitude < -180 || longitude > 180)
            errors.Add("Longitude must be between -180 and 180.");

        if (errors.Count > 0)
            return Result.Failure<Location>(errors);

        return Result.Success(new Location(latitude, longitude));
    }
}
