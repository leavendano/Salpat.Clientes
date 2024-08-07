﻿namespace Salpat.Clientes.Core.Interfaces;

public interface IEmailSender
{
  Task SendEmailAsync(string to, string from, string subject, string textbody, string? htmlbody=null);
}
