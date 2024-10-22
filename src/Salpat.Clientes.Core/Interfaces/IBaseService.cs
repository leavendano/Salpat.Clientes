
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.Interfaces;

  public interface IBaseService :  IDisposable
  {
      
      Task<ApiResponse<T>> SendAsync<T>(ApiRequest apiRequest) where T: class;
  }
