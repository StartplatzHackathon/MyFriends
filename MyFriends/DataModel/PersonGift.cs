using System;

namespace MyFriends.DataModel
{
    public class PersonGift
    {
        public Gift Gift { get; set; }
        public Person Person { get; set; }
        public string Occasion { get; set; }
        public DateTime OccasionDateUtc { get; set; }
        public string Remark { get; set; }
    }
}