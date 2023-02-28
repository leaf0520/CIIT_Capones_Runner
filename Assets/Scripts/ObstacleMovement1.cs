using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstacleMovement1 : MonoBehaviour
{
    public Vector3 Rotation;
    public float Duration;
    public int LoopCount;
    public LoopType Loop;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(Rotation, Duration, RotateMode.LocalAxisAdd).SetLoops(LoopCount, Loop).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
