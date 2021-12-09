using System;
using System.Collections.Generic;

namespace ChatCoreTest
{
    class Inventory2D
    {
        public int width = 4;
        public int height = 4;
        public BagGrid[,] bagGrids;
        public Dictionary<int, Item> itemTable = new Dictionary<int, Item>();
        public Inventory2D()
        {
            bagGrids = new BagGrid[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    bagGrids[i, j] = new BagGrid();
                }
            }
        }
        public bool AddItem(Item target)
        {
            bool rt = false;
            Tuple<int, int> itemHW = target.HW;

            for (int i = 0; i < height; i++)
            {
                if (i + itemHW.Item1 > height) break;
                for (int j = 0; j < width; j++)
                {
                    if (j + itemHW.Item2 > width) break;
                    if (!bagGrids[i, j].IsEmpty) continue;
                    if (bagGrids[i, j].IsEmpty)
                    {
                        int k;
                        for (k = 0; k < itemHW.Item2 && k + j < width; k++)
                        {
                            if (!bagGrids[i, j + k].IsEmpty) break;
                        }
                        if (k != itemHW.Item2) continue;
                        int l;
                        for (l = 0; l < itemHW.Item1; l++)
                        {
                            int q;
                            for (q = 0; q < itemHW.Item2; q++)
                            {
                                if (!bagGrids[i + l, j + q].IsEmpty) break;
                            }
                            if (q != itemHW.Item2) break;
                        }
                        if (l != itemHW.Item1) continue;
                    }
                    for (int m = 0; m < itemHW.Item1; m++)
                    {
                        for (int n = 0; n < itemHW.Item2; n++)
                        {
                            bagGrids[i + m, j + n].id = target.ID; //Spawn item
                        }
                    }
                    if(!itemTable.ContainsKey(target.ID))
                    itemTable.Add(target.ID, target);
                    return true;
                }
            }
            return rt;
        }
    }


    class BagGrid
    {
        public int id = 0;
        public bool IsEmpty => id == 0;
        public Type itemType = null;
        public void Clear()
        {
            id = 0;
            itemType = null;
        }
    }

    class Item
    {
        protected int width, height;
        public Tuple<int, int> HW => Tuple.Create(height, width);

        public int ID { get; protected set; }
        public Item(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public Item() { width = 1; height = 1; }
    }

    class Sword : Item
    {
        public Sword()
        {
            width = 1;
            height = 3;
            Random rand = new Random();
            ID = rand.Next(1, 10);
        }
    }
}