namespace FindMosque.Application.UseCases.Mosque.Query;
using MediatR;
using FindMosque.Domain.Entities.Mosque;

public class GetNearestMosqueQuery : IRequest<Mosque>
{
    public decimal Latitude { get; set; }
    public decimal Longtitude { get; set; }
}

