using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal.server
{
    internal class PartyJson
    {
        public class user
        {
            public string Name { get; set; }

            public string Id { get; set; }
        }

        public class SendLeaderReq
        {
            public string Code { get; set; }
            public string Key { get; set; }
            public string StringObject { get; set; }

        }

        public class SendUserReq
        {
            public string Code { get; set; }
            public string Id { get; set; }
            public string StringObject { get; set; }

        }
    }
}
