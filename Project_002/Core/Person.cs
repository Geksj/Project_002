using System;

namespace Project_002.Core
{
    internal class Person
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public Person(int Id, string Surname, string FirstName, string SecondName)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
        }
    }
}
