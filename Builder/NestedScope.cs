public abstract class NestedScope<TPrev, TNode>(TPrev previous, TNode node) : NodeScope<TNode>(node)
    where TPrev : INodeScope
    where TNode : BTNode
{
    public TPrev Previous { get; } = previous;
    public TPrev End() => Previous;
}
