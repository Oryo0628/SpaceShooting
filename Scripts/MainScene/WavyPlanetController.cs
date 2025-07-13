using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyPlanetController : MonoBehaviour
{
    public float fallSpeed = 2f;        // 落下速度
    public float waveAmplitude = 1f;    // 横振れの幅
    public float waveFrequency = 2f;    // 横振れの速さ

    private float startX;
    private float startY;
    private float time;
    const int point = 100;
    public int Point => point;
     public PlanetType MoveType;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        MoveType = GetComponent<PlanetType>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (MoveType.Type == PlanetType.PlanetMoveType.Top)
        {
            float offsetX = Mathf.Sin(time * waveFrequency) * waveAmplitude;
            transform.position = new Vector3(startX + offsetX, transform.position.y - fallSpeed * Time.deltaTime, 0);
        }
        else if (MoveType.Type == PlanetType.PlanetMoveType.Left)
        {
            float offsetY = Mathf.Sin(time * waveAmplitude) * waveAmplitude;
            transform.position = new Vector3(transform.position.x + fallSpeed * Time.deltaTime, startY + offsetY, 0);
        }
        else if (MoveType.Type == PlanetType.PlanetMoveType.Right)
        {
            float offsetY = Mathf.Sin(time * waveAmplitude) * waveAmplitude;
            transform.position = new Vector3(transform.position.x - fallSpeed * Time.deltaTime, startY + offsetY, 0);
        }
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
