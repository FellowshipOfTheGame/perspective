using System;
using BehaviorTree;

public class Condition : Decorator
{
    private readonly Func<bool> _condition;

    public Condition(Func<bool> condition, Behavior child) : base(child)
    {
        _condition = condition;
    }

    public override Status Behave()
    {
        if (_condition())
        {
            return Child.Update();
        }
        return Status.Failed;
    }
}