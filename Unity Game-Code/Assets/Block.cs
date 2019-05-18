using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Block : MonoBehaviour {
    public int scoreboard = 0;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);
        scoreboard++;
    }
}
