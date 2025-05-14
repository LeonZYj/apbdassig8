using database;
using Repository;

namespace Service1;

public class Service : IService
{
    private readonly IRepository _repo;

    public Service(IRepository repo)
    {
        _repo = repo;
    }
    
    public IEnumerable<PersonalComputer> GetAllPersonalComputers() => _repo.GetAllPersonalComputers();

    public PersonalComputer GetPersonalComputerById(string id) => _repo.GetPersonalComputerID(id);

    public bool AddPersonalComputer(PersonalComputer computer)
    {
        if (string.IsNullOrWhiteSpace(computer.Name) || string.IsNullOrWhiteSpace(computer.OperatingSystem))
            return false;

        return _repo.AddPersonalComputer(computer);
    }

    public bool UpdatePersonalComputer(PersonalComputer computer)
    {
        if (string.IsNullOrWhiteSpace(computer.Name))
            return false;

        return _repo.UpdatePersonalComputer(computer);
    }

    public bool DeletePersonalComputer(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return false;

        return _repo.DeletePersonalComputer(id);
    }
    
    public IEnumerable<SmartWatch> GetAllSmartWatches() => _repo.GetAllSmartWatches();

    public SmartWatch GetSmartWatchById(string id) => _repo.GetSmartWatchID(id);

    public bool AddSmartWatch(SmartWatch watch)
    {
        if (string.IsNullOrWhiteSpace(watch.Name))
            return false;

        return _repo.AddSmartWatch(watch);
    }

    public bool UpdateSmartWatch(SmartWatch watch)
    {
        if (string.IsNullOrWhiteSpace(watch.Name))
            return false;

        return _repo.UpdateSmartWatch(watch);
    }

    public bool DeleteSmartWatch(string id) => _repo.DeleteSmartWatch(id);
    
    public IEnumerable<EmbeddedDevice> GetAllEmbeddedDevices() => _repo.GetAllEmbeddedDevices();

    public EmbeddedDevice GetEmbeddedDeviceById(string id) => _repo.GetEmbeddedDeviceID(id);

    public bool AddEmbeddedDevice(EmbeddedDevice device)
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return false;

        return _repo.AddEmbeddedDevice(device);
    }

    public bool UpdateEmbeddedDevice(EmbeddedDevice device)
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return false;

        return _repo.UpdateEmbeddedDevice(device);
    }

    public bool DeleteEmbeddedDevice(string id) => _repo.DeleteEmbeddedDevice(id);
    
    public IEnumerable<DeviceNonAbstractClass> GetAllDevices() => _repo.GetAllDevices();

    public DeviceNonAbstractClass GetDeviceById(string id) => _repo.GetDeviceID(id);

    public bool AddDevice(DeviceNonAbstractClass device)
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return false;

        return _repo.AddDevice(device);
    }

    public bool UpdateDevice(DeviceNonAbstractClass device)
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return false;

        return _repo.UpdateDevice(device);
    }

    public bool DeleteDevice(string id) => _repo.DeleteDevice(id);
}