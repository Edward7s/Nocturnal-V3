using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal.server
{
    internal class PartyJson
    {

        public class SendInite
        {
            public string code { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }

            public string PartyId { get; set; }
        }

        public class user
        {
            public string? code { get; set; }
            public string Name { get; set; }

            public string Id { get; set; }

            public string PartyId { get; set; }
        }

        public class SendLeaderReq
        {
            public string code { get; set; }
            public string Key { get; set; }
            public string StringObject { get; set; }
            public string PartyId { get; set; }

        }

        public class SendUserReq
        {
            public string code { get; set; }
            public string Id { get; set; }
            public string StringObject { get; set; }
            public string PartyId { get; set; }

        }

        public class PartyJoin
        {
            public string PartyId { get; set; }

            public string[] PartyMembers { get; set; }

            public string[] PartyLeaders { get; set; }

        }
    }
}
