namespace AtmManagement.Api.Dtos
{
    public class AtmDto
    {
        public int Id { get; set; }
        public string AtmName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
    }
}
