using LibraryCore.Enums;
using System;

namespace LibraryCore.Domain.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Enum Status { get; set; }
    }
}
