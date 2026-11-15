using System.Collections.Generic;
using UnityEngine;

public class CollectionsDemo : MonoBehaviour
{
    // [learn] struct = value type: из списка (_itemStacks[i]) и из foreach мы получаем КОПИЮ, а не сам элемент.
    // [learn] Поэтому менять поле прямо в списке нельзя (CS1612 / CS1654): достаём копию, меняем, кладём обратно.
    private struct ItemStack
    {
        // [learn] публичных полей быть не должно
        public string Id;
        public int Amount;
    }

    // [learn] Склад: стопки предметов. Id уникален, на один Id одна стопка.
    private List<ItemStack> _itemStacks = new List<ItemStack>();

    private void Start()
    {
        AddItem("Чай");
        AddItem("Хлеб");
        AddItem("Чай");
        AddItem("Чай");
        AddItem("Колбаса");
        AddItem("Хлеб");
        ViewLog("green");
        RemoveItems("Хлеб");
        ViewLog("yellow");
        RemoveItemsSecondVariant("Чай");
        ViewLog("red");
    }

    // [learn] Только читаем список и ничего в нём не меняем, поэтому foreach: короче и нет возни с индексами.
    private void ViewLog(string color)
    {
        foreach (var itemStack in _itemStacks)
        {
            Debug.Log($"<color={color}>Id = {itemStack.Id} Amount = {itemStack.Amount}</color>");
        }
    }
    
    // [learn] Удаляем по ходу, поэтому for С КОНЦА: RemoveAt сдвигает влево только то, что правее i, а оно уже проверено.
    // [learn] Слева направо следующий элемент съехал бы на место i и был бы пропущен, без всякой ошибки.
    // [learn] Индексы списка: последний = Count - 1, первый = 0, и нулевой тоже надо проверить.
    private void RemoveItems(string id)
    {
        for (int i = _itemStacks.Count - 1; i >= 0; i--)
        {
            if (_itemStacks[i].Id == id)
            {
                _itemStacks.RemoveAt(i);
            }
        }
    }
    
    // [learn] Короче и правильнее всех: RemoveAll принимает не список жертв, а правило (Predicate), лямбду "x => условие".
    // [learn] Один проход, без лишних списков и аллокаций. Это метод List, не LINQ.
    private void RemoveItemsSecondVariant(string id)
    {
        _itemStacks.RemoveAll(x=> x.Id == id);
    }
    
    // [learn] ПЛОХОЙ пример: _itemStacks[index] = item внутри foreach по этому же списку увеличивает его _version.
    // [learn] Не падает только из-за return сразу после: foreach не делает следующий шаг, а он сверяет _version.
    // [learn] Закомментируй return, и будет InvalidOperationException. Ручной index внутри foreach значит, что нужен for.
    private void AddItemSecondVariant(string id)// [learn]
    {
        int index = 0;
        foreach (var itemStack in _itemStacks)
        {
            if (itemStack.Id == id)
            {
                var item = itemStack;
                item.Amount++;
                _itemStacks[index] = item;
                return;
            }
            index++;
        }

        AddNewStack(id);
    }
    
    // [learn] for по индексу: перечислителя (enumerator) нет, сверять _version некому, замена элемента безопасна.
    // [learn] ItemStack это struct: _itemStacks[i].Amount++ не скомпилируется (CS1612), поэтому копия, изменение, запись обратно.
    private void AddItem(string id)
    {
        for (int i = 0; i < _itemStacks.Count; i++)
        {
            if (_itemStacks[i].Id == id)
            {
                var item = _itemStacks[i];
                item.Amount++;
                _itemStacks[i] = item;
                return;
            }
        }

        AddNewStack(id);
    }

    // [learn] new ItemStack() даёт struct с полями по умолчанию (Id = null, Amount = 0), поэтому Amount ставим в 1 явно.
    private void AddNewStack(string newId)
    {
        var item = new ItemStack();
        item.Id = newId;
        item.Amount = 1;
        _itemStacks.Add(item);
    }
}