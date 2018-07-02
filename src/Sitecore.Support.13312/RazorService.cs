using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sitecore.Support.XA.Foundation.SitecoreExtensions.Services
{
  public class RazorService:Sitecore.XA.Foundation.SitecoreExtensions.Services.RazorService
  {
    protected class FakeController : Controller
    {
    }

    public override string GetRazorViewAsString(object model, string filePath)
    {
      StringWriter stringWriter = new StringWriter();
      HttpContextWrapper httpContext = new HttpContextWrapper(HttpContext.Current);
      RouteData routeData = new RouteData();
      routeData.Values["controller"] = "Sitecore";
      ControllerContext controllerContext = new ControllerContext(new RequestContext(httpContext, routeData), new FakeController());
      RazorView razorView = new RazorView(controllerContext, filePath, null, false, null);
      razorView.Render(new ViewContext(controllerContext, razorView, new ViewDataDictionary(model), new TempDataDictionary(), stringWriter), stringWriter);
      return stringWriter.ToString();
    }
  }
}