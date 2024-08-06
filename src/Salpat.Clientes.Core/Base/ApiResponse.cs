using System.Text.Json.Serialization;


namespace Salpat.Clientes.Core.Base;

  public class ApiResponse<T> where T : class
  {
      private IEnumerable<T> _data = Array.Empty<T>();

      [JsonPropertyName("success")]
      public bool Success { get; set; } = true;


      [JsonPropertyName("error")]
      public string Error { get; set; } = "";


      [JsonPropertyName("data")]
      public IEnumerable<T>? Data
      {
          get
          {
              return _data;
          }
          set
          {
              _data = value ?? Array.Empty<T>();
          }
      }
  }
