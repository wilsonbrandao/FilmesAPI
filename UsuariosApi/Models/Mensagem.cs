﻿using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsuariosApi.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigoDeAtivacao)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(dest => new MailboxAddress(dest)));
            Assunto = assunto;
            Conteudo = $"https://localhost:6001/ativa?UsuarioId={usuarioId}&CodigoDeAtivacao={codigoDeAtivacao}";
        }
    }
}
