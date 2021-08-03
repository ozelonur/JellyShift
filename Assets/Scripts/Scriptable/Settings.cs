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
    [SerializeField] private float thumbleSpeed;
    [SerializeField] private float distance;
    [SerializeField] private float feewerTime;



    public float Speed { get => speed; }
    public float Sensivity { get => sensivity; }
    public float XMovementRange { get => xMovementRange; }
    public float MaxScale { get => maxScale; }
    public float MinScale { get => minScale; }
    public float ThumbleSpeed { get => thumbleSpeed; }
    public float Distance { get => distance; }
    public float FeewerTime { get => feewerTime; }

}
