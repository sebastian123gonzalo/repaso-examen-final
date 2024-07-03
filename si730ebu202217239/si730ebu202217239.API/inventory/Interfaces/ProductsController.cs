using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.inventory.Domain.Model.Queries;
using si730ebu202217239.inventory.Domain.Services;
using si730ebu202217239.inventory.Interfaces.Rest.Resources;
using si730ebu202217239.inventory.Interfaces.Rest.Transform;

namespace si730ebu202217239.inventory.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductsController(IProductQueryService productQueryService, IProductCommandService productCommandService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var getProductByIdQuery = new GetProductByIdQuery(productId);
        var product = await productQueryService.Handle(getProductByIdQuery);
        if (product == null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        Product? product;  //"product" can be a null value 
        try
        {
            product = await productCommandService.Handle(createProductCommand);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        if (product == null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { productId = productResource.Id }, productResource);
    }
}