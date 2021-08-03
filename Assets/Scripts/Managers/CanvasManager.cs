using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance = null;

    [SerializeField] private Text diamondText;
    [SerializeField] private Text tapText;

    public Text TapText { get => tapText; set => tapText = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateDiamondText();
        TapText.text = Constants.TAP_TO_PLAY_TEXT;
    }
    public void UpdateDiamondText()
    {
        diamondText.text = PlayerPrefs.GetInt(Constants.DIAMOND_COUNT, 0).ToString();
    }
}
