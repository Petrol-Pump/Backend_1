namespace Petrol_Pump1.ModelPostgres
{
    public class User
    {
        public string UserName { get; set; } = string.Empty;

        public byte[] PasswordHarsh { get; set; }   
        public byte[] PasswordSalt { get; set; }
    }
}
