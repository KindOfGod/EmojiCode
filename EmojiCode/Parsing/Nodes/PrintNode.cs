using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing.Nodes;

public class PrintNode(BranchNode expression) 
    : BranchNode
{
    public BranchNode Expression { get; } = expression;
}