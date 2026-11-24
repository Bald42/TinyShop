using System.Collections.Generic;
using UnityEngine;

public class DictionaryDemo : MonoBehaviour
{
    private Dictionary<string, int> _inventoryItems = new();

    private void Start()
    {
        AddItem("Хлеб");
        AddItem("Хлеб");
        AddItem("Чай");
        RemoveItem("Чай");
        RemoveItem("Хлеб");
        ViewLogs();
    }

    private void AddItem(string key)
    {
        if (_inventoryItems.TryGetValue(key, out int value)) // [learn] value это копия меня надо _inventoryItems[key]
        {
            // _inventoryItems[key]++; // [learn] так делать можно, но это второй поиск по ключу
            // [learn] так делать нельзя, тк сначала присвоится старое значение, а потом оно увеличится
            // _inventoryItems[key] = value++; 
            // _inventoryItems[key] = ++value; // [learn] так делать можно, но value измениться и это плохо читается
            _inventoryItems[key] = value + 1;
        }
        else
        {
            _inventoryItems.Add(key, 1);
        }
    }

    private void RemoveItem(string key)
    {
        if (_inventoryItems.TryGetValue(key, out int value))
        {
            int newValue = value - 1;
            _inventoryItems[key] = newValue;
            if (newValue == 0)
            {
                _inventoryItems.Remove(key);
            }
        }
    }

    private void ViewLogs()
    {
        foreach (var item in _inventoryItems)
        {
            Debug.Log($"<color=green>Key {item.Key} Value {item.Value}</color>");
        }
    }
}