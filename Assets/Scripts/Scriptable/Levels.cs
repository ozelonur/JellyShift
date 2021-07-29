using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Level", order = 1)]
public class Levels : ScriptableObject
{
    [SerializeField] private GameObject[] levelPrefabs;

    public GameObject[] LevelPrefabs { get => levelPrefabs; set => levelPrefabs = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
