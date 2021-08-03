using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;
    private Levels level;
    public int LevelIndex { get => PlayerPrefs.GetInt(Constants.LEVEL_INDEX, 1); set => PlayerPrefs.SetInt(Constants.LEVEL_INDEX, value); }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        level = Resources.Load<Levels>("Levels/" + LevelIndex);

        Instantiate(level.LevelPrefabs);
    }


}
