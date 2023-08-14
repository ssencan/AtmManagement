namespace AtmManagement.Api.Entities

{
    public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public int PlateNumber { get; set; }

        public virtual ICollection<District> Districts { get; set; } 
        public virtual ICollection<Atm> Atms { get; set; }

    }
}

