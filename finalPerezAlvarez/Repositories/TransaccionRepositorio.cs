using finalPerezAlvarez.Web.Models;
using finalPerezAlvarez.Web.DB;
using Microsoft.EntityFrameworkCore;

namespace finalPerezAlvarez.Web.Repositories
{
    public interface ITransaccionRepositorio
    {
        List<Transaccion> ListaCuentaTransacciones(int cuentaId);
    }

    public class TransaccionRepositorio : ITransaccionRepositorio
    {
        private DbEntities _dbEntities;

        public TransaccionRepositorio(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public List<Transaccion> ListaCuentaTransacciones(int cuentaId)
        {
            return DbEntities.Transacciones.Where(o => o.idCuenta == cuentaId).ToList();
        }
    }
}