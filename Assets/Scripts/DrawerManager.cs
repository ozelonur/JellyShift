using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerManager : MonoBehaviour
{
    private LayerMask layerMask;
    private RaycastHit raycastHit;

    private GameObject playerCopy;
    private GameObject playerShadow;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask(Constants.DRAWER_LAYER);
        playerCopy = ObjectManager.Instance.PlayerCopy;
        playerShadow = ObjectManager.Instance.PlayerShadow;

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 20.0f, layerMask))
        {
            print("Hitted a drawer");
            playerCopy.transform.position = raycastHit.transform.position;
            playerCopy.transform.localScale = transform.localScale;

        }
    }
}
