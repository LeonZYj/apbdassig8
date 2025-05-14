namespace database;
public class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsTurnedOn { get; set; }

    public Device()
    {
        Id = Guid.NewGuid().ToString();
        Name = "Unnamed Device";
        IsTurnedOn = false;
    }
}
