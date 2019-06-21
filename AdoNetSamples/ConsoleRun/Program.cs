using DataAccess;
using DataAccess.Connection.SqlServer;
using Entities;

namespace ConsoleRun
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionManager.GetConnection();

            var userRepository = new UserRepository(connection);

            User user = new User { Email = "andrei@email.com", Name = "Andrei 2", UserName = "and 2" };
            var id = userRepository.Insert(user);

            System.Console.WriteLine($"inserted user with {id}");

            var savedUser = userRepository.Read(id);
            savedUser.Print();
        }
    }
}
