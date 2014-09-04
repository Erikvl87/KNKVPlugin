using System.Collections;
using System.Collections.Generic;

namespace KNKVPlugin.Model
{
	public class Program : IEnumerable<Match>
	{
		public List<Week> Weeks = new List<Week>();
		public List<Match> Matches = new List<Match>();

		public Program(List<Week> weeks)
		{
			Weeks = weeks;
			foreach (var week in weeks) 
				Matches.AddRange(week.Matches);
		}

		public IEnumerator<Match> GetEnumerator()
		{
			return Matches.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
