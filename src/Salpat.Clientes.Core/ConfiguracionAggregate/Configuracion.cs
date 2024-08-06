using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.ConfiguracionAggregate;
public class Configuracion : RegisterBase, IAggregateRoot
{
    public string MailHost { get; set; } = "mx.localhost";
    public string MailPort { get; set; } = "465"; 
    public string MailUsername { get; set; } = "username";
    public string MailPassword { get; set; } = "password";
    public string MailAddress { get; set; } = "address@localhost";

    public int TiempoMinimoEntreCargas { get; set; } = 1;

}
