using Microsoft.EntityFrameworkCore;

namespace Mission8_Section04Group2.Models
{
    public class EFGoalRepository : IGoalRepository
    {
        private GoalFormContext _context;
        public EFGoalRepository(GoalFormContext temp)
        {
            _context = temp;
        }
        public List<Goal> Goals => _context.Goals
            .Include(g => g.Category)  // Eager load Category
            .ToList();

        public List<Category> Categories => _context.Categories.ToList();

        public void AddGoal(Goal goal)
        {
            _context.Goals.Add(goal);
            _context.SaveChanges();
        }
        public void UpdateGoal(Goal goal)
        {
            _context.Goals.Update(goal);
            _context.SaveChanges();
        }
        public void DeleteGoal(Goal goal)
        {
            _context.Goals.Remove(goal);
            _context.SaveChanges();
        }

    }
}
