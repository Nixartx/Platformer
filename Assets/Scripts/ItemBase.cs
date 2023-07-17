using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Databases/Items")]
public class ItemBase : ScriptableObject
{
    [SerializeField] [HideInInspector] private List<Item> items;
    [SerializeField] private Item currentItem;
    private int _currentIndex;

    public void CreateItem()
    {
        if (items == null)
            items = new List<Item>();
        
        Item item = new Item();
        items.Add(item);
        currentItem = item;
        _currentIndex = items.Count-1;
    }

    public void RemoveItem()
    {
        if (items == null|| currentItem == null)
            return;
        items.Remove(currentItem);
        if (items.Count > 0)
        {
            currentItem = items[0];
            _currentIndex = 0;
        }
        else CreateItem();
    }

    public void NextItem()
    {
        if (_currentIndex + 1 < items.Count)
            _currentIndex++;
        currentItem = items[_currentIndex];
    }

    public void PrevItem()
    {
        if (_currentIndex > 0)
            _currentIndex--;
        currentItem = items[_currentIndex];
    }

    public Item GetItemByID(int id)
    {
        return items.Find(item => item.ID == id);
    }


}

[System.Serializable]
public class Item
{
    [SerializeField] private int _id;
    public int ID
    {
        get { return _id; }
    }
    
    [SerializeField] private string _name;
    public string Name
    {
        get { return _name; }
    }
    
    [SerializeField] private string _desc;
    public string Desc
    {
        get { return _desc; }
    }
    
    [SerializeField] private BuffType _type;
    public BuffType Type
    {
        get { return _type; }
    }
    
    [SerializeField] private int _value;
    public int Value
    {
        get { return _value; }
    }

    [SerializeField] private Sprite _icon;
    public Sprite Icon
    {
        get { return _icon; }
    }

}
