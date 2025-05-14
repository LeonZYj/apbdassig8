namespace database;

public class EmbeddedDevice : Device
{
    public string IpAddress { get; set; }
    public string NetworkName { get; set; }

    public EmbeddedDevice()
    {
        IpAddress = "0.0.0.0";
        NetworkName = "Unknown";
    }
}
