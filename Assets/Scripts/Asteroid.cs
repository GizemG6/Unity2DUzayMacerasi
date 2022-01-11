using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab = default;

    GameControl gameControl;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        gameControl = Camera.main.GetComponent<GameControl>();
        float direction = Random.Range(0f, 1.0f);
        if (direction < 0.5f)
        {
            rb2d.AddForce(new Vector2(Random.Range(-2.5f, -1.5f), Random.Range(-2.5f, -1.5f)), ForceMode2D.Impulse);
            rb2d.AddTorque(direction * 10.0f);
        }
        else
        {
            rb2d.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.5f)), ForceMode2D.Impulse);
            rb2d.AddTorque(-direction * 10.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fire")
        {
            gameControl.AsteroidExtermination(gameObject);
            DestroyAsteroid();
        }
    }
    public void DestroyAsteroid()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
