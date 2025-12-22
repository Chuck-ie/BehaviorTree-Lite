using System;

// public class DCRRootScope(DecoratorNode node) : RootScope<DecoratorNode>(node)
// {
//     public CFNScope<RootScope<DecoratorNode>> CFN<T>() where T : DecoratorNode, new()
//     {
//         T cfn = new();
//         Node.Children = [.. Node.Children, cfn];
//         cfn.Parent = Node;
//         return new(this, cfn);
//     }
//
//     public RootScope<DecoratorNode> Do<T>(T action) where T : LeafNode, new()
//     {
//         Node.Children = [.. Node.Children, action];
//         action.Parent = Node;
//         return this;
//     }
//
//     public RootScope<ControlFlowNode> Is(Func<BTContext, Entity, bool> lambda)
//     {
//         Condition condition = new(lambda);
//         Node.Children = [.. Node.Children, condition];
//         condition.Parent = Node;
//         return this;
//     }
// }
