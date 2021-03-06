using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<InventoryItem, int> inventory;

    public enum Category
    {
        BattleItems,
        Healing
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Dictionary<InventoryItem, int>(); 
    }

    public void AddItem(InventoryItem item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] += 1;
        } else
        {
            inventory[item] = 1;
        }
    }

    public bool RemoveItem(InventoryItem item)
    {
        if (!inventory.ContainsKey(item))
        {
            return false;
        }
        inventory[item] -= 1;
        if (inventory[item] == 0)
        {
            inventory.Remove(item);
        }
        return true;
    }
    
    // Returns a dictionary with the name and number of items in said Inventory object
    public Dictionary<string, int> GetItemList()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (InventoryItem item in inventory.Keys)
        {
            dict[item.GetIDName()] = inventory[item];
        }
        return dict;
    }
}
