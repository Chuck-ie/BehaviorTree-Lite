public interface INodeScope;

public abstract class NodeScope<T>(T node) : INodeScope where T : BTNode
{
    public T Node { get; set; } = node;
}
