# StoreFront
This is a sample store front application, with inventory tracking and support for inventory shelf life management. 

## The Challenge
Welcome to the StoreFront. As you know, we are a small store with a prime location in a prominent city ran by a friendly store manager named Sarah. We also buy and sell only the finest elements. Unfortunately, our items are constantly losing shelf value as they approach their sell by date. We have a system in place that updates our inventory for us. It was developed by a no-nonsense guy named Larry, who has moved on to new adventures. Your task is to add the new feature to our system so that we can begin selling a new category of items. First an introduction to our system:
 
        - All items have a ShelfLife value which denotes the number of days we have to sell the item
        - All items have a Worth value which denotes how valuable the item is
        - At the end of each day our system lowers both values for every item
 
Pretty simple, right? Well this is where it gets interesting:
 
        - Once the shelf life date has passed, Worth degrades twice as fast
        - The Worth of an item is never negative
        - "Gold" actually increases in Worth the older it gets
        - The Worth of an item is never more than 50
        - "Cadmium" is rare and never has to be sold or will decrease in Worth
        - "Helium", like gold, increases in Worth as it's ShelfLife value approaches; Worth increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Worth drops to 0 after the concert
 
We have recently signed an alchemist to create "Alchemy" items. This requires an update to our system:
 
        - "Alchemy" items degrade in Worth twice as fast as normal items
 
Feel free to make any changes to the UpdateWorth method and add any new code as long as everything still works correctly. However, do not alter the Item class or Items property as those belong to another team that doesn’t believe in shared code ownership (you can make the UpdateWorth method and Items property static if you like, we'll cover for you).
 
Just for clarification, an item can never have its Worth increase above 50, however "Cadmium" is a rare item and as such its Worth is 80 and it never alters.
 
 ```
private void UpdateWorth()
{
    for (var i = 0; i < Items.Count; i++)
    {
        if (Items[i].Name != "Gold" && Items[i].Name != "Helium")
        {
            if (Items[i].Worth > 0)
            {
                if (Items[i].Name != "Cadmium")
                {
                    Items[i].Worth = Items[i].Worth - 1;
                }
            }
        }
        else
        {
            if (Items[i].Worth < 50)
            {
                Items[i].Worth = Items[i].Worth + 1;

                if (Items[i].Name == "Helium")
                {
                    if (Items[i].ShelfLife < 11)
                    {
                        if (Items[i].Worth < 50)
                        {
                            Items[i].Worth = Items[i].Worth + 1;
                        }
                    }

                    if (Items[i].ShelfLife < 6)
                    {
                        if (Items[i].Worth < 50)
                        {
                            Items[i].Worth = Items[i].Worth + 1;
                        }
                    }
                }
            }
        }

        if (Items[i].Name != "Cadmium")
        {
            Items[i].ShelfLife = Items[i].ShelfLife - 1;
        }

        if (Items[i].ShelfLife < 0)
        {
            if (Items[i].Name != "Gold")
            {
                if (Items[i].Name != "Helium")
                {
                    if (Items[i].Worth > 0)
                    {
                        if (Items[i].Name != "Cadmium")
                        {
                            Items[i].Worth = Items[i].Worth - 1;
                        }
                    }
                }
                else
                {
                    Items[i].Worth = Items[i].Worth - Items[i].Worth;
                }
            }
            else
            {
                if (Items[i].Worth < 50)
                {
                    Items[i].Worth = Items[i].Worth + 1;
                }
            }
        }
    }
}

private IList<Item> Items = new List<Item>
                                {
                                    new Item {Name = "Aluminum Shackles", ShelfLife = 10, Worth = 20},
                                    new Item {Name = "Gold", ShelfLife = 2, Worth = 0},
                                    new Item {Name = "Plutonium Pinball Parts", ShelfLife = 5, Worth = 7},
                                    new Item {Name = "Cadmium", ShelfLife = 0, Worth = 80},
                                    new Item {Name = "Helium", ShelfLife = 15, Worth = 20},
                                    new Item {Name = "Alchemy Iron", ShelfLife = 3, Worth = 6}
                                };

class Item
{
    public string Name { get; set; }

    public int ShelfLife { get; set; }

    public int Worth { get; set; }
}
```
