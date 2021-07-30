using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    LayerMask layerMask;
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        layerMask = LayerMask.GetMask(Constants.DRAWER_LAYER);
        if (Physics.Raycast(cameraTransform.position,transform.forward, 20.0f, layerMask))
        {
            print("Hit to a drawer!");
        }
    }
}
