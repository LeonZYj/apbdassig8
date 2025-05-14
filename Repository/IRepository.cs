using database;

namespace Repository;

public interface IRepository
{
    IEnumerable<PersonalComputer> GetAllPersonalComputers();
    PersonalComputer GetPersonalComputerID(String id);
    bool AddPersonalComputer(PersonalComputer computer);
    bool DeletePersonalComputer(String id);
    bool UpdatePersonalComputer(PersonalComputer computer);
    
    IEnumerable<SmartWatch> GetAllSmartWatches();
    SmartWatch GetSmartWatchID(String id);
    bool AddSmartWatch(SmartWatch watch);
    bool DeleteSmartWatch(String id);
    bool UpdateSmartWatch(SmartWatch watch);
    
    IEnumerable<EmbeddedDevice> GetAllEmbeddedDevices();
    EmbeddedDevice GetEmbeddedDeviceID(String id);
    bool AddEmbeddedDevice(EmbeddedDevice device);
    bool DeleteEmbeddedDevice(String id);
    bool UpdateEmbeddedDevice(EmbeddedDevice device);

    IEnumerable<DeviceNonAbstractClass> GetAllDevices();
    DeviceNonAbstractClass GetDeviceID(String id);
    bool AddDevice(DeviceNonAbstractClass device);
    bool DeleteDevice(String id);
    bool UpdateDevice(DeviceNonAbstractClass device);


}