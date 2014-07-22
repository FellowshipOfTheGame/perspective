namespace BehaviorTree
{
    public class Action : Behavior
    {
        private readonly System.Action _behave;

        public Action(System.Action behave)
        {
            _behave = behave;
        }

        public override Status Behave()
        {
            _behave();
            return Status.Succeeded;
        }
    }
}