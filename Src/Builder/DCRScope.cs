using System;
using System.Diagnostics;

public class DCRScope<TPrev>(TPrev scope, DecoratorNode node) : NestedScope<TPrev, DecoratorNode>(scope, node)
    where TPrev : INodeScope
{
    public DCRScope<TPrev> Invert() => DCR<Inverter>();
    public CFNScope<TPrev> Sequence() => CFN<Sequence>();
    public CFNScope<TPrev> Fallback() => CFN<Fallback>();

    public TPrev Do<T>(T leaf) where T : LeafNode
    {
        _ = Link(leaf);
        return Previous;
    }

    public TPrev Is(Func<BTContext, bool> lambda)
    {
        _ = Link(new Condition(lambda));
        return Previous;
    }


    private DCRScope<TPrev> DCR<TDCR>() where TDCR : DecoratorNode, new()
    {
        TDCR decoratorNode = Link(new TDCR());
        return new(Previous, decoratorNode);
    }

    private CFNScope<TPrev> CFN<TCFN>() where TCFN : ControlFlowNode, new()
    {
        TCFN controlFlowNode = Link(new TCFN());
        return new(Previous, controlFlowNode);
    }

    private TChild Link<TChild>(TChild child)
        where TChild : BTNode
    {
        Debug.Assert(Node.Child == null, "Do not assign multiple children to a DecoratorNode");
        Node.Child = child;
        child.Parent = Node;
        return child;
    }
}
