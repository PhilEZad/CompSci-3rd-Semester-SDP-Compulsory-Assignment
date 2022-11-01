using System.ComponentModel.DataAnnotations;
using Application.Interfaces;
using Application.Validators;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BoxController : ControllerBase
{
    private IBoxService _boxService;

    public BoxController(IBoxService service)
    {
        _boxService = service;
    }

    [HttpGet]
    public List<Box> GetAllBoxes()
    {
        return _boxService.GetAllBoxes();
    }

    [HttpPost]
    public ActionResult<Box> CreateNewBox(PostBoxDTO dto)
    {
        try
        {
            var result = _boxService.CreateNewBox(dto);
            return Created("product/" + result.Id, result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    [Route("{id}")]
    public ActionResult<Box> UpdateBox([FromRoute] int id, [FromBody] Box box)
    {
        try
        {
            return Ok(_boxService.UpdateBox(id, box));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No box found at ID: " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Box> DeleteBox([FromRoute] int id)
    {
        try
        {
            return Ok(_boxService.DeleteBox(id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No box found at ID: " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpGet]
    [Route("buildDB")]
    public string CreateDB()
    {
        _boxService.BuildDb();
        return "Database has been created";
    }
}