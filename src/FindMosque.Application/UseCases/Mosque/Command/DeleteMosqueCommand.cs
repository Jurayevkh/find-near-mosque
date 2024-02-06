using MediatR;

namespace FindMosque.Application.UseCases.Mosque.Command;

public class DeleteMosqueCommand:IRequest<bool>
{
    public required string Name { get; set; }
}

