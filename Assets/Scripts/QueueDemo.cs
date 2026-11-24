using System.Collections.Generic;
using UnityEngine;

public class QueueDemo : MonoBehaviour
{
    private Queue<string> _customers = new();

    private void Start()
    {
        AddToQueue("Таня");
        AddToQueue("Саша");
        AddToQueue("Женя");
        ServeNextCustomer();
        WhosNextPerson();
    }

    private void AddToQueue(string name)
    {
        _customers.Enqueue(name);
    }

    private void ServeNextCustomer()
    {
        if (_customers.TryDequeue(out string value))
        {
            Debug.Log($"Обслужили {value}");
        }
    }

    private void WhosNextPerson()
    {
        Debug.Log($"Следующий {_customers.Peek()}");
    }
}