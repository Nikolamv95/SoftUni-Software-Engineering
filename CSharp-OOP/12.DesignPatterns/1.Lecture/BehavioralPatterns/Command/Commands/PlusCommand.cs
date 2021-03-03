namespace CommandPattern.Commands
{
    public class PlusCommand : ICommand
    {
        public PlusCommand(int operand) : base(operand)
        {
        }

        public override int Calculate(int currnetValue)
        {
            return currnetValue + this.operand;
        }

        public override int UndoCalculate(int currnetValue)
        {
            return currnetValue - this.operand;
        }
    }
}
