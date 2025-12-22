using System;

public class Executor : LeafNode
{
    private readonly Func<BTContext, BTStatus> _lambda;

    internal Executor(Func<BTContext, BTStatus> lambda)
    {
        _lambda = lambda;
    }

    public override void OnEnter(BTContext context) { }
    public override void OnExit() { }

    public override BTStatus Update(BTContext context, float dt)
    {
        return _lambda.Invoke(context);
    }
}
