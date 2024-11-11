using FastEndpoints;
using FluentValidation;


namespace Salpat.Clientes.Web.Transacciones;

public class CreateTransaccionValidator : Validator<CreateTransaccionRequest>
{
    public CreateTransaccionValidator(IConfiguration _configuration)
    {
       int minutos = -1 * _configuration.GetValue<int>("BsRules:MaxMinutesRegister");
       RuleFor(x => x.Fecha).GreaterThan(DateTime.Now.AddMinutes(minutos)); 
       RuleFor(x => x.ProductoId).InclusiveBetween(1,3);
    }
}