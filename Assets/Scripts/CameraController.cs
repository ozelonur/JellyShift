using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private Vector3 offset = new Vector3(1.5f, 1.25f, -2);
    // Start is called before the first frame update
    private void Start()
    {
        player = PlayerController.Instance.gameObject;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
