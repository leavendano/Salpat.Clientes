namespace Salpat.Clientes.UseCases.Transacciones;

public record ExportResponseDTO(string FileName, byte[] StreamContent);