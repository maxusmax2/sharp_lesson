public class Role
{
    public Role() { }
    public Role(int id, string name) 
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Page> AllowedPages { get; set; }
    public override int GetHashCode() => this.Id;
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }
        Role other = (Role)obj;
        return Id == other.Id;
    }
}

