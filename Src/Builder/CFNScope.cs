using System;

public class CFNScope<TPrev>(TPrev scope, ControlFlowNode node) : NestedScope<TPrev, ControlFlowNode>(scope, node)
    where TPrev : INodeScope
{
    public DCRScope<CFNScope<TPrev>> Invert() => DCR<Inverter>();
    public CFNScope<CFNScope<TPrev>> Sequence() => CFN<Sequence>();
    public CFNScope<CFNScope<TPrev>> Fallback() => CFN<Fallback>();

    public CFNScope<TPrev> Do<T>(T leaf) where T : LeafNode
    {
        _ = Link(leaf);
        return this;
    }

    public CFNScope<TPrev> Is(Func<BTContext, bool> lambda)
    {
        _ = Link(new Condition(lambda));
        return this;
    }


    private DCRScope<CFNScope<TPrev>> DCR<TDCR>() where TDCR : DecoratorNode, new()
    {
        TDCR decoratorNode = Link(new TDCR());
        return new(this, decoratorNode);
    }

    private CFNScope<CFNScope<TPrev>> CFN<TCFN>() where TCFN : ControlFlowNode, new()
    {
        TCFN controlFlowNode = Link(new TCFN());
        return new(this, controlFlowNode);
    }

    private TChild Link<TChild>(TChild child)
        where TChild : BTNode
    {
        Node.Children = [.. Node.Children, child];
        child.Parent = Node;
        return child;
    }
}
