using System.Data.SqlClient;

namespace DataAccess
{
    public class PostRepository : BaseRepository
    {
        public PostRepository(SqlConnection connection) : base(connection)
        {
        }

        // TODO - Same as UserRepository
    }
}
