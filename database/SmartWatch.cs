namespace database;
public class SmartWatch
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsTurnedOn { get; set; }
    public int BatteryLevel { get; set; }

    public SmartWatch()
    {
        Id = Guid.NewGuid().ToString();
        Name = "Unnamed SmartWatch";
        IsTurnedOn = false;
        BatteryLevel = 100;
    }
}
