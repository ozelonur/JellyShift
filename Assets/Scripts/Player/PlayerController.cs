using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour, IProperty
{
    public static PlayerController Instance = null;
    [SerializeField] private Settings settings;

    private GameManager gameManager;
    private ObjectManager objectManager;
    private CanvasManager canvasManager;


    private Rigidbody playerRigidbody;

    private bool isPlaying = false;
    private bool isGameOver = false;
    private bool isGameComplete = false;

    private int passedObstacleCount = 0;

    public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
    public bool IsGameComplete { get => isGameComplete; set => isGameComplete = value; }
    public int PassedObstacleCount { get => passedObstacleCount; set => passedObstacleCount = value; }
    public Settings Settings { get => settings; set => settings = value; }

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
        canvasManager = CanvasManager.Instance;
        gameManager.GameOver += GameOver;
        gameManager.GameComplete += GameComplete;
        gameManager.GameComplete += Thumble;


        playerRigidbody = GetComponent<Rigidbody>();

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
        canvasManager.TapText.gameObject.SetActive(true);
        canvasManager.TapText.text = Constants.TRY_AGAIN_TEXT;
        
    }

    private void GameComplete()
    {

        isPlaying = false;
        isGameComplete = true;
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.freezeRotation = false;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX & RigidbodyConstraints.FreezeRotationY;
        canvasManager.TapText.gameObject.SetActive(true);
        canvasManager.TapText.text = Constants.NEXT_LEVEL_TEXT;
        LevelManager.Instance.LevelIndex++;
        Invoke(Constants.LAUNCH_CONFETTI, 1f);
    }

    private void LaunchConfetti()
    {
        Instantiate(objectManager.Confetti, new Vector3(canvasManager.TapText.transform.position.x, canvasManager.TapText.transform.position.y, transform.position.z), Quaternion.identity);
    }

    private void Thumble()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 3.5f), 1f);
        transform.DORotate(new Vector3(180, 0, 0), 1f);
    }

    public void Interact()
    {
        transform.DOMoveZ(transform.position.z + 1, .2f);
    }
}
