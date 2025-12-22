public class BT(BTNode root)
{
    private readonly BTNode _root = root;
    private readonly BTContext _context = new();

    public BTStatus Update(float dt)
    {
        BTStatus status = _root.Update(_context, dt);

        if (status != BTStatus.Running)
        {
            _root.OnExit();
            _context.Reset();
        }

        return status;
    }
}
