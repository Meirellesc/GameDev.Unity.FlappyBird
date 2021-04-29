using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;

    [SerializeField]
    Transform gameOver;

    [SerializeField]
    Text scoreView;

    [SerializeField]
    float jump;

    [SerializeField]
    int score;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if jump
        if(Input.GetKeyDown(KeyCode.Space)  || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody.velocity = Vector2.up * jump;
        }

    }

    /// <summary>
    /// Method to detect collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AddScore"))
        {
            score += 1;
            scoreView.text = score.ToString();
        }
        else if(collision.CompareTag("Pipe"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        enabled = false;

        gameOver.gameObject.SetActive(true);

        Invoke("Pause", 0);
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }
}
