namespace FindMosque.Application.UseCases.Mosque.Query;
using MediatR;
using FindMosque.Domain.Entities.Mosque;

public class GetNearestMosqueQuery:IRequest<Mosque>
{
    public required decimal Latitude { get; set; }
    public required decimal Longtitude { get; set; }
}

