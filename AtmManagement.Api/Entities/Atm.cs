using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtmManagement.Api.Entities
{
    public class Atm
    {
        public int ID { get; set; }

        public string AtmName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool IsActive { get; set; }

        public int CityID { get; set; } // CityID'yi foreign key olarak tanımlayın

        public int DistrictID { get; set; } // DistrictID'yi foreign key olarak tanımlayın

        public virtual City City { get; set; } // City modeline ilişkiyi temsil eden navigasyon özelliği

        public virtual District District { get; set; } // District modeline ilişkiyi temsil eden navigasyon özelliği

        
    }
}
