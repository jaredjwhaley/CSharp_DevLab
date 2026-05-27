var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* === NOTES ======================================================================================
 * === HTTP Response ===
 * --- Status Codes ---
 *   - 1xx: Informational    - 2xx: Success          - 3xx: Redirection
 *   - 4xx: Client Errors    - 5xx: Server Errors
 *   
 *   - Common Status Codes:
 *     - 101 Switching Protocols: The server is switching protocols as requested by the client.
 *     - 200 OK: The request has succeeded.
 *     - 302 Found: The requested resource has been temporarily moved to a different URI.
 *     - 304 Not Modified: The requested resource has not been modified since the last request.
 *     - 400 Bad Request: The server cannot process the request due to a client error (e.g., malformed request syntax).
 *     - 401 Unauthorized: The client must authenticate itself to get the requested response.
 *     - 403 Forbidden: The client does not have access rights to the content.
 *     - 404 Not Found: The server cannot find the requested resource.
 *     - 500 Internal Server Error: The server encountered an unexpected condition that prevented it from fulfilling the request.
 *   
 *   - Returning Status Codes:
 *     - 'MapGet' and similar methods return a 200 OK status code by default when the request is successful, and can only return a value.
 *       - In the code below, the 'MapGet' method will return a 200 OK status code along with the string "Hello World!" when a GET request is made to the root URL ("/"):
 *       - app.MapGet("/", () => "Hello World!");
 *       
 *     - The 'Run' method is required if you want your response to be dictated by the logic in the
 *       lambda expression, and it allows you to specify the status code and response body
 *       explicitly.
 *       - Please see the inline comments in the code below for examples on this implementation:
 */
app.Run(async (HttpContext context) => {
    // NOTE: The HttpContext object is created upon receipt of each request and contains all the
    //       information about the request and response, including headers, body, query parms, etc.

    // You can specify the status code of the response by setting context.Response.StatusCode to the desired value
    context.Response.StatusCode = 400;

    // You can write to the response body using context.Response.WriteAsync, which allows you to
    //   send data back to the client as part of the HTTP response.
    //   - The 'WriteAsync' method is asynchronous and returns a Task, so you should 'await' it to
    //     ensure that the response is sent correctly.
    await context.Response.WriteAsync("Hello");
    await context.Response.WriteAsync("World");
});