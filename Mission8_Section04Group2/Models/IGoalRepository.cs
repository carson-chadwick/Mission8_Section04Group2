namespace Mission8_Section04Group2.Models
{
    public interface IGoalRepository
    {
        List<Goal> Goals { get; }
        List<Category> Categories { get; }

        public void AddGoal(Goal goal);
        public void UpdateGoal(Goal goal);
        public void DeleteGoal(Goal goal);
        public void CompleteStatus(Goal goal);
    }
}
