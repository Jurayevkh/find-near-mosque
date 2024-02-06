using FindMosque.Application.Abstractions;
using FindMosque.Application.UseCases.Mosque.Command;
using MediatR;

namespace FindMosque.Application.UseCases.Mosque.Handler;

public class DeleteMosqueCommandHandler : IRequestHandler<DeleteMosqueCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteMosqueCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteMosqueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var mosque = await _applicationDbContext.Mosque.FirstOrDefaultAsync(mosque=>mosque.Name==request.Name);
            if (mosque is null)
                return false;
            _applicationDbContext.Mosque.Remove(mosque);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

