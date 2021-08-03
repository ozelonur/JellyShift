using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour, IProperty
{
    private GameManager gameManager;
    private PlayerController player;
    private CameraController cameraController;

    private Collider obstacleCollider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = PlayerController.Instance;
        cameraController = CameraController.Instance;
        obstacleCollider = GetComponent<Collider>();
    }

    public void Interact()
    {
        player.transform.DOMoveZ(player.transform.position.z - .25f, .15f);
        cameraController.cameraAction();
        obstacleCollider.enabled = false;
        transform.DOMoveY(transform.position.y - 3f, 1.5f);
        //Invoke(Constants.GAME_OVER, .2f);
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }
}
