using System;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStake custStake = new CustomStake();
            custStake.Push(10);
            custStake.Push(20);
            custStake.Push(30);
            custStake.Push(30);
            custStake.Push(30);
            custStake.Push(30);
            custStake.Push(30);
            custStake.Push(30);
            custStake.Push(50);
            int value = custStake.Peek();
        }
    }
}
