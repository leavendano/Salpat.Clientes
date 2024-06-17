
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.RecompensaAgreggate;
public class Recompensa(string descripcion, int puntosRequeridos) : RegisterBase, IAggregateRoot
{
    public string Descripcion { get; private set; } = Guard.Against.NullOrEmpty(descripcion, nameof(descripcion));
    public int PuntosRequeridos { get; private set; } = Guard.Against.NegativeOrZero(puntosRequeridos, nameof(puntosRequeridos));

    public void UpdatePuntos(int puntos)
    {
        this.PuntosRequeridos = Guard.Against.NegativeOrZero(puntos, nameof(puntos));
    }  

    public void UpdateDescripcion(string descripcion)
    {
        this.Descripcion = Guard.Against.NullOrEmpty(descripcion, nameof(descripcion));
    }  

}