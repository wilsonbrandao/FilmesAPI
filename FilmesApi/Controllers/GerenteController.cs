using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }


        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<ReadGerenteDto> readGerenteDto = _gerenteService.RecuperaGerentes();
            if (readGerenteDto == null) return NotFound();
            return Ok(readGerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperaGerentePorId(id);
            if(readGerenteDto != null) return Ok(readGerenteDto);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionaGerente(gerenteDto);

            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readGerenteDto.Id }, readGerenteDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result result = _gerenteService.DeletaGerente(id);

            if (result.IsSuccess) return NoContent();
            
            return NotFound();
        }
    }
}
