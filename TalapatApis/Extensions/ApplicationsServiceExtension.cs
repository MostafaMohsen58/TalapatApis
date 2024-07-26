using Microsoft.AspNetCore.Mvc;
using Talapat.Core.Repositories;
using Talapat.Repository;
using TalapatApis.Errors;
using TalapatApis.Helper;

namespace TalapatApis.Extensions
{
    public static class ApplicationsServiceExtension
    {


        public static IServiceCollection AddApplicationsServices(this IServiceCollection Services)
        {
            //    builder.Services.AddScoped<IgenericRepository<Product> , GenericRepository<Product>>();
            Services.AddScoped(typeof(IgenericRepository<>), typeof(GenericRepository<>));



            Services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

            //   builder.Services.AddAutoMapper(m=>m.AddProfile(new MappingProfiles()));
            Services.AddAutoMapper(typeof(MappingProfiles));
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    //model state [key value pair]
                    // key : name of params
                    // value: errors

                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)// parameter of errors
                                             .SelectMany(p => p.Value.Errors)
                                             .Select(E => E.ErrorMessage).ToArray();

                    var ValidationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ValidationErrorResponse);
                };
            });
            return Services;

        }

    }
}
