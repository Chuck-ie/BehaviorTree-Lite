public class RootScope<TRoot>(TRoot root) : NodeScope<TRoot>(root)
    where TRoot : BTNode
{
    public BT Build() => new(Node);
}
