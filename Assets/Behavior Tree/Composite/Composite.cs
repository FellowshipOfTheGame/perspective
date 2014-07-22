namespace BehaviorTree
{
    public abstract class Composite : Behavior
    {
        protected Behavior[] Children;

        protected Composite(params Behavior[] children)
        {
            Children = children;
        }
    }
}