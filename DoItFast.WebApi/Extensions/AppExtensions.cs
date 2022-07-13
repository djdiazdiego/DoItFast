using DoItFast.WebApi.Middlewares;

namespace DoItFast.WebApi.Extensions
{
    public static class AppExtensions
    {
        /// <summary>
        /// Add swagger middleware
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // For Debug in Kestrel
                c.SwaggerEndpoint("swagger/v1/swagger.json", "DoItFast.WebApi v1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

            });
        }

        /// <summary>
        /// Middeware for catch flow errors.
        /// </summary>
        /// <param name="app"></param>
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ErrorHandlerMiddleware>();

        //public static void UseJwtMiddleware(this IApplicationBuiSlder app)
        //    => app.UseMiddleware<JwtMiddleware>();

       
    }
}
