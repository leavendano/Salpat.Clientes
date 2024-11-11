using System.Data;
using System.Text;
using System.Text.Json;
using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.Base;
using Salpat.Clientes.UseCases.Transacciones;
using Salpat.Clientes.UseCases.Transacciones.List;

namespace Salpat.Clientes.Infrastructure.Data.Queries;
public class ListTransaccionesQueryService(AppDbContext _db,IHttpClientFactory _httpClient) : IListTransaccionesQueryService
{
  
  public async Task<IEnumerable<TransaccionDTO>> ListAsync(int? EstacionId,DateTime? FechaInicial, DateTime? Fechafinal,int? ClienteId)
  {
    var result = await _db.Database.SqlQuery<TransaccionDTO>(
      $@"SELECT id,t.estacion_id, t.hose_delivery_id, t.fecha,t.posicion,t.producto_id, t.importe, t.volumen, t.cliente_id, t.puntos 
          FROM transacciones t
          WHERE 1= 1 
          and ( {FechaInicial} is null or fecha >= {FechaInicial}) 
          and ( {Fechafinal} is null or fecha <= {Fechafinal})
          and  ({EstacionId}::int is null or estacion_id = {EstacionId})
          and  ({ClienteId}::int is null or cliente_id = {ClienteId})")
      .ToListAsync();

    return result;
  }


  public async Task<IEnumerable<TransaccionConsultaDTO>> ListConsultaAsync(int? EstacionId,DateTime? FechaInicial, DateTime? Fechafinal)
  {
    var result = await _db.Database.SqlQuery<TransaccionConsultaDTO>(
      $@"SELECT t.id,t.estacion_id, s.nombre as nombre_estacion, t.hose_delivery_id, t.fecha,t.posicion,t.producto_id , t.importe, t.volumen,
          t.cliente_id, c.nombre as nombre_cliente,c.empresa_id,e.nombre as nombre_empresa, t.puntos,
          CASE WHEN t.producto_id = 1 THEN 'MAGNA' WHEN t.producto_id = 2 THEN 'PREMIUM' WHEN t.producto_id = 3 THEN 'DIESEL' END AS nombre_producto 
          FROM transacciones t 
          LEFT JOIN clientes c ON c.id = t.cliente_id
          LEFT JOIN empresas e ON e.id = c.empresa_id
          LEFT JOIN estaciones s ON s.id = t.estacion_id
          WHERE 1= 1 
          and ( {FechaInicial} is null or t.fecha >= {FechaInicial}) 
          and ( {Fechafinal} is null or t.fecha <= {Fechafinal})
          and  ({EstacionId}::int is null or estacion_id = {EstacionId})")
      .ToListAsync();

    return result;
  }


  public async Task<Result<ExportResponseDTO>> ExportAsync(string Tipo,int? EstacionId,DateTime? FechaInicial, DateTime? Fechafinal)
  {
    var result = await _db.Database.SqlQuery<TransaccionConsultaDTO>(
      $@"SELECT t.id,t.estacion_id, s.nombre as nombre_estacion, t.hose_delivery_id, t.fecha,t.posicion,t.producto_id , t.importe, t.volumen,
          t.cliente_id, c.nombre as nombre_cliente,c.empresa_id,e.nombre as nombre_empresa, t.puntos,
          CASE WHEN t.producto_id = 1 THEN 'MAGNA' WHEN t.producto_id = 2 THEN 'PREMIUM' WHEN t.producto_id = 3 THEN 'DIESEL' END AS nombre_producto 
          FROM transacciones t 
          LEFT JOIN clientes c ON c.id = t.cliente_id
          LEFT JOIN empresas e ON e.id = c.empresa_id
          LEFT JOIN estaciones s ON s.id = t.estacion_id
          WHERE 1= 1 
          and ( {FechaInicial} is null or t.fecha >= {FechaInicial}) 
          and ( {Fechafinal} is null or t.fecha <= {Fechafinal})
          and  ({EstacionId}::int is null or estacion_id = {EstacionId})")
      .ToListAsync();

      string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
      Byte[] bytes = File.ReadAllBytes(rootpath + "/Transacciones.rdlc");
      String fileRdlc = Convert.ToBase64String(bytes);
      IEnumerable<ParamDTO> parametros = new List<ParamDTO>(){
          new ParamDTO("NombreEstacionParameter","Grupo Salpat"),
          new ParamDTO("NombreSucursalParameter","    ") 
      };
      
     
      
      IEnumerable<ExportData> exportData = new List<ExportData>(){
        new ExportData( "Transacciones",result)
      };
      ExportServiceRequest dataRequest = new ExportServiceRequest("Transacciones",Tipo, fileRdlc, parametros, exportData);
      try
        {
          string url = "http://localhost:5000";
      using var client = _httpClient.CreateClient("ReportAPI");
      HttpRequestMessage message = new HttpRequestMessage();
      message.Headers.Add("Accept", "application/json");
      message.RequestUri = new Uri(url + $"/report");
      client.DefaultRequestHeaders.Clear();
      var jsonText = JsonSerializer.Serialize(dataRequest);
      message.Content = new StringContent(jsonText, Encoding.UTF8, "application/json");
      message.Method = HttpMethod.Post;

      var apiResponse = await client.SendAsync(message);
      apiResponse.EnsureSuccessStatusCode();
      var apiContent = await apiResponse.Content.ReadAsByteArrayAsync();

      var filename = apiResponse?.Content?.Headers?.ContentDisposition?.FileName;
      if (!string.IsNullOrEmpty(filename))
      {
        return Result.Success(new ExportResponseDTO(filename, apiContent));

      }
      else
      {
        return Result.Error("No se logró optener el archivo");
      }
    }
    catch (Exception e)
    {
      return Result.Error(e.Message);
    }

  }

   public void Dispose()
  {
            GC.SuppressFinalize(true);
  }
}
