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
using WebApp.Models;
using WebApp.Models.Field.Dtos;
using WebApp.Models.Matchers;

namespace WebApp.Controllers_API
{
    public class RecommendationsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Recommendations
        public List<RecommendedUserDto> GetRecommendations(int id)
        {
            GeneralUser initiatior = db.Users.FirstOrDefault(gu => gu.Id == id);
            List<RecommendedUserDto> result = new List<RecommendedUserDto>();
            if (initiatior != null)
            {
                List<GeneralUser> otherTypeOfUsers = initiatior is StudentUser ? db.Users.OfType<ProviderUser>().Cast<GeneralUser>().ToList() : db.Users.OfType<StudentUser>().Cast<GeneralUser>().ToList();
                foreach(GeneralUser user in new ProviderMatcher(initiatior).GetMatchingProvider(otherTypeOfUsers))
                {
                    if(user.GetType() != initiatior.GetType())
                    {
                        result.Add(new RecommendedUserDto(user));
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