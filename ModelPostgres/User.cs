namespace Petrol_Pump1.ModelPostgres
{
    public class User
    {
        public decimal UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string Role { get; set; }

        public byte[] PasswordHarsh { get; set; }   
        public byte[] PasswordSalt { get; set; }
    }
}
