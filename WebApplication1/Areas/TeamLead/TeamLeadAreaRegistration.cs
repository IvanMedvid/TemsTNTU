using System.Web.Mvc;

namespace WebApplication1.Areas.TeamLead
{
    public class TeamLeadAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TeamLead";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TeamLead_default",
                "TeamLead/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}