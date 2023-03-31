
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Section7.Models;

namespace Section7.CustomModelBinders;
public class PersonModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        Person person = new Person();
        //First and Last Name
        if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
        {
            person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

            if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
            {
                person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }
        }


        //Email
        if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
        {
            person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;



            bindingContext.Result = ModelBindingResult.Success(person);
        return Task.CompletedTask;
    }
}
