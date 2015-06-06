using System.Web.Mvc;

namespace WebApplication1.Areas.SuperAdmin
{
    public class SuperAdminAreaRegistration : AreaRegistration 
    {
        //<summary>
        //Область для додавання та редагування тем
        //</summary>
        public override string AreaName 
        {
            get 
            {
                return "SuperAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SuperAdmin_default",
                "SuperAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}