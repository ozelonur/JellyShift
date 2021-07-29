using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance = null;

    private GameManager gameManager;
    private ObjectManager objectManager;

    private Rigidbody playerRigidbody;

    private bool isPlaying = false;
    private bool isGameOver = false;

    public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

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
        gameManager = GameManager.Instance;
        objectManager = ObjectManager.Instance;
        gameManager.GameOver += GameOver;
        gameManager.GameComplete += GameComplete;

        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.parent.GetComponent<IProperty>()?.Interact();
    }
    private void GameOver()
    {
        isPlaying = false;
        IsGameOver = true;
        playerRigidbody.velocity = Vector3.zero;
        objectManager.TapText.gameObject.SetActive(true);
        objectManager.TapText.text = Constants.TRY_AGAIN_TEXT;
        
    }

    private void GameComplete()
    {
        isPlaying = false;
        IsGameOver = true;
        playerRigidbody.velocity = Vector3.zero;
        objectManager.TapText.gameObject.SetActive(true);
        objectManager.TapText.text = Constants.TRY_AGAIN_TEXT;
    }
}
