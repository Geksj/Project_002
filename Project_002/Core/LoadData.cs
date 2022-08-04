using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Project_002.Core
{
    internal class LoadData
    {
        static string json;
        public static List<BankAccount> LoadDataBankAccount()
        {
            List<BankAccount> bankAccountGroup = new List<BankAccount>();
            json = File.ReadAllText("_bankAccount.json");
            bankAccountGroup = JsonConvert.DeserializeObject<List<BankAccount>>(json);
            return bankAccountGroup;
        }
        public static List<Person> LoadDataPerson()
        {
            List<Person> personGroup = new List<Person>();
            json = File.ReadAllText("_bankAccount.json");
            personGroup = JsonConvert.DeserializeObject<List<Person>>(json);
            return personGroup;
        }
    }
}
