namespace database;


public class PersonalComputer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsTurnedOn { get; set; }
    public string OperatingSystem { get; set; }

    public PersonalComputer()
    {
        Id = Guid.NewGuid().ToString();
        Name = "Unnamed PC";
        IsTurnedOn = false;
        OperatingSystem = "Unknown";
    }
}
