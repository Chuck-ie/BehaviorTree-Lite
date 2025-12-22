# Motivation
This simple behavior tree implementation was done out of curiosity for a game I'm currently working on, just to get the basics down of how behavior
trees work.

# Testing
This repo is untested and should therefore not be used uncritically.

# BehaviorTree-Lite
A basic behavior tree implementation with the most common nodes. It contains a builder that implements the flow-builder-pattern for accessibility.
The builder is also context aware, meaning that each node is automatically changing in- and out of the correct context. As an example, a decorator node
inside a behavior tree only allows for a single child. If this child is a leaf node, then the context of the decorator automatically closes and jumps
out of the decorator node context and back into the context it came from. If another control node is added as a child however, the context jumps into
the context of the newly created node. Also, when later closing this child's context, it automatically is able to skip the already full decorator node 
parent from earlier. This helps immensly in writing clean and easily understandable behavior trees. The drawback is that the builder needs to store
the entire type reference chain of where it currently is in context through generics in memory. This however is generally not a problem, since 
behavior trees are generally static and only built once at start-up. 

# Builder example
```csharp
BT behavior = Begin<Sequence>()
    .Sequence()
        .Is(static (context) => context.Get<int>("input") > 1)
        .End()
    .Build();
```
