using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Models.Field;

namespace WebApp.Models.Matchers
{
	public class ProviderMatcher
	{
		public ProviderMatcher(GeneralUser initiator)
		{
			if (initiator == null)
			{
				throw new NullReferenceException("Student cannot be null");
			}
			_initiator = initiator;
		}

		public List<GeneralUser> GetMatchingProvider(List<GeneralUser> searchedUsers)
		{
			List<_generalScored> scoredList = new List<_generalScored>();
			foreach (GeneralUser searchedUser in searchedUsers)
			{
				int searchedScore = 0;
				foreach (UserFOI searchedFoi in searchedUser.Interests)
				{
					if(_initiator.Interests.Any(i=> i.Id == searchedFoi.Id))
					{
						searchedScore++;
					}
				}
				scoredList.Add(new _generalScored {user = searchedUser,score = searchedScore });
			}
			List<GeneralUser> returnList = new List<GeneralUser>();
			foreach(_generalScored scored in scoredList.OrderByDescending(x=>x.score))
			{
				returnList.Add(scored.user);
			}
			return returnList;
		}

		#region inner object
		private class _generalScored
		{
			public int score;
			public GeneralUser user;
		}
		#endregion

		#region fields
		GeneralUser _initiator;

		#endregion
	}
}