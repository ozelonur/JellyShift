using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance = null;

    [SerializeField] private Levels levels;
    [SerializeField] private Settings settings;
    [SerializeField] private Camera orthographicCamera;
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private GameObject playerCopy;
    [SerializeField] private GameObject playerShadow;

    // Text's
    [SerializeField] private Text tapText;
    [SerializeField] private Text diamondCountText;


    public Levels Levels { get => levels; set => levels = value; }
    public Settings Settings { get => settings; set => settings = value; }
    public Camera OrthographicCamera { get => orthographicCamera; set => orthographicCamera = value; }
    public Text TapText { get => tapText; set => tapText = value; }
    public ParticleSystem Confetti { get => confetti; set => confetti = value; }
    public Text DiamondCountText { get => diamondCountText; set => diamondCountText = value; }
    public GameObject PlayerCopy { get => playerCopy; set => playerCopy = value; }
    public GameObject PlayerShadow { get => playerShadow; set => playerShadow = value; }

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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
