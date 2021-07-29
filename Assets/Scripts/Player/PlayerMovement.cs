﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    // Vector3's
    private Vector3 difference;
    private Vector3 firstPosition;
    private Vector3 mousePosition;


    private Settings settings;
    private PlayerController playerController;
    private Camera orthoGraphicCamera;
    // Start is called before the first frame update
    void Start()
    {
        settings = ObjectManager.Instance.Settings;
        playerController = PlayerController.Instance;
        orthoGraphicCamera = ObjectManager.Instance.OrthographicCamera;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.IsPlaying)
        {
            firstPosition = Vector3.Lerp(firstPosition,mousePosition, .1f);
            if (Input.GetMouseButtonDown(0))
            {
                MouseDown(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                MouseUp();
            }
            else if (Input.GetMouseButton(0))
            {
                MouseHold(Input.mousePosition);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -settings.XMovementRange, settings.XMovementRange), transform.position.y, transform.position.z);
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, settings.MinScale, settings.MaxScale), Mathf.Clamp(transform.localScale.y, settings.MinScale, settings.MaxScale), transform.localScale.z);
        }
        
    }

    private void FixedUpdate()
    {
        if (playerController.IsPlaying)
        {
            playerRigidbody.velocity = Vector3.Lerp(playerRigidbody.velocity, new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y, settings.Speed), 1f);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x + transform.localScale.x * -difference.y, transform.localScale.y + transform.localScale.y * difference.y, transform.localScale.z), .01f);

        }

    }
    private void MouseDown(Vector3 inputPosition)
    {
        mousePosition = orthoGraphicCamera.ScreenToWorldPoint(inputPosition);
        firstPosition = mousePosition;
    }

    private void MouseHold(Vector3 inputPosition)
    {
        mousePosition = orthoGraphicCamera.ScreenToWorldPoint(inputPosition);
        difference = mousePosition - firstPosition;
        difference *= settings.Sensivity;
    }

    private void MouseUp()
    {
        difference = Vector3.zero;
    }
}
