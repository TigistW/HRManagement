using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
        return Ok(leaveTypes);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
        return Ok(leaveType);
    }

    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
    {
        var response = await _mediator.Send(new CreateLeaveTypeCommand { createLeaveTypeDto = leaveType });
        return Ok(response);

    }

    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
    {
        await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType });
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
        return NoContent();
    }
}
