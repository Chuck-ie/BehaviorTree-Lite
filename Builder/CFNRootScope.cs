using System;

public class CFNRootScope(ControlFlowNode node) : RootScope<ControlFlowNode>(node)
{
    public CFNScope<RootScope<ControlFlowNode>> Sequence() => CFN<Sequence>();
    public CFNScope<RootScope<ControlFlowNode>> Fallback() => CFN<Sequence>();

    public RootScope<ControlFlowNode> Do<T>(T action) where T : LeafNode, new()
    {
        Node.Children = [.. Node.Children, action];
        action.Parent = Node;
        return this;
    }

    public RootScope<ControlFlowNode> Is(Func<BTContext, bool> lambda)
    {
        Condition condition = new(lambda);
        Node.Children = [.. Node.Children, condition];
        condition.Parent = Node;
        return this;
    }


    private CFNScope<RootScope<ControlFlowNode>> CFN<T>() where T : ControlFlowNode, new()
    {
        T cfn = new();
        Node.Children = [.. Node.Children, cfn];
        cfn.Parent = Node;
        return new(this, cfn);
    }
}
