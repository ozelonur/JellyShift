using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Corner : MonoBehaviour, IProperty
{
    private PlayerController player;
    private RoadManager roadManager;

    private float distance = 101.5f;


    private enum Rotations
    {
        Right,
        Left,
        None
    }

    [SerializeField] private Rotations currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;
        roadManager = RoadManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    public void Interact()
    {
        if (currentRotation == Rotations.Left)
        {
            transform.parent.transform.parent.DORotate(new Vector3(0, 0, 0), 1f);
        }
        else if (currentRotation == Rotations.Right)
        {
            transform.parent.transform.parent.DORotate(new Vector3(0, -90, 0), 1f);
        }
        Invoke(Constants.CHANGE_ROAD_PIVOT, 1.3f);
        print(player.transform.position);
        roadManager.Distance += 100;
        GetComponent<Collider>().enabled = false;
    }

    private void ChangeRoadPivot()
    {
        RoadManager.Instance.ChangeRoadPivot();
    }
}
