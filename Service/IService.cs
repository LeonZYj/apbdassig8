using database;

namespace Service1;

public interface IService
{
    IEnumerable<PersonalComputer> GetAllPersonalComputers();
    PersonalComputer GetPersonalComputerById(string id);
    bool AddPersonalComputer(PersonalComputer computer);
    bool UpdatePersonalComputer(PersonalComputer computer);
    bool DeletePersonalComputer(string id);
    
    IEnumerable<SmartWatch> GetAllSmartWatches();
    SmartWatch GetSmartWatchById(string id);
    bool AddSmartWatch(SmartWatch watch);
    bool UpdateSmartWatch(SmartWatch watch);
    bool DeleteSmartWatch(string id);
    
    IEnumerable<EmbeddedDevice> GetAllEmbeddedDevices();
    EmbeddedDevice GetEmbeddedDeviceById(string id);
    bool AddEmbeddedDevice(EmbeddedDevice device);
    bool UpdateEmbeddedDevice(EmbeddedDevice device);
    bool DeleteEmbeddedDevice(string id);
    
    IEnumerable<DeviceNonAbstractClass> GetAllDevices();
    DeviceNonAbstractClass GetDeviceById(string id);
    bool AddDevice(DeviceNonAbstractClass device);
    bool UpdateDevice(DeviceNonAbstractClass device);
    bool DeleteDevice(string id);
    
}