using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Middleware.Entities
{
    public class SpendOnCard
    {
        public string Pin { get; set; }
        public string CardId { get; set; }
        public string Balance { get; set; }
    }
}
