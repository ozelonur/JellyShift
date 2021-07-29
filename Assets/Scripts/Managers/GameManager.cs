using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private ObjectManager objectManager;
    private PlayerController playerController;

    public Action GameOver;
    public Action GameComplete;
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
        objectManager = ObjectManager.Instance;
        playerController = PlayerController.Instance;
        objectManager.TapText.text = Constants.TAP_TO_PLAY_TEXT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        if (playerController.IsGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            playerController.IsPlaying = true;
            objectManager.TapText.gameObject.SetActive(false);
        }
    }
}
