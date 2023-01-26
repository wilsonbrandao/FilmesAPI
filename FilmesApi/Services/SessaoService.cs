using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<ReadSessaoDto> RecuperaSessoes()
        {
            List<Sessao> listSessao = _context.Sessoes.ToList();
            if(listSessao == null) return null;
            List<ReadSessaoDto> listSessaoDto = _mapper.Map<List<ReadSessaoDto>>(listSessao);
            return listSessaoDto;
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.Where(sessao => sessao.Id == id).FirstOrDefault();
            if (sessao != null) 
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return sessaoDto;

            } 
            return null;
        }

    }
}
