using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpGet]
        public IActionResult RecuperaSessoes()
        {
            List<ReadSessaoDto> listSessaoDto = _sessaoService.RecuperaSessoes();
            if (listSessaoDto != null) return Ok(listSessaoDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId (int id)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.RecuperaSessoesPorId(id);
            if(readSessaoDto != null) return Ok(readSessaoDto);
            return NotFound();

        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new {Id = readSessaoDto.Id}, readSessaoDto); 
        }
    }
}
