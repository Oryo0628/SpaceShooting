using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAvoidMeteor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRange = 3f;

    public float minX = -2.5f; // 画面左端
    public float maxX = 2.5f;  // 画面右端

    private void Update()
    {
        // 近くの隕石を探す
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject meteor in meteors)
        {
            float distance = Vector2.Distance(transform.position, meteor.transform.position);
            if (distance < closestDistance && meteor.transform.position.y > transform.position.y)
            {
                closest = meteor;
                closestDistance = distance;
            }
        }

        // 移動方向を決める
        float moveX = 0;

        if (closest != null && closestDistance < detectionRange)
        {
            if (closest.transform.position.x < transform.position.x)
                moveX = 1;
            else
                moveX = -1;
        }
        // else
        // {
        //     // 元の位置（中央）へ戻る
        //     float centerX = 0;
        //     moveX = centerX - transform.position.x;
        // }

        // 移動処理 + 画面端制限
        Vector3 newPosition = transform.position + new Vector3(moveX * moveSpeed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); // 画面外に出ないよう制限
        transform.position = newPosition;
    
    }
}
