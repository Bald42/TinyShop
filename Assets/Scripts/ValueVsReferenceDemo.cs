using System.Collections.Generic;
using UnityEngine;

public class ValueVsReferenceDemo : MonoBehaviour
{
	private void Start()
	{
		ChangeValueInCollection();
	}

	
	private void ShowСlassAndStruct()
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

	private void ChangeValueInCollection()
	{
		List<TestStructure> list = new List<TestStructure>();
		TestStructure [] arr = new TestStructure[10]; 
		Dictionary<string, TestStructure> dictStruct = new Dictionary<string, TestStructure>();
		Dictionary<string, int>  dictInt = new Dictionary<string, int>();
		arr[0].X++;
		// list[0].X++;
		// dict["a"].X++;
		int value = 0;
		Debug.Log($"{dictInt.TryGetValue("x", out value)} {value}");
	}
}