namespace Salpat.Clientes.Web.Clientes;

public class GetClientByPhoneRequest
{
  public const string Route = "/Clientes/{Telefono}";
  public static string BuildRoute(string telefono) => Route.Replace("{Telefono}", telefono);

  public string Telefono { get; set; } = "";
}
