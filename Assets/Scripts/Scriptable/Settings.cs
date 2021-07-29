using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Settings", menuName = "Settings", order = 1)]
public class Settings : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float sensivity;
    [SerializeField] private float xMovementRange;
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;



    public float Speed { get => speed; set => speed = value; }
    public float Sensivity { get => sensivity; set => sensivity = value; }
    public float XMovementRange { get => xMovementRange; set => xMovementRange = value; }
    public float MaxScale { get => maxScale; set => maxScale = value; }
    public float MinScale { get => minScale; set => minScale = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
