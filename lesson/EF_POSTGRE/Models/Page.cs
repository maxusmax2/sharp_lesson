public class Page
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string URL { get; set; }
    public virtual ICollection<User>? AllowedUsers { get; set; }
    public virtual ICollection<Role>? AllowedRoles { get; set; }
    
    public override int GetHashCode() => this.Id;
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }
        Page other = (Page)obj;
        return Id == other.Id;
    }
}
