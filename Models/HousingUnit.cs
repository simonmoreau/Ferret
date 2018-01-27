using System;

namespace Ferret.Models
{
    public class HousingUnit
    {
        public int Id { get; set; }
        public long sourceId {get;set;}
        public TransactionType TransactionType {get;set;}
        public HousingType HousingType{get;set;}
        public DateTime CreationDate{get;set;}
        public DateTime RefreshDate{get;set;}
        public string Description{get;set;}
        public double Price{get;set;}
        public double Area{get;set;}
        public int ConstructionYear{get;set;}
        public int RoomNumber{get;set;}
        public int BedroomNumber{get;set;}
        public int WCNumber{get;set;}
        public int BathroomNumber{get;set;}
        public int ParkingNumber{get;set;}
        public int BoxNumber{get;set;}
        public int BalconiesNumber{get;set;}
        public bool SwimmingPool{get;set;}
        public double Latitude{get;set;}
        public double Longitude {get;set;}
    }
    public enum TransactionType
    {
        buy,
        rent
    }

    public enum HousingType
    {
        appartment,
        house,
        undefined
    }
}
