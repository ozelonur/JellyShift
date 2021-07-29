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
    [SerializeField] private Text tapText;

    public Levels Levels { get => levels; set => levels = value; }
    public Settings Settings { get => settings; set => settings = value; }
    public Camera OrthographicCamera { get => orthographicCamera; set => orthographicCamera = value; }
    public Text TapText { get => tapText; set => tapText = value; }

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
