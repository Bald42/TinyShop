using System.Collections.Generic;
using UnityEngine;

public class HashSetDemo : MonoBehaviour
{
    private HashSet<string> _purchasedItemIds = new ();

    private void Start()
    {
        RegisterPurchase("Ботинок");
        RegisterPurchase("Ботинок");
    }

    private void RegisterPurchase(string itemId)
    {
        if (_purchasedItemIds.Add(itemId))
        {
            Debug.Log($"Первая покупка {itemId}");
        }
        else
        {
            Debug.Log($"Товар {itemId} уже покупали");
        }
    }
}