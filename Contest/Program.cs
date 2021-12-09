using System;

namespace ChatCoreTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var testBag = new Inventory2D();
            var sword = new Sword();
            var isAdd = testBag.AddItem(new Sword());
            var isAdd2 = testBag.AddItem(new Sword());
            var isAdd3 = testBag.AddItem(new Sword());
            var isAdd4 = testBag.AddItem(new Sword());
            var isAdd5 = testBag.AddItem(new Sword());
            for (int i = 0; i < testBag.height; i++)
            {
                for (int j = 0; j < testBag.width; j++)
                {
                    Console.Write(testBag.bagGrids[i, j].id);
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }
}