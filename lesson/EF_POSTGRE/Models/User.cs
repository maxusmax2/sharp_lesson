public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public string Login { get; set; }
    public virtual ICollection<Role> Roles { get; set; }

    public virtual ICollection<Page> AllowedPages { get; set; }

    public override int GetHashCode() => Id;
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }
        User other = (User)obj;
        return Id == other.Id;   
    }
}

