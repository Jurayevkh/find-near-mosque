using FindMosque.API.DTO.Mosque;
using FindMosque.Application.UseCases.Mosque.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindMosque.API.Controllers;

[Route("api/[controller]/[action]")]
public class MosqueController : ControllerBase
{
    private readonly IMediator _mediator;

    public MosqueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateMosque(CreateMosqueDTO createMosqueDTO)
    {
        CreateMosqueCommand mosque = new CreateMosqueCommand()
        {
            Name = createMosqueDTO.Name,
            Latitude = createMosqueDTO.Latitude,
            Longtitude = createMosqueDTO.Longtitude,
            Address = createMosqueDTO.Address,
            City = createMosqueDTO.City,
            PostCode = createMosqueDTO.PostCode ?? ""
        };

        var result = await _mediator.Send(mosque);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateMosque(UpdateMosqueDTO updateMosqueDTO)
    {
        UpdateMosqueCommand mosque = new UpdateMosqueCommand()
        {
            OldName = updateMosqueDTO.OldName,
            Name = updateMosqueDTO.Name,
            Latitude = updateMosqueDTO.Latitude,
            Longtitude = updateMosqueDTO.Longtitude,
            Address = updateMosqueDTO.Address,
            City = updateMosqueDTO.City,
            PostCode = updateMosqueDTO.PostCode,
        };
        var result = await _mediator.Send(mosque);
        return Ok(result);
    }

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteMosque(string Name)
    {
        var result = await _mediator.Send(new DeleteMosqueCommand() {Name=Name});
        return Ok(result);
    }
}

