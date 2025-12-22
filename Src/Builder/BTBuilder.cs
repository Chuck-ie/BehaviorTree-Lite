public static class BTBuilder
{
    public static CFNRootScope Begin<TRoot>()
        where TRoot : ControlFlowNode, new()
    {
        TRoot root = new();
        CFNRootScope rootScope = new(root);
        return rootScope;
    }

    // RootNode
    public static BT Build<T>(this RootScope<T> scope)
        where T : BTNode
    {
        return new BT(scope.Node);
    }

    // public static void Testing()
    // {
    //     BT behavior = Begin<Sequence>()
    //         .Sequence()
    //             .Is(static (context) => context.Get<int>("input") > 1)
    //             .End()
    //         .Build();
    // }
}
