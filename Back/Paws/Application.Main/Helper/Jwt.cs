using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Helper
{
    public class Jwt
    {
        public string OriginCors { get; set; }
        public string Secret { get; set; }
        public string IsSuer { get; set; }
        public string Audience { get; set; }
    }
}
