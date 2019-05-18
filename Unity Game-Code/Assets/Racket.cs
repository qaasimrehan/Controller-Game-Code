using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using UnityEngine.SceneManagement;


// MADE BY QAASIM REHAN
public class Racket : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM4" +
        "",9600);

    // Movement speed
    public float speed = 150;
    float h = 0f;
    private float amountToMove;
    Scene loadedLevel;

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        loadedLevel = SceneManager.GetActiveScene();
    }

    void FixedUpdate()
    {
       
       // Debug.Log(h);
  h = Input.GetAxisRaw("Horizontal");
        if (sp.IsOpen)
        {
            try
            {
                // h = sp.ReadByte();
                // moveObject(sp.ReadByte());
                //    print(sp.ReadByte());
                //   print(sp.ReadByte());

                h = sp.ReadByte();
               // print(h);
                if (h == 76)
                {
                    h = -1;
                    print("LEFT");
                    GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
                }
                if (h == 82)
                {
                    h = 1;
                    print("RIGHT");
                    GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
                }
                if (h == 78)
                {
                    h = 0;
                   print("STOP");
                    GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
                }
                if (h == 83) {
                    SceneManager.LoadScene(loadedLevel.buildIndex);
                }

            }
            catch (Exception)
            {
                //   print(e);
                //  print("ERROR");

            }


        } 

        //GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;


    }


}





