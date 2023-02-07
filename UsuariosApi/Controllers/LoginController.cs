using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result result = _loginService.LogaUsuario(request);
            if (result.IsFailed) return Unauthorized(result.Errors[0]);

            return Ok(result.Successes[0]);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result result = _loginService.SolicitaResetSenhaUsuario(request);
            if (result.IsFailed) return Unauthorized(result.Errors[0]);
            return Ok(result.Successes[0]);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result result = _loginService.ResetaSenhaUsuario(request);
            if (result.IsFailed) return Unauthorized(result.Errors[0]);
            return Ok(result.Successes[0]);

            
        }


    }
}
