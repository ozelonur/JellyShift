using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance = null;
    private GameObject player;
    public Action cameraAction;

    private Vector3 offset = new Vector3(1.5f, 1.25f, -2);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        cameraAction += DoShake;
        player = PlayerController.Instance.gameObject;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    private void DoShake()
    {
        transform.DOShakeRotation(.1f, 8, 3);
    }
}
