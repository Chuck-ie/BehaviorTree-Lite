public class Inverter : DecoratorNode
{
    public override void OnEnter(BTContext context) { }
    public override void OnExit() { }

    public override BTStatus Update(BTContext context, float dt)
    {
        BTStatus childStatus = UpdateChild(Child, context, dt);

        if (childStatus == BTStatus.Success)
            return BTStatus.Failure;
        if (childStatus == BTStatus.Failure)
            return BTStatus.Success;

        return BTStatus.Running;
    }
}
