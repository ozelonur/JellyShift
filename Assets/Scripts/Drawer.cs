using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drawer : MonoBehaviour
{
    private PlayerController player;
    private FeewerManager feewerManager;

    // Start is called before the first frame update
    private void Start()
    {
        player = PlayerController.Instance;
        feewerManager = FeewerManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PLAYER))
        {
            player.PassedObstacleCount++;
            other.transform.parent.GetComponent<PlayerMovement>().Speed += .4f;

            if (player.PassedObstacleCount >= 4)
            {
                feewerManager.Feewer();
                player.PassedObstacleCount = 0;
            }
        }
    }

}
