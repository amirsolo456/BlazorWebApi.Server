using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities.Shared
{
    public class MessageReplays
    {
        public Messages message { get; set; }
        public IEnumerable<Messages>? replays { get; set; }

    }
}
