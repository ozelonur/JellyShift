using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance = null;

    [SerializeField] private Levels levels;
    [SerializeField] private Camera orthographicCamera;
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private GameObject playerCopy;
    [SerializeField] private GameObject playerShadow;



    public Levels Levels { get => levels; set => levels = value; }
    public Camera OrthographicCamera { get => orthographicCamera; set => orthographicCamera = value; }
    public ParticleSystem Confetti { get => confetti; set => confetti = value; }
    public GameObject PlayerCopy { get => playerCopy; set => playerCopy = value; }
    public GameObject PlayerShadow { get => playerShadow; set => playerShadow = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
