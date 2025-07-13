using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float imageHeight = 10f; // 画像の高さ（手動で入力 or 自動計算）

    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y <= -imageHeight)
        {
            Vector3 newPos = transform.position;
            newPos.y += imageHeight * 2f;
            transform.position = newPos;
        }
    }
}
