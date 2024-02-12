namespace FindMosque.Application.UseCases.Mosque.Handler;
using MediatR;
using FindMosque.Domain.Entities.Mosque;
using FindMosque.Application.UseCases.Mosque.Query;
using FindMosque.Application.Abstraction;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

public class GetNearestMosqueQueryHandler : IRequestHandler<GetNearestMosqueQuery, Mosque>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public const double EarthRadiusKm = 6371.0;

    public GetNearestMosqueQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    private static double ToRadians(double angle)
    {
        return Math.PI * angle / 180.0;
    }

    // Calculates the distance between two points using the Haversine formula
    public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        double dLat = ToRadians(lat2 - lat1);
        double dLon = ToRadians(lon2 - lon1);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return EarthRadiusKm * c;
    }

    public async Task<Mosque> Handle(GetNearestMosqueQuery request, CancellationToken cancellationToken)
    {
        var mosques = await _applicationDbContext.Mosque.ToListAsync();
        var nearest = mosques[0];
        for(int i = 0; i < mosques.Count; i++)
        {
            //if (nearest > mosques[i])
        }
        throw new NotImplementedException();
    }
}

