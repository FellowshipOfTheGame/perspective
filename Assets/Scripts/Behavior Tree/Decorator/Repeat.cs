namespace BehaviorTree
{
    public class Repeat : Decorator
    {
        private readonly uint _limit;
        private uint _counter;

        public Repeat(uint limit, Behavior child)
            : base(child)
        {
            _limit = limit;
        }

        public override void Initialize()
        {
            _counter = 0;
        }

        public override Status Behave()
        {
            Status status = Child.Update();

            if (status == Status.Succeeded)
            {
                ++_counter;
                return (_counter == _limit) ? Status.Succeeded : Status.Running;
            }

            return status;
        }
    }
}