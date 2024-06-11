
```mermaid
erDiagram
    CLIENTE ||--o{ TRANSACCION : places
    CLIENTE {
        string Nombre
        string Telefono
        string Email
    }
    TRANSACCION ||--|{ LINE-ITEM : contains
    TRANSACCION {
        int id
        DateTime Fecha
        decimal Cantidad
        decimal Importe
        int PuntosGanados
    }
    LINE-ITEM {
        string productCode
        int quantity
        float pricePerUnit
    }

```