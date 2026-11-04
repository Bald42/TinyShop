using UnityEngine;

public class ValueVsReferenceDemo : MonoBehaviour
{
	private void Start()
	{
		var classOriginal = new TestClass();
		var structOriginal = new TestStructure();
		classOriginal.X = 1;
		structOriginal.X = 1;
		var classCopy = classOriginal;
		var structCopy = structOriginal;
		classCopy.X = 5;
		structCopy.X = 5;
		// [learn] TestClass ссылочный, поэтому classOriginal и classCopy — две переменные со ссылкой на один объект,
		// и X у них один
		// structCopy значимый, поэтому у нас два разных экземпляра и два разных Х
		Debug.Log($"{classOriginal.X}, {classCopy.X}, {structOriginal.X}, {structCopy.X}");
	}
}