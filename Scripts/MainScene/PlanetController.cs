using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    

    public float speed = 2f;

    const int point = 100;
    public int Point => point;

    public PlanetType MoveType;

    void Start()
    {
        MoveType = GetComponent<PlanetType>();
    }
    void Update()
    {
        if (MoveType.Type == PlanetType.PlanetMoveType.Top) transform.Translate(Vector3.down * speed * Time.deltaTime);
        else if (MoveType.Type == PlanetType.PlanetMoveType.Left) transform.Translate(Vector3.right * speed * Time.deltaTime);
        else if (MoveType.Type == PlanetType.PlanetMoveType.Right) transform.Translate(Vector3.left * speed * Time.deltaTime);
        
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
