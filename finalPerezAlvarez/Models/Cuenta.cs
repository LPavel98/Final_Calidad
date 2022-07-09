namespace finalPerezAlvarez.Web.Models;

public class Cuenta
{
    public int id { get; set; } 
    public string nombre { get; set; }
    public string categoria { get; set; }
    public decimal saldoInicial { get; set; }
    public string moneda { get; set; }
    public int tipoCuentaId { get; set; }
    public TipoCuenta? TipoCuenta {get; set; }

}