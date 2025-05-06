namespace RestApiAnimals.Filters
{
    public class ValidationHelper
    {
        internal static async ValueTask<object?> ValidateId(EndpointFilterInvocationContext context, 
            EndpointFilterDelegate next)
        {
            var id = context.GetArgument<string>(0);
            if(string.IsNullOrEmpty(id))
            {
                return Results.ValidationProblem(new Dictionary<string, string[]>
                {
                    {"id", new[] {"Invalid format: id animal"} }
                });
            }
            
            return await next(context);
        }
    }
}
