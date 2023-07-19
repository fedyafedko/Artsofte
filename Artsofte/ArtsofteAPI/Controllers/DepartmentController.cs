using BLL.Interfaces;
using Employee.Common.DTO.Department;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;
    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpPost("department")]
    public async Task<IActionResult> Add(DepartmentDTO department)
    {
        try
        {
            var result = await _service.AddDepartment(department);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("department")]
    public async Task<IActionResult> UpdateLanguage(int floor, UpdateDepartmentDTO department)
    {
        try
        {
            var result = await _service.UpdateDepartment(department, floor);
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
    [HttpDelete("department")]
    public async Task<IActionResult> DeleteEmployer(int floor)
    {
        try
        {
            return await _service.DeleteDepartment(floor) ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}