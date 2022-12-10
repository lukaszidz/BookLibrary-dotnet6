namespace BookLibrary.Api.Configuration;

using static System.Net.Mime.MediaTypeNames;

internal static class ExceptionHandler
{
    public static IApplicationBuilder UseCustomExceptions(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            return app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = Text.Plain;

                    await context.Response.WriteAsync("An error occured.");
                });
            });
        }

        return app;
    }
}
