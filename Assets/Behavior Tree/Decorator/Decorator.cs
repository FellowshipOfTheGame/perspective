namespace BehaviorTree
{
    public abstract class Decorator : Behavior
    {
        protected readonly Behavior Child;

        protected Decorator(Behavior child)
        {
            Child = child;
        }
    }
}