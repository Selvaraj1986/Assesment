using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class LoginModel
    {
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class LoginParameter
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
