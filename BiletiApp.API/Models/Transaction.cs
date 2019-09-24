using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public enum TransactionStatus {
        Available,
        Pending,
        Confirmed
    }
    public class Transaction
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}
