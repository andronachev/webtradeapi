using System;
using System.Collections.Generic;
using System.Linq;
using WebTrade.Core.Interfaces;
using WebTrade.Core.Model;

namespace WebTrade.Infrastructure
{
    public class InMemoryBuyerRepository : IBuyerRepository
    {
        private static List<Buyer> _buyers = new List<Buyer>
        {
            new Buyer()
            {
                 Id = Guid.Parse("06698b1c-254c-4cd4-aaa4-a22859136ed1"),
                 Name = "John"
            },
            new Buyer()
            {
                 Id = Guid.Parse("a0325655-eb61-4e89-b9a2-c7b886c649ed"),
                 Name = "Alice"
            }
        };

        public Buyer[] GetAllBuyers()
        {
            return _buyers.ToArray();
        }

        public Buyer GetBuyer(Guid buyerId)
        {
            return _buyers.FirstOrDefault(b => b.Id == buyerId);
        }

        public void RegisterBuyer(Buyer buyer)
        {
            _buyers.Add(buyer);
        }
    }
}
