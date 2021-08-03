using UnityEngine;
using DG.Tweening;

public class Corner : MonoBehaviour, IProperty
{
    private PlayerController player;
    private RoadManager roadManager;

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
 
        GetComponent<Collider>().enabled = false;
    }

    private void ChangeRoadPivot()
    {
        RoadManager.Instance.ChangeRoadPivot();
    }
}
