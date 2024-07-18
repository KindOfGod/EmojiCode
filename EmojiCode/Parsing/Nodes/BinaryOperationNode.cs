using EmojiCode.Lexing;
using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing.Nodes;

public class BinaryOperationNode(BranchNode left, TokenType op, BranchNode right) 
    : BranchNode
{
    public BranchNode Left { get; } = left;
    public TokenType Operator { get; } = op;
    public BranchNode Right { get; } = right;
}