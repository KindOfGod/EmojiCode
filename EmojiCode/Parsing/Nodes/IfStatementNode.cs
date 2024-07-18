using EmojiCode.Parsing.Nodes.Base;

namespace EmojiCode.Parsing.Nodes;

public class IfStatementNode(BranchNode condition, BranchNode trueBranch, BranchNode falseBranch)
    : BranchNode
{
    public BranchNode Condition { get; } = condition;
    public BranchNode TrueBranch { get; } = trueBranch;
    public BranchNode FalseBranch { get; } = falseBranch;
}