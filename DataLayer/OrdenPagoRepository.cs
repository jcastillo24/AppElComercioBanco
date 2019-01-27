using DataLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class OrdenPagoRepository : BaseRepository<OrdenPago>, IOrdenPagoRepository
    {
        public OrdenPagoRepository(string connectionString) : base(connectionString) { }
        

        public IEnumerable<OrdenPago> GetAll()
        {
            using (var command = new SqlCommand("select o.idordenpago,o.monto,o.moneda,o.estado,o.fechapago,o.idsucursal,s.nombre as nombresucursal from ordenpago o inner join sucursal s on (o.idsucursal=s.idsucursal)"))
            {
                return GetRecords(command);
            }
        }


        public IEnumerable<OrdenPago> GetAllBySucursalAndMoney(int idSucursal, string moneda)
        {
            using (var command = new SqlCommand("select o.idordenpago,o.monto,o.moneda,o.estado,o.fechapago,o.idsucursal,s.nombre as nombresucursal"
                                              + " from ordenpago o"
                                              + " inner join sucursal s on (o.idsucursal=s.idsucursal)"
                                              + " inner join banco b on (s.idbanco=b.idbanco)"
                                              + " where b.idbanco=(select idbanco from sucursal where idsucursal=" + idSucursal + ") and o.moneda='" + moneda + "'"))
            {
                return GetRecords(command);
            }
        }



        public OrdenPago GetById(int id)
        {
            using (var command = new SqlCommand("select o.idordenpago,o.monto,o.moneda,o.estado,o.fechapago,o.idsucursal,s.nombre as nombresucursal from ordenpago o inner join sucursal s on (o.idsucursal=s.idsucursal) where idordenpago = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        public void Insert(OrdenPago value)
        {
            using (var command = new SqlCommand("INSERT INTO ordenpago (monto,moneda,estado,fechapago,idsucursal) Values (@monto,@moneda,@estado,@fechapago,@idsucursal)"))
            {
                command.Parameters.AddWithValue("@monto", value.Monto ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@moneda", value.Moneda ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@estado", value.Estado ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fechapago", value.FechaPago ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@idsucursal", value.SucursalId);
                ExecuteNonQuery(command);
            }
        }

        public void Update(int id, OrdenPago value)
        {
            using (var command = new SqlCommand("Update ordenpago SET [monto]=@monto,[moneda]=@moneda,[estado]=@estado,[fechapago]=@fechapago,[idsucursal]=@idsucursal where [idordenpago]=@id"))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@monto", value.Monto ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@moneda", value.Moneda ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@estado", value.Estado ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fechapago", value.FechaPago ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@idsucursal", value.SucursalId);
                ExecuteNonQuery(command);
            }
        }
        public void Delete(int id)
        {
            using (var command = new SqlCommand("delete from ordenpago where idordenpago=@id"))
            {
                command.Parameters.AddWithValue("@id", id);
                ExecuteNonQuery(command);
            }
        }

        public override OrdenPago PopulateRecord(SqlDataReader reader)
        {
            return new OrdenPago
            {
                Id = reader.GetInt32(0),
                Monto = reader.GetDecimal(1),
                Moneda = reader.GetString(2),
                Estado = reader.GetString(3),
                FechaPago = reader.GetDateTime(4),
                SucursalId = reader.GetInt32(5),
                Sucursal = new Sucursal { Nombre = reader.GetString(6) }
            };
        }



    }
}
