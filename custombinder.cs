using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1
{//custom middleware
    public class custombinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            var result = data.TryGetValue("Name", out var name);
            if (result)
            {
                var ar = name.ToString().Split('|');

                bindingContext.Result = ModelBindingResult.Success(ar);
            }

            return Task.CompletedTask;
        }
    }
}
