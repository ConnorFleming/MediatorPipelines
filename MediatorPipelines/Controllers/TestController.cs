using MediatorPipelines.Mediator.GetUsers;
using MediatorPipelines.Mediator.OtherRequest;
using MediatorPipelines.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorPipelines.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;
    
    public TestController(ILogger<TestController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetUserQuery(1)));
    }

    [HttpGet("Other")]
    public async Task<IActionResult> GetOther()
    {
        return Ok(await _mediator.Send(new SomeOtherQuery()));
    }
}