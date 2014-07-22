namespace BehaviorTree
{
    public abstract class Behavior
    {
        public Status Status;

        public Status Update()
        {
            if (Status != Status.Running)
            {
                Status = Status.Unstarted;
                Initialize();
            }

            Status = Behave();

            if (Status != Status.Running)
            {
                Terminate();
            }

            return Status;
        }

        public virtual void Initialize(){}

        public abstract Status Behave();

        public virtual void Terminate(){}
    }
}