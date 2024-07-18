using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing.Nodes;

public class WhileLoopNode(BranchNode condition, BranchNode body) 
    : BranchNode
{
    public BranchNode Condition { get; } = condition;
    public BranchNode Body { get; } = body;
}