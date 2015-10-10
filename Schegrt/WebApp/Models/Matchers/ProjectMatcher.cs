using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.Field;

namespace WebApp.Models.Matchers
{
	public class ProjectMatcher
	{
		public ProjectMatcher(GeneralUser initiator)
		{
			if (initiator == null)
			{
				throw new NullReferenceException("Initiatior cannot be null");
			}
			_initiator = initiator;
		}

		public List<Project> GetMatchingProvider(List<Project> searchedProjects)
		{
			List<_projectScored> scoredList = new List<_projectScored>();
			foreach (Project searchedProject in searchedProjects)
			{
				int searchedScore = 0;
				foreach (ProjectFOI searchedFoi in searchedProject.FoiList)
				{
					if (_initiator.Interests.Any(i => i.Foi.Id == searchedFoi.Foi.Id))
					{
						searchedScore++;
					}
				}
				if (searchedScore > 0)
				{
					scoredList.Add(new _projectScored { project = searchedProject, score = searchedScore });
				}
			}
			List<Project> returnList = new List<Project>();
			foreach (_projectScored scored in scoredList.OrderByDescending(x => x.score))
			{
				returnList.Add(scored.project);
			}
			return returnList;
		}

		#region inner object
		private class _projectScored
		{
			public int score;
			public Project project;
		}
		#endregion

		#region fields
		GeneralUser _initiator;

		#endregion
	}
}