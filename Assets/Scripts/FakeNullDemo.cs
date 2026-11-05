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
        // [learn] Будет тру, фолс и MRE
        // Потому что таргет унитчтожен и равен нулл, ссылка на объект осталась и ReferenceEquals выдал фолс,
        // тк проверяет ссылку, в последнем ошибка, тк пытаемся получить имя из унечтоженного объекта
        Debug.Log($"<color=green>target == null {target == null}</color>");
        Debug.Log($"<color=green>ReferenceEquals(target, null) {ReferenceEquals(target, null)}</color>");
        Debug.Log($"<color=green>target?.name {target?.name}</color>");
    }
}
