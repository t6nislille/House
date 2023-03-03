﻿namespace ProjectHouse.Models.House
{
    public class HouseIndexViewModel
    {
        public Guid? id { get; set; }
        public int Size { get; set; }
        public int NumberOfFloors { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfBedrooms { get; set; }

        // Only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}