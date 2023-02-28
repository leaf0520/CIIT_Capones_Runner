using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    public Vector3 Rotation;
    public float Duration;
    public int LoopCount;
    public LoopType Loop;

    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float LRDuration;


    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(Rotation, Duration, RotateMode.LocalAxisAdd).SetLoops(LoopCount, Loop).SetEase(Ease.Linear);
        StartMovement();

    }
    public void StartMovement(){
        transform.DOLocalMove(EndPosition, LRDuration).OnComplete(() => RestartMovement());
    }

    public void RestartMovement()
    {
        transform.DOLocalMove(StartPosition, LRDuration).OnComplete(() => StartMovement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
