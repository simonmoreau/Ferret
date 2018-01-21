using System;

namespace Ferret.Models
{
    public class HousingUnit
    {
        public long Id { get; set; }
        public TransactionType TransactionType {get;set;}
        public HousingType HousingType{get;set;}
        public DateTime CreationDate{get;set;}
        public DateTime RefreshDate{get;set;}
        public string Description{get;set;}
        public double Price{get;set;}
        public double Area{get;set;}
        public Coordinates Coordinates{get;set;}
        public int ConstructionYear{get;set;}
        public int RoomNumber{get;set;}
        public int BedroomNumber{get;set;}
        public int WCNumber{get;set;}
        public int BathroomNumber{get;set;}
        public int ParkingNumber{get;set;}
        public int BoxNumber{get;set;}
        public int BalconiesNumber{get;set;}
        public bool SwimmingPool{get;set;}
    }

    public class Coordinates
    {
        public Coordinates(double latitude,double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = Longitude;
        }
        public double Latitude{get;}
        public double Longitude{get;}
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
