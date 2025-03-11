using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Application.Commands.Wallets.Delete;
using MyWallet.Application.Commands.Wallets.Update;
using MyWallet.Application.Queries.Wallets.GetAll;
using MyWallet.Application.Queries.Wallets.GetBy;
using MyWallet.Domain.Entities;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class WalletsController : ControllerBase
{
    private readonly ILogger<WalletsController> _logger;
    private readonly IMediator _mediator;
    public WalletsController(ILogger<WalletsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Retorna todas las Wallets creadas por el usuario 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllWalletsQuery());
        return Ok(response);
    }

    /// <summary>
    /// Retorna todas las Wallets creadas por el usuario 
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _mediator.Send(new GetWalletByIdQuery(id));
        return Ok(response);
    }

    /// <summary>
    /// Crea un nuevo Wallet
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(CreateWalletCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response.Data);
    }

    /// <summary>
    /// Actualiza la informacion de la Wallet
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateWalletCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    /// <summary>
    /// Elimina la Wallet creadas por el usuario. 
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var command = new DeleteWalletCommand() { Id = id };
        var response = await _mediator.Send(command);
        return Accepted(response);
    }
}
