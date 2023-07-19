using BLL.Interfaces;
using Employee.Common.DTO.Language;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _service;
    public LanguagesController(ILanguageService service)
    {
        _service = service;
    }

    [HttpPost("language")]
    public async Task<IActionResult> Add(LanguageDTO language)
    {
        try
        {
            var result = await _service.AddLanguage(language);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("language")]
    public async Task<IActionResult> UpdateLanguage(string name, LanguageDTO language)
    {
        try
        {
            var result = await _service.UpdateLanguage(language, name);
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
    [HttpDelete("language")]
    public async Task<IActionResult> DeleteEmployer(string name)
    {
        try
        {
            return await _service.DeleteLanguage(name) ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}