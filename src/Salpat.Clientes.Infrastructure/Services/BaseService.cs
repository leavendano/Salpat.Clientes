using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Salpat.Clientes.Core.Base;
using Salpat.Clientes.Core.Interfaces;



namespace Salpat.Clientes.Infrastructure.Services;

  public class BaseService :  IBaseService
  {                
      private IHttpClientFactory _httpClient;

      public BaseService(IHttpClientFactory httpClient)
      {
          this._httpClient = httpClient;
      }
     
      public async Task<ApiResponse<T>> SendAsync<T>(ApiRequest apiRequest) where T : class
      {
          try
          {
              if(apiRequest == null || string.IsNullOrEmpty(apiRequest.Url))
              {
                  throw new InvalidOperationException("el objeto request no puede ser nulo");
              }
              var client = _httpClient.CreateClient("WebAPI");
              HttpRequestMessage message = new HttpRequestMessage();
              message.Headers.Add("Accept", "application/json");
              message.RequestUri = new Uri(apiRequest.Url);
              client.DefaultRequestHeaders.Clear();
              if (apiRequest.Parameters != null)
              {
                message.Content = new StringContent(JsonSerializer.Serialize(apiRequest.Parameters),
                    Encoding.UTF8, "application/json");   
              }

              if (!string.IsNullOrEmpty(apiRequest.AccessToken))
              {
                  var token = apiRequest.AccessToken.Split(' ');
                  var AccesToken = token.Length > 1 ? token[1] : token[0];
                  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccesToken);
              }

              HttpResponseMessage? apiResponse = null;
              switch (apiRequest.ApiType)
              {
                  case "POST":
                      message.Method = HttpMethod.Post;
                      break;
                  case "PUT":
                      message.Method = HttpMethod.Put;
                      break;
                  case "DELETE":
                      message.Method = HttpMethod.Delete;
                      break;
                  default:
                      message.Method = HttpMethod.Get;
                      break;
              }
              apiResponse = await client.SendAsync(message);

              var apiContent = await apiResponse.Content.ReadAsStringAsync();
              var apiResponseDto = JsonSerializer.Deserialize<ApiResponse<T>>(apiContent);
              if (apiResponseDto != null)
              {
                  apiResponseDto.Data ??= Array.Empty<T>();
                  return apiResponseDto;
              }
              else
              {
                  throw new InvalidOperationException("Se obtuvo una respuesta nula");
              }
          }
          catch (Exception e)
          {
              var dto = new ApiResponse<T>
              {
                  Success = false,
                  Error = e.Message,
                  Data = default
              };
             
              return dto;
          }
      }

      public void Dispose()
      {
          GC.SuppressFinalize(true);
      }
  }
