
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Models.Field;
using WebApp.Models.Field.ViewModels;

namespace WebApp.Controllers_API
{
    public class ProjectsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/ProjectFOIs
        public IQueryable<ProjectFOI> GetProjectFOIs(int id)
        {
			return db.ProjectFOIs.Where(pf => pf.Project.Id == id);
        }

        public IHttpActionResult AddProjectInterest(ProjInterestViewModel projModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Project proj = db.Projects.FirstOrDefault(p => p.Id == projModel.ProjId);
			FieldOfInterest foi = db.Fields.FirstOrDefault(f => f.Id == projModel.FOIId);

			ProjectFOI projFoi = new ProjectFOI { Project = proj, Foi = foi };

			db.ProjectFOIs.Add(projFoi);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = projFoi.Id }, projFoi);
		}

        // DELETE: api/ProjectFOIs/5
        [ResponseType(typeof(ProjectFOI))]
        public IHttpActionResult DeleteProjectFOI(int id)
        {
            ProjectFOI projectFOI = db.ProjectFOIs.Find(id);
            if (projectFOI == null)
            {
                return NotFound();
            }

            db.ProjectFOIs.Remove(projectFOI);
            db.SaveChanges();

            return Ok(projectFOI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectFOIExists(int id)
        {
            return db.ProjectFOIs.Count(e => e.Id == id) > 0;
        }
    }
}