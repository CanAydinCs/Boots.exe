using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 3f;

    private Rigidbody2D rg;
    private GroundCheck gc;

    private bool isGround = false;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundCheck>();
    }

    private void FixedUpdate()
    {
        //horizontal player movement
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * speed;

        //vertical player movement
        isGround = gc.IsGround;
        if (Input.GetButton("Jump") && isGround) 
        {
            rg.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if (transform.position.y < GameObject.FindGameObjectWithTag("Generator").GetComponent<RandomLevelGenerator>().lowestHeight - 20)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}