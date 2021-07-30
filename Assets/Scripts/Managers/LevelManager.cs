using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;
    private Levels levels;
    public int LevelIndex { get => PlayerPrefs.GetInt(Constants.LEVEL_INDEX, 0); set => PlayerPrefs.SetInt(Constants.LEVEL_INDEX, value); }

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
        levels = ObjectManager.Instance.Levels;
        if (LevelIndex >= levels.LevelPrefabs.Length)
        {
            LevelIndex = 0;
        }

        Instantiate(levels.LevelPrefabs[LevelIndex]);
    }


}
