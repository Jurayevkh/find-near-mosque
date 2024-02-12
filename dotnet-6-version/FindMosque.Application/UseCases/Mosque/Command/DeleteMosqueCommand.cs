using MediatR;

namespace FindMosque.Application.UseCases.Mosque.Command;

public class DeleteMosqueCommand : IRequest<bool>
{
    public string Name { get; set; }
}
