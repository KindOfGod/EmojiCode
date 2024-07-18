using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing.Nodes;

public class NumberNode(string value) 
    : BranchNode
{
    public string Value { get; } = value;
}