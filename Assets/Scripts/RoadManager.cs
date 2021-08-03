using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static RoadManager Instance = null;

    private float distance;

    public float Distance { get => distance; set => distance = value; }

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
        Distance = PlayerController.Instance.Settings.Distance;
        transform.position = new Vector3(0, 0, Distance);
    }

    public void ChangeRoadPivot()
    {
        GameObject temp = GameObject.Find(Constants.TEMP);
        while (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<Transform>().parent = temp.transform;
        }

        transform.position = new Vector3(0, 0, Distance);


        while (temp.transform.childCount > 0)
        {
            temp.transform.GetChild(0).GetComponent<Transform>().parent = transform;
        }

    }


}
