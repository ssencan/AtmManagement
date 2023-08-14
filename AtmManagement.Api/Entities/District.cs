namespace AtmManagement.Api.Entities
{
    public class District
    {
       
        public int ID { get; set; }
        public string DistrictName { get; set; }

        public int CityID { get; set; } // CityID'yi foreign key olarak tanımlayın

       
        public virtual City City { get; set; } // İlişkiyi temsil eden navigasyon özelliği

        
        public virtual ICollection<Atm> Atms { get; set; } //İlçeye ait ATM'lerin koleksiyonunu temsil eder.

    }
}
