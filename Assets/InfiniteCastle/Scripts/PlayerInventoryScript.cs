using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventoryScript : MonoBehaviour
{

    [SerializeField]
    private Text InventoryText;

    public List<GameObject> Items = new List<GameObject>();

    private void UpdateText()
    {
        InventoryText.text = "";
        foreach (GameObject item in Items)
        {
            ObjectScript scriptItem = item.GetComponent<ObjectScript>();
            if (scriptItem)
            {
                InventoryText.text += scriptItem.Name +" ";
            }
        }
    }

    public void AddItem(GameObject item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            UpdateText();
        }
    }

    public void RemoveItem(string  itemName)
    {
        GameObject itemToRemove;
        foreach( GameObject item in Items)
        {
          if(item.name == itemName)
            {
                Items.Remove(item);
                UpdateText();
            }
            break;
            
        }
        
    }
}
