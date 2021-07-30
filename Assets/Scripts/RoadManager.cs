using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static RoadManager Instance = null;
    private PlayerController player;

    private float distance;
    private int childCount = 0;

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
        print(transform.childCount);
        player = PlayerController.Instance;
        Distance = ObjectManager.Instance.Settings.Distance;
        transform.position = new Vector3(0, 0, Distance);
    }

    // Update is called once per frame
    void Update()
    {

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
