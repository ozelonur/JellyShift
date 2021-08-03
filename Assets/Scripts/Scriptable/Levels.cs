﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Level", order = 1)]
public class Levels : ScriptableObject
{
    [SerializeField] private GameObject levelPrefab;

    public GameObject LevelPrefabs { get => levelPrefab; set => levelPrefab = value; }

}
