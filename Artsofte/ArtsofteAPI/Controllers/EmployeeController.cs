using BLL.Interfaces;
using Employee.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteAPI.Controllers;
[Route("/")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;
    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }
    [HttpPost("add")]
    public async Task<IActionResult> Add(AddEmployeeDTO employee)
    {
        try
        {
            var result = await _service.AddEmployee(employee);
            return Ok(result);        
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteEmployer(int id)
    {
        try
        {
            return await _service.DeleteEmployee(id) ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("edit")]

    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDTO employee)
    {
        try
        {
            var result = await _service.UpdateEmployee(employee, id);
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