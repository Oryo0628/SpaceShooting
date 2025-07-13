using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
     public float moveAmplitude = 1f;     // 左右の動きの幅
    public float moveSpeed = 1f;         // 動く速さ

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * moveSpeed) * moveAmplitude;
        transform.position = startPosition + new Vector3(x, 0, 0);
    }
}
