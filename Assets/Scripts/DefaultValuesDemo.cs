using System.Collections.Generic;
using UnityEngine;

public class DefaultValuesDemo : MonoBehaviour
{
    [SerializeField] private string botName;
    [SerializeField] private List<int> botLives;
    
    private int _coins;  //[learn] default = 0
    private string _playerName; //[learn] default = null
    private List<int> _scores; //[learn] default = null
    private Vector3 _spawnPoint; //[learn] default = Vector3.zero
    private ItemType _itemType; //[learn] default = None
    private int? _bestScore;  //[learn] default = null
    
    private void Start()
    {
        // Debug.Log(_playerName.Length); //[learn] выдаст NullReferenceException, тк default = null
        // Debug.Log(_scores.Count); //[learn] выдаст NullReferenceException, тк default = null
        Debug.Log($"_spawnPoint.x {_spawnPoint.x}"); //[learn] выдаст 0
        //[learn] выдаст false, тк default = null, а значение не присваивали
        Debug.Log($"_bestScore.HasValue {_bestScore.HasValue}");
        //[learn] выдаст 0, тк сериализованные поля заполняются их создаёт сериализатор Unit
        Debug.Log($"botName.Length {botName.Length}"); 
        //[learn] выдаст 0, тк сериализованные поля заполняются их создаёт сериализатор Unit
        Debug.Log($"botLives.Count {botLives.Count}"); 
    }
    
    private enum ItemType
    {
        None = 0, 
        Weapon = 1, 
        Armor = 2
    } 
}
