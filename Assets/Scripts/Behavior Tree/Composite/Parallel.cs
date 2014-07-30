namespace BehaviorTree
{
    public class Parallel : Composite
    {
        public enum Policy
        {
            RequireOne,
            RequireAll
        }

        public Policy SuccessPolicy;
        public Policy FailurePolicy;

        public Parallel(Policy successPolicy, Policy failurePolicy, params Behavior[] children)
            : base(children)
        {
            SuccessPolicy = successPolicy;
            FailurePolicy = failurePolicy;
        }

        public override void Initialize()
        {
            foreach (Behavior child in Children)
            {
                child.Status = Status.Unstarted;
            }
            base.Initialize();
        }

        public override Status Behave()
        {
            uint succeededCount = 0;
            uint failureCount = 0;
            foreach (Behavior child in Children)
            {
                if (child.Status == Status.Running || child.Status == Status.Unstarted)
                {
                    child.Update();
                }

                Status status = child.Status;

                if (status == Status.Succeeded)
                {
                    if (SuccessPolicy == Policy.RequireOne)
                    {
                        return Status.Succeeded;
                    }
                    ++succeededCount;
                }

                if (status == Status.Failed)
                {
                    if (FailurePolicy == Policy.RequireOne)
                    {
                        return Status.Failed;
                    }
                    ++failureCount;
                }
            }

            if (succeededCount == Children.Length)
            {
                return Status.Succeeded;
            }

            if (failureCount == Children.Length)
            {
                return Status.Failed;
            }

            return Status.Running;
        }

        public override void Terminate()
        {
            foreach (Behavior child in Children)
            {
                if (child.Status == Status.Running)
                {
                    child.Status = Status.Aborted;
                }
            }
        }
    }
}