// The builder pattern is used to create and configure the web application.
// The WebApplication class provides a simple way to set up a web server and define routes for handling HTTP requests.
// In this example, we define a single route that responds to GET requests at the root URL ("/") with the message "Hello World!".
// Finally, we call app.Run() to start the web server and listen for incoming requests.
var builder = WebApplication.CreateBuilder(args);

// The app variable is an instance of the WebApplication class, which represents the web application being built.
var app = builder.Build();

// The MapGet method is used to define a route for handling GET requests at the root URL ("/").
app.MapGet("/", () => "Hello World!");

// The Run method starts the web server and begins listening for incoming HTTP requests.
app.Run();

// === NOTES ======================================================================================
// - Kestrel is the default web server used by ASP.NET Core applications.
//   It is a cross-platform web server that can run on Windows, Linux, and macOS. Kestrel is
//   designed to be fast and efficient, making it a popular choice for hosting web applications.
// - It is best practice to use Kestrel in combination with a reverse proxy server
//   (like IIS, Nginx, or Apache) in production environments for better security and performance.
//   - This is because Kestrel does not have all the features of a full-fledged web server, such
//      as SSL termination, request filtering, and load balancing.
//   - Despite these lacks, Kestrel is still highly efficient, and the gaps are easily covered by
//     implementing a reverse proxy server in front of it.