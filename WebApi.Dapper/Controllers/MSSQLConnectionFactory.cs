using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Dapper.Controllers
{
    public class MSSQLConnectionFactory : IDisposable
    {
        private readonly SqlConnection _database;
        private bool _disposed = false;

        public MSSQLConnectionFactory(string connectionString)
        {
            _database = new SqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            if (_database.State != ConnectionState.Open)
            {
                try
                {
                    _database.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to connect in database", ex);
                }
            }
            return _database;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _database.Close();
                    _database.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
