using FastEndpoints;
using FluentValidation;


namespace Salpat.Clientes.Web.Transacciones;

public class CreateTransaccionValidator : Validator<CreateTransaccionRequest>
{
    public CreateTransaccionValidator()
    {
       RuleFor(x => x.ProductoId).InclusiveBetween(1,3);
    }
}