using System.Collections;
using UnityEngine;

public class FakeNullDemo : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    private void Start()
    {
        Destroy(target);
        StartCoroutine(LogStateAfterDestroy());
    }

    private IEnumerator LogStateAfterDestroy()
    {
        yield return new WaitForEndOfFrame();
        // [learn] Будет True, False и MissingReferenceException
        // 1. Потому что таргет уничтожен. Unity перегрузил ==, он спрашивает движок «объект жив?».
        // 2. Ссылка на объект осталась и ReferenceEquals выдал False, тк проверяет ссылку.
        // 3. Ошибка, тк пытаемся получить имя из уничтоженного объекта, а ?. проверяет ссылку которая осталась
        Debug.Log($"<color=green>target == null {target == null}</color>");
        Debug.Log($"<color=green>ReferenceEquals(target, null) {ReferenceEquals(target, null)}</color>");
        Debug.Log($"<color=green>target?.name {target?.name}</color>");
    }
}