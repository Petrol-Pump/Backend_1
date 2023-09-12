using System.ComponentModel.DataAnnotations;

namespace Petrol_Pump1.ModelPostgres
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Role { get; set; }

        public byte[] PasswordHarsh { get; set; }   
        public byte[] PasswordSalt { get; set; }
    }
}
