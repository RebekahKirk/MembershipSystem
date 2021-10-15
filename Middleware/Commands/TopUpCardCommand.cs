using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Middleware.Commands
{
    public class TopUpCardCommand : BaseCommand
    {
        public string Pin { get; set; }
        public string CardId { get; set; }
        public string Balance { get; set; }
        public string Amount { get; set; }
    }
}
