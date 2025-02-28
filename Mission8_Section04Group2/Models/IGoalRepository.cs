using System;

namespace Mission8_Section04Group2.Models
{
	public interface IGoalRepository
	{
		List<Goal>Goals {  get; }

		//public void AddGoal(Goal goal);
		//^That will help when we need to save or edit from the repo. Change "AddGoal" to whatever the method is called
}
