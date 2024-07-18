using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing.Nodes;

public class ReadNode(BranchNode variable) 
    : BranchNode
{
    public BranchNode Variable { get; } = variable;
}