using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Diamond : MonoBehaviour, IProperty
{
    public static Diamond Instance = null;

    public int DiamondCount { get => PlayerPrefs.GetInt(Constants.DIAMOND_COUNT, 0); set => PlayerPrefs.SetInt(Constants.DIAMOND_COUNT, value); }

    private Text diamondCountText;

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
        diamondCountText = ObjectManager.Instance.DiamondCountText;

        transform.DORotate(new Vector3(transform.localEulerAngles.x, Random.Range(80, 100), transform.localEulerAngles.z), .2f, RotateMode.Fast).SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (!isCollided)
        {
            DiamondCount++;
            GetComponent<Collider>().enabled = false;
            diamondCountText.text = DiamondCount.ToString();
            isCollided = true;
            Destroy(gameObject);
        }
    }
}
