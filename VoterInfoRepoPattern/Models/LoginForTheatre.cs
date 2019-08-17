using System;
using System.Collections.Generic;

namespace VoterInfoRepoPattern.Models
{
    public partial class LoginForTheatre
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
