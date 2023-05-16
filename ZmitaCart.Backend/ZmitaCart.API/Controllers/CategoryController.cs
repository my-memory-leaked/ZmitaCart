using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZmitaCart.API.Common;
using ZmitaCart.Application.Commands.CategoryCommands.CreateCategory;
using ZmitaCart.Application.Commands.CategoryCommands.DeleteCategory;
using ZmitaCart.Application.Queries.CategoryQueries.GetAllSuperiors;
using ZmitaCart.Application.Queries.CategoryQueries.GetCategories;
using ZmitaCart.Application.Commands.CategoryCommands.UpdateCategory;
using ZmitaCart.Application.Dtos.CategoryDtos;

namespace ZmitaCart.API.Controllers;

[Route("category")]
public class CategoryController : ApiController
{
    public CategoryController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var response = await mediator.Send(command);

        return response.IsSuccess 
            ? Created($"category/{response.Value}", response.Value) 
            : ResponseHandler.HandleErrors(response.Errors);
    }

    [HttpGet("getBySuperiorId")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesBySuperiorId([FromQuery] GetCategoriesBySuperiorIdQuery request)
    {
        var response = await mediator.Send(request);
        
        return response.IsSuccess 
            ? Ok(response.Value) 
            : ResponseHandler.HandleErrors(response.Errors);
    }

    [HttpGet("getFewBySuperiorId")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesBySuperiorId([FromQuery] GetCategoriesWithChildrenBySuperiorIdQuery request)
    {
        var response = await mediator.Send(request);
        
        return response.IsSuccess 
            ? Ok(response.Value) 
            : ResponseHandler.HandleErrors(response.Errors);
    }

    [HttpGet("getAllSuperiors")]
    public async Task<ActionResult<IEnumerable<SuperiorCategoryDto>>> GetCategoriesBySuperiorId()
    {
        var response = await mediator.Send(new GetAllSuperiorsQuery());
        
        return response.IsSuccess 
            ? Ok(response.Value) 
            : ResponseHandler.HandleErrors(response.Errors);
    }

    [HttpPut("updateCategory")]
    public async Task<ActionResult<int>> UpdateCategory([FromBody] UpdateCategoryCommand command)
    {
        var response = await mediator.Send(command);
        
        return response.IsSuccess 
            ? Ok(response.Value) 
            : ResponseHandler.HandleErrors(response.Errors);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCategory([FromRoute] DeleteCategoryCommand command)
    {
        var response = await mediator.Send(command);
        
        return response.IsSuccess 
            ? Ok() 
            : ResponseHandler.HandleErrors(response.Errors);
    }
}