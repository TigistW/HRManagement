
using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
    {
        var LeaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
        return Ok(LeaveAllocations);
    }

   
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var LeaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
        return Ok(LeaveAllocation);
    }

    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto LeaveAllocation)
    {
        var response = await _mediator.Send(new CreateLeaveAllocationCommand { LeaveAllocationDto = LeaveAllocation });
        return Ok(response);

    }

    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto LeaveAllocation)
    {
        await _mediator.Send(new UpdateLeaveAllocationCommand { LeaveAllocationDto = LeaveAllocation });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
        return NoContent();
    }
}
