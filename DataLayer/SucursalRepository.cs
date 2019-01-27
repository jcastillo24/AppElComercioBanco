using DataLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class SucursalRepository : BaseRepository<Sucursal>, ISucursalRepository
    {

        public SucursalRepository(string connectionString) : base(connectionString) { }

        public IEnumerable<Sucursal> GetAll()
        {
            using (var command = new SqlCommand("select s.idsucursal,s.nombre,s.direccion,s.fecharegistro,s.idbanco,b.nombre as nombrebanco from sucursal s inner join banco b on (s.idbanco=b.idbanco) "))
            {
                return GetRecords(command);
            }
        }
        public IEnumerable<Sucursal> GetAllByIdBanco(int idBanco)
        {
            using (var command = new SqlCommand("select s.idsucursal,s.nombre,s.direccion,s.fecharegistro,s.idbanco,b.nombre as nombrebanco from sucursal s inner join banco b on (s.idbanco=b.idbanco) where b.idbanco=" + idBanco))
            {
                return GetRecords(command);
            }
        }

        public Sucursal GetById(int id)
        {
            using (var command = new SqlCommand("select s.idsucursal,s.nombre,s.direccion,s.fecharegistro,s.idbanco,b.nombre as nombrebanco FROM sucursal s inner join banco b on (s.idbanco=b.idbanco) WHERE s.idsucursal= @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        public void Insert(Sucursal value)
        {
            using (var command = new SqlCommand("INSERT INTO sucursal (nombre,direccion,fecharegistro,idbanco) Values (@nombre,@direccion,@fecharegistro,@idbanco)"))
            {
                command.Parameters.AddWithValue("@nombre", value.Nombre ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@direccion", value.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fecharegistro", value.FechaRegistro ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@idbanco", value.BancoId);
                ExecuteNonQuery(command);
            }
        }

        public void Update(int id, Sucursal value)
        {
            using (var command = new SqlCommand("Update sucursal SET nombre=@nombre,direccion=@direccion,fecharegistro=@fecharegistro,idbanco=@idbanco where idsucursal=@id"))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", value.Nombre ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@direccion", value.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fecharegistro", value.FechaRegistro ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@idbanco", value.BancoId);
                ExecuteNonQuery(command);
            }
        }
        public void Delete(int id)
        {
            using (var command = new SqlCommand("DELETE FROM sucursal WHERE idsucursal=@id"))
            {
                command.Parameters.AddWithValue("@id", id);
                ExecuteNonQuery(command);
            }
        } 
        public override Sucursal PopulateRecord(SqlDataReader reader)
        {
            return new Sucursal
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Direccion = reader.GetString(2),
                FechaRegistro = reader.GetDateTime(3),
                BancoId = reader.GetInt32(4),
                Banco = new Banco { Nombre = reader.GetString(5) }
            };
        }


    }
}
