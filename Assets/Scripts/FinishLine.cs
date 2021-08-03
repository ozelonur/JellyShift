using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour, IProperty
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void Interact()
    {
        GetComponent<Collider>().enabled = false;
        gameManager.GameComplete();
    }
}
