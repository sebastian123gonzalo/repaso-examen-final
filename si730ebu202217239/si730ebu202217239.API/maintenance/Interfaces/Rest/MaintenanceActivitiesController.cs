using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202217239.maintenance.Domain.Model.Aggregates;
using si730ebu202217239.maintenance.Domain.Model.Queries;
using si730ebu202217239.maintenance.Domain.Services;
using si730ebu202217239.maintenance.Interfaces.Rest.Resources;
using si730ebu202217239.maintenance.Interfaces.Rest.Transform;

namespace si730ebu202217239.maintenance.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MaintenanceActivitiesController(IMaintenanceActivityQueryService maintenanceActivityQueryService, IMaintenanceActivityCommandService maintenanceActivityCommandService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMaintenanceActivityById(int maintenanceActivityId)
    {
        var getMaintenanceActivityByIdQuery = new GetMaintenanceActivityByIdQuery(maintenanceActivityId);
        var maintenanceActivity = await maintenanceActivityQueryService.Handle(getMaintenanceActivityByIdQuery);
        if (maintenanceActivity == null) return NotFound();
        var maintenanceActivityResource = MaintenanceActivityResourceFromEntityAssembler.ToResourceFromEntity(maintenanceActivity);
        return Ok(maintenanceActivityResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMaintenanceActivity([FromBody] CreateMaintenanceActivityResource resource)
    {
        var createMaintenanceActivityCommand = CreateMaintenanceActivityCommandFromResourceAssembler.ToCommandFromResource(resource);
        MaintenanceActivity? maintenanceActivity;
        try
        {
            maintenanceActivity = await maintenanceActivityCommandService.Handle(createMaintenanceActivityCommand);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        if (maintenanceActivity == null) return BadRequest();
        var maintenanceActivityResource = MaintenanceActivityResourceFromEntityAssembler.ToResourceFromEntity(maintenanceActivity);
        return CreatedAtAction(nameof(GetMaintenanceActivityById), new { maintenanceActivityId = maintenanceActivityResource.Id }, maintenanceActivityResource);
    }
    
}