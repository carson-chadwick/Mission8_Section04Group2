using System;
namespace Mission8_Section04Group2.Models
{
	public class EFGoalRepository : IGoalRepository
	{
		private TaskFormContext _context;

		public EFGoalRepository(TaskFormContext temp) 
		{
			_context = temp;
		}

		public List<Goal> Tasks => _context.Goals.ToList(); //This might need to be "Tasks" instead of "Goals"
		//WE MIGHT USE THIS FOR EDITING AND SAVING ETC 
		//public void AddGoal(Goal goal) 
		//{
		//	_context.Add(goal);
		//	_context.SaveChanges();
		//}
	}
}
