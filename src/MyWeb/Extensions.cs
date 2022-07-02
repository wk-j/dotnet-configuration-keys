public static class Extensions {
    public static void ShowConfig(this WebApplication? app) {
        var config = app.Configuration;
        var service1 = config["Service1"];
        var service2 = config["Service2"];

        app.Logger.LogInformation("Service1={0}", service1);
        app.Logger.LogInformation("Service2={0}", service2);
    }
}