using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControl : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    GameObject firePrefab;
    const float motiveForce = 6;
    GameControl gameControl;
    // Start is called before the first frame update
    void Start()
    {
        gameControl = Camera.main.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0)
        {
            position.x += horizontalInput * motiveForce * Time.deltaTime;
        }
        if (verticalInput != 0)
        {
            position.y += verticalInput * motiveForce * Time.deltaTime;
        }
        transform.position = position;
        if (Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioControl>().Fire();
            Vector3 firePosition = gameObject.transform.position;
            firePosition.y += 1;
            Instantiate(firePrefab, firePosition, Quaternion.identity);
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioControl>().SpaceshipExplosion();
            gameControl.FinishGame();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
