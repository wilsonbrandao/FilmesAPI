﻿using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HoraDeInicio, opts => opts
                .MapFrom(dto => dto.HoraDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));

        }
    }
}
