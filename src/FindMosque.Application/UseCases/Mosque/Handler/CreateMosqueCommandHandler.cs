using FindMosque.Application.Abstractions;
using FindMosque.Application.UseCases.Mosque.Command;
using MediatR;

namespace FindMosque.Application.UseCases.Mosque.Handler;

using FindMosque.Domain.Entities.Mosque;

public class CreateMosqueCommandHandler : IRequestHandler<CreateMosqueCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateMosqueCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateMosqueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isHaveMosque = _applicationDbContext.Mosque.FirstOrDefault(mosque=>mosque.Name==request.Name);

            if(isHaveMosque is not null)
                return false;
            

            Mosque mosque = new Mosque()
            {
                Name=request.Name,
                Latitude=request.Latitude,
                Longtitude=request.Longtitude,
                Address=request.Address,
                City=request.City,
                PostCode=request.PostCode ?? "",
                CreatedAt=DateTime.UtcNow
            };

            await _applicationDbContext.Mosque.AddAsync(mosque);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

