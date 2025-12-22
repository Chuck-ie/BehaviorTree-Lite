public abstract class ControlFlowNode : BTNode
{
    public BTNode[] Children { get; set; }
    protected int CurrIndex { get; set; }

    public override void OnEnter(BTContext context) { }

    public override void OnExit()
    {
        if (CurrIndex < Children.Length)
        {
            BTNode currentChild = Children[CurrIndex];
            if (currentChild.Status == BTStatus.Running)
                currentChild.OnExit();
        }

        foreach (BTNode child in Children)
            child.Status = BTStatus.Ready;

        CurrIndex = 0;
        Status = BTStatus.Ready;
    }
}
