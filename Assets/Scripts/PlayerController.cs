using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 4.2f;
    public float xRange = 10.0f;
    public float zRange = 17.0f;

    private Rigidbody playerRb;
    public float playerForce = 20;
    public bool gameOver = false;
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayer();
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
     /*   if (collision.gameObject.CompareTag("win"))
        {
            if (!gameOver)
            {
                win = true;
                Debug.Log("You Win!");
            }
        }*/
    }
    void MovePlayer()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.x > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (!gameOver)
        {
            if (!win)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    playerRb.AddForce(Vector3.forward * playerForce, ForceMode.Impulse);
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    playerRb.AddForce(Vector3.back * playerForce, ForceMode.Impulse);
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    playerRb.AddForce(Vector3.left * playerForce, ForceMode.Impulse);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    playerRb.AddForce(Vector3.right * playerForce, ForceMode.Impulse);
                }
            }
        }
    }
}
