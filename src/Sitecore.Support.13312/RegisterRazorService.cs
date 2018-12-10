using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.SitecoreExtensions.Services;

namespace Sitecore.Support
{
  public class RegisterRazorService : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<IRazorService, Sitecore.Support.XA.Foundation.SitecoreExtensions.Services.RazorService>();
    }
  }
}