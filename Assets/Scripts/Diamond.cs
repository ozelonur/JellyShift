using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Diamond : MonoBehaviour, IProperty
{
    public static Diamond Instance = null;

    public int DiamondCount { get => PlayerPrefs.GetInt(Constants.DIAMOND_COUNT, 0); set => PlayerPrefs.SetInt(Constants.DIAMOND_COUNT, value); }

    private CanvasManager canvasManager;

    private bool isCollided = false;

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
        canvasManager = CanvasManager.Instance;
        

        transform.DORotate(new Vector3(transform.localEulerAngles.x, Random.Range(80, 100), transform.localEulerAngles.z), .2f, RotateMode.Fast).SetLoops(-1, LoopType.Incremental);
    }

    public void Interact()
    {
        if (!isCollided)
        {
            DiamondCount++;
            GetComponent<Collider>().enabled = false;
            canvasManager.UpdateDiamondText();
            isCollided = true;
            Destroy(gameObject);
        }
    }
}
