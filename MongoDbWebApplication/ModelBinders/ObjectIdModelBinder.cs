using Microsoft.AspNetCore.Mvc.ModelBinding;

using MongoDB.Bson;

namespace MongoDbWebApplication.ModelBinders;

public class ObjectIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var modelResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (modelResult.FirstValue == null)
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Object id is not set");

            bindingContext.Result = ModelBindingResult.Failed();

            return Task.CompletedTask;
        }

        var objId = modelResult.FirstValue;

        if (ObjectId.TryParse(objId, out var result))
        {
            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }

        bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Object id is not set");

        return Task.CompletedTask;
    }
}
