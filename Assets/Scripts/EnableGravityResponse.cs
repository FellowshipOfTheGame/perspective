public class EnableGravityResponse : Dual
{
    public bool DisableWhenImaginary;
    
    protected override void BecomeReal()
    {
        rigidbody.useGravity = true;
    }

    protected override void BecomeImaginary()
    {
        if (DisableWhenImaginary)
        {
            rigidbody.useGravity = false;
        }
    }
}
