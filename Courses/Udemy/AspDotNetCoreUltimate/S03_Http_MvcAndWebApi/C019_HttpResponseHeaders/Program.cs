var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* === NOTES ======================================================================================
 * === HTTP Response ===
 * --- Response Headers ---
 *   - Not visible to the end user, but they are sent by the server to the client as part of the HTTP response.
 */
app.Run(async (HttpContext context) => {

    // You can set custom headers in the HTTP response by adding key-value pairs to the
    //   context.Response.Headers collection.
    context.Response.Headers["MyHeader"] = "my value";
    await context.Response.WriteAsync("Hello");
    await context.Response.WriteAsync("World");
});
/*   - If you want to actually view the headers, you have to open your browser's developer view,
 *     navigate to the network view, and then open the specific request.
 */