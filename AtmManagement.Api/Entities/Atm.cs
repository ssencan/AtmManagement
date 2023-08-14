namespace AtmManagement.Api.Entities
{
    public class Atm
    {
        public int ID { get; set; }

        public string AtmName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool IsActive { get; set; }

        public int CityID { get; set; } 

        public int DistrictID { get; set; }

        public virtual City City { get; set; } // ATM'nin bulunduğu şehri temsil eden navigasyon özelliği.

        public virtual District District { get; set; } // ATM'nin bulunduğu ilçeyi temsil eden navigasyon özelliği.


    }
}
