using Entities.Common;

namespace Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public void Print()
        {
            System.Console.WriteLine($"{Name}, {UserName}, {Email}");
        }
    }
}
