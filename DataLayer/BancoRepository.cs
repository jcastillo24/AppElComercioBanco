using DataLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class BancoRepository : BaseRepository<Banco>, IBancoRepository
    {
        public BancoRepository(string connectionString)
           : base(connectionString)
        {
        }
        public IEnumerable<Banco> GetAll()
        {
            using (var command = new SqlCommand("SELECT * FROM banco"))
            {
                return GetRecords(command);
            }
        }
        public Banco GetById(int id)
        {
            using (var command = new SqlCommand("SELECT * FROM banco WHERE idbanco = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        public void Insert(Banco value)
        {
            using (var command = new SqlCommand("INSERT INTO banco (nombre,direccion,fecharegistro) VALUES (@nombre,@direccion,@fecharegistro)"))
            {
                command.Parameters.AddWithValue("@nombre", value.Nombre ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@direccion", value.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fecharegistro", value.FechaRegistro ?? (object)DBNull.Value);
                ExecuteNonQuery(command);
            }
        }

        public void Update(int id, Banco value)
        {
            using (var command = new SqlCommand("Update banco SET [nombre]=@nombre,[direccion]=@direccion,[fecharegistro]=@fecharegistro WHERE [idbanco]=@id"))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", value.Nombre ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@direccion", value.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fecharegistro", value.FechaRegistro ?? (object)DBNull.Value);
                ExecuteNonQuery(command);
            }
        }

        public void Delete(int id)
        {
            using (var command = new SqlCommand("DELETE FROM banco WHERE idbanco=@id"))
            {
                command.Parameters.AddWithValue("@id", id);
               
                ExecuteNonQuery(command);
            }
        }

        public override Banco PopulateRecord(SqlDataReader reader)
        {
            return new Banco
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Direccion = reader.GetString(2),
                FechaRegistro = reader.GetDateTime(3)
            };
        }

    }
}
