using System.Diagnostics;

public class Fallback : ControlFlowNode
{
    public override BTStatus Update(BTContext context, float dt)
    {
        for (int i = CurrIndex; i < Children.Length; i++)
        {
            BTNode child = Children[i];
            BTStatus status = UpdateChild(child, context, dt);

            switch (status)
            {
                case BTStatus.Success:
                    child.OnExit();
                    return BTStatus.Success;
                case BTStatus.Failure:
                    child.OnExit();
                    continue;
                case BTStatus.Running:
                    CurrIndex = i;
                    return BTStatus.Running;
                case BTStatus.Ready:
                    Debug.Assert(false, "Ready status should be handled by UpdateChild() and never returned.");
                    return BTStatus.Failure;
                default:
                    Debug.Assert(false, "Unhandled BTStatus");
                    return BTStatus.Failure;
            }
        }

        return BTStatus.Failure;
    }
}
