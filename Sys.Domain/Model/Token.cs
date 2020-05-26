using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class TokenSession
    {
        public TokenSession() { }
        public TokenSession(int userId)
        {
            this.UserId = userId;
        }
        public int UserId { get; set; }
    }
}
