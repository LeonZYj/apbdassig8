using database;
using Repository;
using Service1;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<IRepository>(sp => new Repository.ServiceMethod(connectionString));
builder.Services.AddSingleton<IService, Service1.Service>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/api/devices", (IService service) =>
{
    try { return Results.Ok(service.GetAllDevices()); }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapGet("/api/devices/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.GetDeviceById(id);
        if (result == null) return Results.NotFound();
        return Results.Ok(result);
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPost("/api/devices", (IService service, DeviceNonAbstractClass device) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return Results.BadRequest("Name is required.");

        device.Id = Guid.NewGuid().ToString();
        var result = service.AddDevice(device);
        return result ? Results.Created($"/api/devices/{device.Id}", device) : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPut("/api/devices/{id}", (IService service, string id, DeviceNonAbstractClass device) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return Results.BadRequest("Name is required.");

        device.Id = id;
        var result = service.UpdateDevice(device);
        return result ? Results.Ok() : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapDelete("/api/devices/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.DeleteDevice(id);
        return result ? Results.Ok() : Results.NotFound();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapGet("/api/devices/personalComputers", (IService service) =>
{
    try { return Results.Ok(service.GetAllPersonalComputers()); }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapGet("/api/devices/personalComputers/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.GetPersonalComputerById(id);
        if (result == null) return Results.NotFound();
        return Results.Ok(result);
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPost("/api/devices/personalComputers", (IService service, PersonalComputer pc) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(pc.Name))
            return Results.BadRequest("Name is required.");
        if (string.IsNullOrWhiteSpace(pc.OperatingSystem))
            return Results.BadRequest("Operating System is required.");

        pc.Id = Guid.NewGuid().ToString();
        var result = service.AddPersonalComputer(pc);
        return result ? Results.Created($"/api/devices/personalComputers/{pc.Id}", pc) : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPut("/api/devices/personalComputers/{id}", (IService service, string id, PersonalComputer pc) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(pc.Name))
            return Results.BadRequest("Name is required.");

        pc.Id = id;
        var result = service.UpdatePersonalComputer(pc);
        return result ? Results.Ok() : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapDelete("/api/devices/personalComputers/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.DeletePersonalComputer(id);
        return result ? Results.Ok() : Results.NotFound();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapGet("/api/devices/smartWatches", (IService service) =>
{
    try { return Results.Ok(service.GetAllSmartWatches()); }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapGet("/api/devices/smartWatches/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.GetSmartWatchById(id);
        if (result == null) return Results.NotFound();
        return Results.Ok(result);
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPost("/api/devices/smartWatches", (IService service, SmartWatch watch) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(watch.Name))
            return Results.BadRequest("Name is required.");

        watch.Id = Guid.NewGuid().ToString();
        var result = service.AddSmartWatch(watch);
        return result ? Results.Created($"/api/devices/smartWatches/{watch.Id}", watch) : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPut("/api/devices/smartWatches/{id}", (IService service, string id, SmartWatch watch) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(watch.Name))
            return Results.BadRequest("Name is required.");

        watch.Id = id;
        var result = service.UpdateSmartWatch(watch);
        return result ? Results.Ok() : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapDelete("/api/devices/smartWatches/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.DeleteSmartWatch(id);
        return result ? Results.Ok() : Results.NotFound();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapGet("/api/devices/embeddedDevices", (IService service) =>
{
    try { return Results.Ok(service.GetAllEmbeddedDevices()); }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapGet("/api/devices/embeddedDevices/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.GetEmbeddedDeviceById(id);
        if (result == null) return Results.NotFound();
        return Results.Ok(result);
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPost("/api/devices/embeddedDevices", (IService service, EmbeddedDevice device) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return Results.BadRequest("Name is required.");

        device.Id = Guid.NewGuid().ToString();
        var result = service.AddEmbeddedDevice(device);
        return result ? Results.Created($"/api/devices/embeddedDevices/{device.Id}", device) : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapPut("/api/devices/embeddedDevices/{id}", (IService service, string id, EmbeddedDevice device) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(device.Name))
            return Results.BadRequest("Name is required.");

        device.Id = id;
        var result = service.UpdateEmbeddedDevice(device);
        return result ? Results.Ok() : Results.BadRequest();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.MapDelete("/api/devices/embeddedDevices/{id}", (IService service, string id) =>
{
    try
    {
        var result = service.DeleteEmbeddedDevice(id);
        return result ? Results.Ok() : Results.NotFound();
    }
    catch (Exception ex) { return Results.Problem(ex.Message); }
});

app.Run();
