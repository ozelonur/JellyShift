using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeewerManager : MonoBehaviour
{
    public static FeewerManager Instance = null;

    private PlayerController player;

    private bool isTimerOn = false;

    private float timer;

    

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
        player = PlayerController.Instance;

        timer = player.Settings.FeewerTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerOn && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            StopFeewer();
        }
    }

    public void Feewer()
    {
        isTimerOn = true;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(Constants.OBSTACLE);
        foreach (var gameObject in gameObjects)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
        }
    }

    private void StopFeewer()
    {
        isTimerOn = false;
        timer = player.Settings.FeewerTime;
        player.GetComponent<PlayerMovement>().Speed = player.Settings.Speed;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(Constants.OBSTACLE);
        foreach (var gameObject in gameObjects)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.green;
            }
        }
    }
}
