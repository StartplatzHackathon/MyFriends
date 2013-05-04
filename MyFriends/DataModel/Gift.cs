using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFriends.DataModel
{
    public class Gift
    {
        public Gift()
        {
            Id = Guid.NewGuid();
            Categories = new List<string>();
            CreatedUtc = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PlaceName { get; set; }

        public GPSPosition Position { get; set; }

        public decimal Price { get; set; }

        public Uri Url { get; set; }

        public IList<string> Categories { get; private set; }

        public DateTime CreatedUtc { get; private set; }
    }
}