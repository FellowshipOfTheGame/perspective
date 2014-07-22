using System;

namespace BehaviorTree
{
    public class Conditional : Behavior
    {
        private readonly Func<bool> _boolBehave;

        public Conditional(Func<bool> behave)
        {
            _boolBehave = behave;
        }

        public override Status Behave()
        {
            return _boolBehave() ? Status.Succeeded : Status.Failed;
        }
    }
}