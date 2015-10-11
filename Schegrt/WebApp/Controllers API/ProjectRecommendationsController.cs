using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models.Field;
using WebApp.Models.Field.Dtos;
using WebApp.Models.Matchers;
using WebApp.Models;


namespace WebApp.Controllers_API
{
    public class ProjectRecommendationsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Recommendations
        public List<RecomendedProjectDto> GetRecommendations(int id)
        {
            GeneralUser initiatior = db.Users.FirstOrDefault(gu => gu.Id == id);
            List<RecomendedProjectDto> result = new List<RecomendedProjectDto>();
            if (initiatior != null)
            {
				List<Project> projectList = db.Projects.ToList();
                foreach(Project project in new ProjectMatcher(initiatior).GetMatchingProvider(projectList))
                {
                    if(project.GetType() != initiatior.GetType())
                    {
                        result.Add(new RecomendedProjectDto(project));
                    }
                }
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}