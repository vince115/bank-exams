public static class Config {
    public const string ConnString =
    "Server=localhost,1433;Database=BankDb;User ID=sa;Password=Pass@123456;Encrypt=True;TrustServerCertificate=True;";
}
public class OverdraftException : Exception { public OverdraftException(string m) : base(m) {} }
