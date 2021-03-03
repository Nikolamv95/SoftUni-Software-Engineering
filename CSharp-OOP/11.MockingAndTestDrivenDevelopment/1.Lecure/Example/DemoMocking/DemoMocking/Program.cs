using Moq;
using System;

namespace DemoMocking
{
    class Program
    {
        static void Main(string[] args)
        {
            Mock<Promotion> mockPromotion = new Mock<Promotion>();
            mockPromotion.Setup(x => x.GetDiscount()).Returns(20); 
            mockPromotion.Setup(x => x.CalculateDiscount(100)).Returns(50);

            Console.WriteLine($"GetDiscount {mockPromotion.Object.GetDiscount()}");;
            Console.WriteLine($"CalculateDiscount {mockPromotion.Object.CalculateDiscount(100)}");;
            


        }
    }
}
