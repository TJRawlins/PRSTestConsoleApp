using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSTestConsoleApp {
    public class User {
        public int Id { get; set; }
        [StringLength(30)]
        public string Username { get; set; } = string.Empty;
        [StringLength(30)]
        public string Password { get; set; } = string.Empty;
        [StringLength(30)]
        public string Firstname { get; set; } = string.Empty;
        [StringLength(30)]
        public string Lastname { get; set; } = string.Empty;
        [StringLength(12)]
        public string? Phone { get; set; }
        [StringLength(255)]
        public string? Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }
    }
}
