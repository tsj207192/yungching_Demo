using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yungching_Demo.Areas.Hotel.ViewModels
{
    public class Product
    {
        public Project Project { get; set; }
        public Room Room { get; set; }
        public Price Price { get; set; }
    }

    public class Project
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }

    }

    public class Room
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomDesc { get; set; }

    }

    public class Price
    {
        public string Curr { get; set; }
        public decimal Amount { get; set; }
    }
}