using System;

namespace MyFriends.DataModel
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    }
}