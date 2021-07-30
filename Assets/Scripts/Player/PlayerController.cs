using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance = null;

    private GameManager gameManager;
    private ObjectManager objectManager;
    private Settings settings;

    private Rigidbody playerRigidbody;

    private bool isPlaying = false;
    private bool isGameOver = false;
    private bool isGameComplete = false;

    public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
    public bool IsGameComplete { get => isGameComplete; set => isGameComplete = value; }

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
        settings = objectManager.Settings;
        gameManager.GameOver += GameOver;
        gameManager.GameComplete += GameComplete;
        gameManager.GameComplete += Thumble;


        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IProperty>() != null) 
        {
            collision.gameObject.GetComponent<IProperty>()?.Interact();
        }
        else
        {
            collision.gameObject.transform.parent.GetComponent<IProperty>()?.Interact();
        }
    }
    private void GameOver()
    {
        isPlaying = false;
        isGameOver = true;
        playerRigidbody.velocity = Vector3.zero;
        objectManager.TapText.gameObject.SetActive(true);
        objectManager.TapText.text = Constants.TRY_AGAIN_TEXT;
        
    }

    private void GameComplete()
    {

        isPlaying = false;
        isGameComplete = true;
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.freezeRotation = false;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX & RigidbodyConstraints.FreezeRotationY;
        objectManager.TapText.gameObject.SetActive(true);
        objectManager.TapText.text = Constants.NEXT_LEVEL_TEXT;
        LevelManager.Instance.LevelIndex++;
        Invoke(Constants.LAUNCH_CONFETTI, 1f);
    }

    private void LaunchConfetti()
    {
        Instantiate(objectManager.Confetti, new Vector3(objectManager.TapText.transform.position.x, objectManager.TapText.transform.position.y, transform.position.z), Quaternion.identity);
        //Confetti.Instance.LaunchEffect();
    }

    private void Thumble()
    {
        transform.position = new Vector3(transform.position.x, .5f, transform.position.z);
        transform.GetChild(0).position = new Vector3(transform.GetChild(0).position.x, 0, transform.GetChild(0).position.z);
        playerRigidbody.freezeRotation = false;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX & RigidbodyConstraints.FreezeRotationY;
        playerRigidbody.useGravity = true;
        playerRigidbody.AddForce(transform.forward * settings.ThumbleSpeed);
    }
}
