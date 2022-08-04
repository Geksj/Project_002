using System;

namespace Project_002.Core
{
    internal class BankAccount
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int Balance { get; set; }
        public bool Status { get; set; }
        public int IdPerson { get; set; }

        public BankAccount(int Id, string Number, string Type, int Balance, bool Status, int IdPerson)
        {
            this.Id = Id;
            this.Number = Number;
            this.Type = Type;
            this.Balance = Balance;
            this.Status = Status;
            this.IdPerson = IdPerson;
        }
    }
}
