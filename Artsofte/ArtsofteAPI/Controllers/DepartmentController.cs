using BLL.Interfaces;
using DAL.Entities;
using Employer.Common.DTO.Department;
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

    [HttpPost("{id}")]
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
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLanguage(int id, DepartmentDTO department)
    {
        try
        {
            var result = await _service.UpdateDepartment(department, id);
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
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteEmployer(int id)
    {
        try
        {
            return await _service.DeleteDepartment(id) ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}