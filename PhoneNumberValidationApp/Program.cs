using Microsoft.Extensions.DependencyInjection;
using Validator.StringValidators;
using Validator;
using ValidatorExceptions;

var serviceProvider = new ServiceCollection()
               .AddTransient<IStringContainsPhoneNumberValidator, StringContainsPhoneNumberValidator>()
               .AddTransient<ValidatorService>()
               .BuildServiceProvider();

var validationService = serviceProvider.GetService<ValidatorService>();
try
{
  var valid = validationService.DoesNotContainPhone("Hi Alix, you can contact me at 9 8 ONE ZERO zero two 3 4 five five");
}catch(EmptyInputException ex)
{
    Console.WriteLine(ex.Message);
}
catch(PhoneNumberDetectedException<PhoneNumberInfo> ex)
{
    foreach (var item in ex.DetectedPhoneNumbers)
    {
        Console.WriteLine(item.PhoneNumber);
    }
}
