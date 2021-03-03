using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
   public abstract class ICommand
    {
        protected int operand;

        public ICommand(int operand)
        {
            this.operand = operand;
        }

        public abstract int Calculate(int currnetValue);
        public abstract int UndoCalculate(int currnetValue);
    }
}
