using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public float speed = 150.0f;
    public Text score;
    public Text gameoverText;
    private int count = 0;

    bool gameover = false;
    bool win = false;
    Rigidbody2D rigid;// = GetComponent<Rigidbody2D>();
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

    }

    void Update()
    {

        if (count >= 180) {
            win = true;

        }

        if (gameover)
        {

            gameoverText.text = "TRY AGAIN";
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        }
        if (win)
        {
            gameoverText.text = "YOU  WIN";
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }


    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed += 2;
        }
        else if (col.gameObject.tag == "green")
        {
            count += 1;
            score.text = count.ToString();
        }
        else if (col.gameObject.tag == "pink")
        {
            count += 2;
            score.text = count.ToString();
        }
        else if (col.gameObject.tag == "blue")
        {
            count += 3;
            score.text = count.ToString();
        }
        else if (col.gameObject.tag == "yellow")
        {
            count += 4;
            score.text = count.ToString();
        }

        else if (col.gameObject.tag == "red")
        {
            count += 5;
            score.text = count.ToString();
            
        }
        else if (col.gameObject.tag == "Gameover")
        {
            print("HIT");
            gameover = true;

        }
    }
}
