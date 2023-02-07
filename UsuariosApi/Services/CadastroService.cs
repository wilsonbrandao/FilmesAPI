using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly EmailService _emailService;

        public CadastroService(IMapper mapper,
            UserManager<CustomIdentityUser> userManager,
            EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }


        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password).Result;
            
            _userManager.AddToRoleAsync(usuarioIdentity, "regular");

            if (resultadoIdentity.Succeeded)
            {
                var codegoAtivacao = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCodigoAtivacao = HttpUtility.UrlEncode(codegoAtivacao);

                _emailService.EnviarEmail(new[] { usuarioIdentity.Email },
                    "Link de Ativacao",
                    usuarioIdentity.Id,
                    encodedCodigoAtivacao);

                return Result.Ok().WithSuccess(codegoAtivacao);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            CustomIdentityUser usuarioIdentity = _userManager
                .Users
                .FirstOrDefault(usuario => usuario.Id == request.UsuarioId);

            IdentityResult identityResult = _userManager.ConfirmEmailAsync(usuarioIdentity, request.CodigoDeAtivacao).Result;
            if(identityResult.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
