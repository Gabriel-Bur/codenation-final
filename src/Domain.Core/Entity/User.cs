using System;

namespace Domain.Core.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User() {}

        public User(Guid id, string name, string email, string password) : base(id)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
}
