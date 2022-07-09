using finalPerezAlvarez.Controllers;
using finalPerezAlvarez.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace finalPerezAlvarez.Tests.Controllers;

public class HomeControllerTest
{
    [Test]
    public void Index01()
    {
      
        var controller = new HomeController();
       
        var view = controller.Index() as ViewResult;
        
        Assert.IsNotNull(view); 
        
    }
    
    [Test]
    public void viewmodel01()
    {
        var controller = new HomeController();
        var view = controller.Privacy() as ViewResult;
        Assert.IsNotNull(view); 
        Assert.IsNull(view.Model);
    }
}