public class Login
{
    public int Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public string IpAddress { get; set; }
    public string DeviceSetting { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public override int GetHashCode() => this.Id;
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }
        Login other = (Login)obj;
        return Id == other.Id;
    }
}

