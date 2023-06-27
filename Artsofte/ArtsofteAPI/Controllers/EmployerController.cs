using BLL.Interfaces;
using Employer.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteAPI.Controllers;
[Route("/")]
[ApiController]
public class EmployerController : Controller
{
    private readonly IEmployerService _service;
    public EmployerController(IEmployerService service)
    {
        _service = service;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("add")]
    [ActionName(nameof(GetById))]
    public async Task<IActionResult> Add(AddEmployerDTO addEmployer)
    {
        try
        {
            var result = await _service.AddEmployer(addEmployer);
            return CreatedAtAction(nameof(_service.GetById), new { employer = result.Name }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteCurrency(int id)
    {
        try
        {
            return await _service.DeleteEmployer(id) ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("edit")]

    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployerDTO employer)
    {
        try
        {
            var result = await _service.UpdateEmployer(employer, id);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_service.GetAll());
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}