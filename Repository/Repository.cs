using System.Data;
using database;
using Microsoft.Data.SqlClient;

namespace Repository;
using System.Collections.Generic;
public class ServiceMethod : IRepository
{
    private readonly string connectionString;

    public ServiceMethod(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public IEnumerable<PersonalComputer> GetAllPersonalComputers()
        {
            var result = new List<PersonalComputer>();
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT d.ID, d.Name, d.IsEnabled, pc.OperatingSystem FROM Device d JOIN PersonalComputer pc ON d.Id = pc.DeviceId", connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new PersonalComputer
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2),
                    OperatingSystem = reader.GetString(3)
                });
            }
            return result;
        }

        public PersonalComputer GetPersonalComputerID(string id)
        {
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT d.ID, d.Name, d.IsEnabled, pc.OperatingSystem FROM Device d JOIN PersonalComputer pc ON d.Id = pc.DeviceId WHERE d.Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new PersonalComputer
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2),
                    OperatingSystem = reader.GetString(3)
                };
            }
            return null;
        }

        public bool AddPersonalComputer(PersonalComputer pc)
        {
            if (string.IsNullOrWhiteSpace(pc.Id))
                pc.Id = Guid.NewGuid().ToString();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("AddPersonalComputer", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", pc.Id);
            command.Parameters.AddWithValue("@Name", pc.Name);
            command.Parameters.AddWithValue("@IsEnabled", pc.IsTurnedOn);
            command.Parameters.AddWithValue("@OperatingSystem", pc.OperatingSystem);

            connection.Open();
            command.ExecuteNonQuery();

            return true;
        }

        public bool DeletePersonalComputer(string id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var cmd = new SqlCommand(
                    "DELETE FROM PersonalComputer WHERE DeviceId = @Id; DELETE FROM Device WHERE Id = @Id",
                    connection,
                    transaction
                );
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

 
        public bool UpdatePersonalComputer(PersonalComputer pc)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var cmd = new SqlCommand(
                    "UPDATE Device SET Name = @Name, IsEnabled = @IsEnabled WHERE Id = @Id; " +
                    "UPDATE PersonalComputer SET OperatingSystem = @OperatingSystem WHERE DeviceId = @Id",
                    connection,
                    transaction
                );

                cmd.Parameters.AddWithValue("@Id", pc.Id);
                cmd.Parameters.AddWithValue("@Name", pc.Name);
                cmd.Parameters.AddWithValue("@IsEnabled", pc.IsTurnedOn);
                cmd.Parameters.AddWithValue("@OperatingSystem", pc.OperatingSystem);

                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }


        public IEnumerable<SmartWatch> GetAllSmartWatches()
        {
            var result = new List<SmartWatch>();
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT d.ID, d.Name, d.IsEnabled, sw.BatteryLife FROM Device d JOIN SmartWatch sw ON d.Id = sw.DeviceId", connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new SmartWatch
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2),
                    BatteryLevel = reader.GetInt32(3)
                });
            }
            return result;
        }

        public SmartWatch GetSmartWatchID(string id)
        {
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT d.ID, d.Name, d.IsEnabled, sw.BatteryLife FROM Device d JOIN SmartWatch sw ON d.Id = sw.DeviceId WHERE d.Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new SmartWatch
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2),
                    BatteryLevel = reader.GetInt32(3)
                };
            }
            return null;
        }

        public bool AddSmartWatch(SmartWatch watch)
        {
            if (string.IsNullOrWhiteSpace(watch.Id))
                watch.Id = Guid.NewGuid().ToString();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("AddSmartWatch", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", watch.Id);
            command.Parameters.AddWithValue("@Name", watch.Name);
            command.Parameters.AddWithValue("@IsEnabled", watch.IsTurnedOn);
            command.Parameters.AddWithValue("@BatteryLife", watch.BatteryLevel);

            connection.Open();
            command.ExecuteNonQuery();

            return true;
        }


        public bool DeleteSmartWatch(string id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var cmd = new SqlCommand(
                    "DELETE FROM SmartWatch WHERE DeviceId = @Id; DELETE FROM Device WHERE Id = @Id",
                    connection,
                    transaction
                );
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool UpdateSmartWatch(SmartWatch watch)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var cmd = new SqlCommand(
                    "UPDATE Device SET Name = @Name, IsEnabled = @IsEnabled WHERE Id = @Id; " +
                    "UPDATE SmartWatch SET BatteryLife = @BatteryLife WHERE DeviceId = @Id",
                    connection,
                    transaction
                );

                cmd.Parameters.AddWithValue("@Id", watch.Id);
                cmd.Parameters.AddWithValue("@Name", watch.Name);
                cmd.Parameters.AddWithValue("@IsEnabled", watch.IsTurnedOn);
                cmd.Parameters.AddWithValue("@BatteryLife", watch.BatteryLevel);

                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }


        public IEnumerable<EmbeddedDevice> GetAllEmbeddedDevices()
        {
            var result = new List<EmbeddedDevice>();
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT d.ID, d.Name, d.IsEnabled, ed.NetworkName, ed.IPAddress FROM Device d JOIN EmbeddedDevice ed ON d.Id = ed.DeviceId", connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new EmbeddedDevice
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2),
                    NetworkName = reader.GetString(3),
                    IpAddress = reader.GetString(4)
                });
            }
            return result;
        }

        public EmbeddedDevice GetEmbeddedDeviceID(string id)
        {
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT d.ID, d.Name, d.IsEnabled, ed.NetworkName, ed.IPAddress FROM Device d JOIN EmbeddedDevice ed ON d.Id = ed.DeviceId WHERE d.Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new EmbeddedDevice
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2),
                    NetworkName = reader.GetString(3),
                    IpAddress = reader.GetString(4)
                };
            }
            return null;
        }

        public bool AddEmbeddedDevice(EmbeddedDevice device)
        {
            if (string.IsNullOrWhiteSpace(device.Id))
                device.Id = Guid.NewGuid().ToString();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand("AddEmbeddedDevice", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", device.Id);
            command.Parameters.AddWithValue("@Name", device.Name);
            command.Parameters.AddWithValue("@IsEnabled", device.IsTurnedOn);
            command.Parameters.AddWithValue("@NetworkName", device.NetworkName);
            command.Parameters.AddWithValue("@IPAddress", device.IpAddress);

            connection.Open();
            command.ExecuteNonQuery();

            return true;
        }

        public bool DeleteEmbeddedDevice(string id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var cmd = new SqlCommand(
                    "DELETE FROM EmbeddedDevice WHERE DeviceId = @Id; DELETE FROM Device WHERE Id = @Id",
                    connection,
                    transaction
                );
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }


        public bool UpdateEmbeddedDevice(EmbeddedDevice device)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var cmd = new SqlCommand(
                    "UPDATE Device SET Name = @Name, IsEnabled = @IsEnabled WHERE Id = @Id; " +
                    "UPDATE EmbeddedDevice SET NetworkName = @NetworkName, IPAddress = @IPAddress WHERE DeviceId = @Id",
                    connection,
                    transaction
                );

                cmd.Parameters.AddWithValue("@Id", device.Id);
                cmd.Parameters.AddWithValue("@Name", device.Name);
                cmd.Parameters.AddWithValue("@IsEnabled", device.IsTurnedOn);
                cmd.Parameters.AddWithValue("@NetworkName", device.NetworkName);
                cmd.Parameters.AddWithValue("@IPAddress", device.IpAddress);

                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public IEnumerable<DeviceNonAbstractClass> GetAllDevices()
        {
            var result = new List<DeviceNonAbstractClass>();
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT * FROM Device", connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new DeviceNonAbstractClass
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2)
                });
            }
            return result;
        }

        public DeviceNonAbstractClass GetDeviceID(string id)
        {
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT * FROM Device WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new DeviceNonAbstractClass
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    IsTurnedOn = reader.GetBoolean(2)
                };
            }
            return null;
        }

        public bool AddDevice(DeviceNonAbstractClass device)
        {
            if (string.IsNullOrWhiteSpace(device.Id))
                device.Id = Guid.NewGuid().ToString();

            using var connection = new SqlConnection(connectionString);
            var cmd = new SqlCommand("INSERT INTO Device (Id, Name, IsEnabled) VALUES (@Id, @Name, @IsEnabled)", connection);
            cmd.Parameters.AddWithValue("@Id", device.Id);
            cmd.Parameters.AddWithValue("@Name", device.Name);
            cmd.Parameters.AddWithValue("@IsEnabled", device.IsTurnedOn);
            connection.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteDevice(string id)
        {
            using var connection = new SqlConnection(connectionString);
            var cmd = new SqlCommand("DELETE FROM Device WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", id);
            connection.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool UpdateDevice(DeviceNonAbstractClass device)
        {
            using var connection = new SqlConnection(connectionString);
            var cmd = new SqlCommand("UPDATE Device SET Name = @Name, IsEnabled = @IsEnabled WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", device.Id);
            cmd.Parameters.AddWithValue("@Name", device.Name);
            cmd.Parameters.AddWithValue("@IsEnabled", device.IsTurnedOn);
            connection.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
    }