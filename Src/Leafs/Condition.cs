using System;

public class Condition : LeafNode
{
    private readonly Func<BTContext, bool> _lambda;

    internal Condition(Func<BTContext, bool> lambda)
    {
        _lambda = lambda;
    }

    public override void OnEnter(BTContext context) { }
    public override void OnExit() { }

    public override BTStatus Update(BTContext context, float dt)
    {
        return _lambda.Invoke(context)
            ? BTStatus.Success
            : BTStatus.Failure;
    }
}
