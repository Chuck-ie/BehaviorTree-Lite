public abstract class BTNode
{
    public BTNode Parent { get; set; }
    public BTStatus Status { get; set; } = BTStatus.Ready;

    public abstract void OnEnter(BTContext context);
    public abstract void OnExit();
    public abstract BTStatus Update(BTContext context, float dt);

    protected static BTStatus UpdateChild(BTNode child, BTContext context, float dt)
    {
        if (child.Status == BTStatus.Ready)
        {
            child.OnEnter(context);
            child.Status = BTStatus.Running;
        }

        child.Status = child.Update(context, dt);
        return child.Status;
    }
}
