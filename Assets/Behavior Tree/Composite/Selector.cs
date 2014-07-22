using System.Collections.Generic;

namespace BehaviorTree
{
    public class Selector : Composite
    {
        private readonly IEnumerator<Behavior> _childEnumerator;

        public Selector(params Behavior[] children)
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
            Status status = Status.Failed;
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
                if (status == Status.Succeeded || status == Status.Running)
                {
                    break;
                }
            }

            return status;
        }
    }
}