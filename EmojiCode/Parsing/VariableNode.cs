using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing;

public class VariableNode(string name) : BranchNode
{
    public string Name { get; } = name;
}