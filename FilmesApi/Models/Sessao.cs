﻿using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //virtual to lazy load
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }

        public DateTime HoraDeEncerramento { get; set; }

    }
}
