namespace finalPerezAlvarez.Web.Models;

public class Transaccion
{
    public int id { get; set; }
    public int idCuenta { get; set; } // siempre enviar
    public DateTime fecha { get; set; }
    public string descripcion { get; set; }
    public decimal monto { get; set; }
    public string tipo { get; set; }
}