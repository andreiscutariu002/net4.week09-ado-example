using System;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(SqlConnection connection) : base(connection)
        {
        }

        public int Insert(User user)
        {
            const string query = "insert into users (name, username, email) values (@name, @username, @email); select cast(scope_identity() as int);";

            SqlParameter name = new SqlParameter("@name", System.Data.DbType.String)
            {
                Value = user.Name
            };

            SqlParameter username = new SqlParameter("@username", System.Data.DbType.String)
            {
                Value = user.UserName
            };

            SqlParameter email = new SqlParameter("@email", System.Data.DbType.String)
            {
                Value = user.Email
            };

            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(name);
            command.Parameters.Add(username);
            command.Parameters.Add(email);

            return (int)command.ExecuteScalar();
        }

        public User Read(int id)
        {
            string query = $"select * from users where id = @id";

            SqlParameter idParam = new SqlParameter("@id", System.Data.DbType.Int32)
            {
                Value = id
            };

            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(idParam);

            var reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                reader.Read();

                // todo check for null
                var userId = (int) reader["id"];
                var name = reader["name"] as string;
                var userName = reader["username"] as string;
                var email = reader["email"] as string;

                return new User
                {
                    Email = email,
                    Name = name,
                    UserName = userName
                };
            }
            else
            {
                throw new InvalidOperationException($"User with {id} does not exits!");
            }
        }

        public void Update(int id, User user)
        {
            // todo
        }

        public void Delete(int id)
        {
            // todo
        }
    }
}
