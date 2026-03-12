using Microsoft.AspNetCore.Mvc;
using unit_converter.Models;
using unit_converter.Services;

namespace unit_converter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConverterController : ControllerBase
{
    private readonly CalculateService _calculateService;

    public ConverterController(CalculateService calculateService)
    {
        _calculateService = calculateService;
    }

    [HttpPost("convert")]
    public IActionResult Convert([FromBody] ConversionRequest request)
    {
        try
        {
            decimal result = request.Type.ToLower() switch
            {
                "length" => _calculateService.CalculateLength(request.Value, request.FromUnit, request.ToUnit),
                "weight" => _calculateService.CalculateWeight(request.Value, request.FromUnit, request.ToUnit),
                "temperature" => _calculateService.CalculateTemperature(request.Value, request.FromUnit, request.ToUnit),
                _ => throw new ArgumentException($"Unsupported conversion type: {request.Type}")
            };

            return Ok(new
            {
                result = result,
                unit = request.ToUnit
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error] {DateTime.Now}: {ex.Message}");
            return StatusCode(500, "An internal error occurred during calculation.");
        }
    }
}