﻿using System.ComponentModel.DataAnnotations;

namespace Salpat.Clientes.Web.Transacciones;

public class CreateTransaccionRequest
{
  public const string Route = "/Api/Transacciones";

  [Required]
  public int HoseDeliveryId { get; set; }
  [Required]
  public int ClienteId { get; set; }
  [Required]
  public int EstacionId { get; set; }
  [Required]
  public int Posicion { get; set; }
  [Required]
  public DateTime Fecha { get; set; }
  [Required]
  public decimal Importe { get; set; }
  [Required]
  public decimal Volumen {  get; set; }
  [Required]
  public int ProductoId { get; set; }

}
