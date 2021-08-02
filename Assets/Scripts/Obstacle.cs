using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour, IProperty
{
    private GameManager gameManager;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = PlayerController.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interact()
    {
        player.transform.DOMoveZ(player.transform.position.z - .25f, .25f);
        Invoke(Constants.GAME_OVER, .2f);
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }
}
