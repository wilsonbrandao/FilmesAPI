using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;
  
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> listCinemaDto = _cinemaService.RecuperaCinemas(nomeDoFilme);
            if (listCinemaDto == null) return NotFound();
            return Ok(listCinemaDto);
        }


        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.RecuperaCinemasPorId(id);
            if(readCinemaDto != null) return Ok(readCinemaDto);    
            return NotFound();
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaService.AtualizaCinema(id, cinemaDto);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result result = _cinemaService.DeletaCinema(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
