using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence : Composite
    {
        private readonly IEnumerator<Behavior> _childEnumerator;

        public Sequence(params Behavior[] children)
            : base(children)
        {
            _childEnumerator = ((IEnumerable<Behavior>) Children).GetEnumerator();
        }

        public override void Initialize()
        {
            _childEnumerator.Reset();
        }

        public override Status Behave()
        {
            Status status = Status.Succeeded;
            if (Status != Status.Unstarted && _childEnumerator.Current != null)
            {
                if (_childEnumerator.Current.Status == Status.Running)
                {
                    status = _childEnumerator.Current.Update();
                    if (status == Status.Running) return status;
                }
            }

            while (_childEnumerator.MoveNext())
            {
                status = _childEnumerator.Current.Update();
                if (status == Status.Failed || status == Status.Running)
                {
                    break;
                }
            }

            return status;
        }
    }
}