using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var score = other.gameObject.GetComponent<EnemyScore>();
            ScoreManager.AddScore(score.Score); // 例：100点加算
            Destroy(other.gameObject); // 隕石を破壊
            Destroy(gameObject);       // 弾も消える
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
