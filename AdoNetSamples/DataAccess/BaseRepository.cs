using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class BaseRepository
    {
        protected readonly SqlConnection Connection;

        protected BaseRepository(SqlConnection connection)
        {
            this.Connection = connection;
        }
    }
}
