using FindMosque.Application.Abstractions;
using FindMosque.Application.UseCases.Mosque.Command;
using MediatR;
namespace FindMosque.Application.UseCases.Mosque.Handler;

public class UpdateMosqueComandHandler : IRequestHandler<UpdateMosqueCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateMosqueComandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateMosqueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var mosque = _applicationDbContext.Mosque.FirstOrDefault(mosque=>mosque.Name==request.OldName);
            if (mosque is null)
                return false;
            mosque.Name = request.Name ?? mosque.Name;
            mosque.Latitude = request.Latitude;
            mosque.Longtitude = request.Longtitude;
            mosque.Address = request.Address ?? mosque.Address;
            mosque.City = request.City ?? mosque.City;
            mosque.PostCode = request.PostCode ?? mosque.PostCode;
            _applicationDbContext.Mosque.Update(mosque);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
}
        catch
        {
            return false;
        }
    }
}

