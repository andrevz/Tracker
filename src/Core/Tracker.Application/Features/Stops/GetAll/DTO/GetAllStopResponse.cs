namespace Tracker.Application.Features.Stops.GetAll.DTO;

public class GetAllStopResponse
{
    public required string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public short DisplayOrder { get; set; }
}