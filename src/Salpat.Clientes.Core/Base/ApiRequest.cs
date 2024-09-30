

namespace Salpat.Clientes.Core.Base;

  public class ApiRequest(string token, string url, object? parameters, string apiType = "POST")
{
  public string ApiType { get; set; } = apiType;
  public string Url { get; set; } = url;
  public object? Parameters { get; set; } = parameters;
  public string AccessToken { get; set; } = token;

}
