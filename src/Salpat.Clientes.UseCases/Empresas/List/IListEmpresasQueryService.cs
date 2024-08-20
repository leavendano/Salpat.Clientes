namespace Salpat.Clientes.UseCases.Empresas.List;

public interface IListEmpresasQueryService
{
     Task<IEnumerable<EmpresaDTO>> ListAsync();
}