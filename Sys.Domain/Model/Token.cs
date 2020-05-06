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
        public TokenSession(int userId, List<ApiRoute> apiRouteList)
        {
            this.UserId = userId;
            this.ApiRouteList = apiRouteList;
        }
        public int UserId { get; set; }
        public List<ApiRoute> ApiRouteList { get; set; }
    }
}
