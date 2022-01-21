using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int score = 1;

    public int live = 1;

    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            live--;

            if (live <= 0)
            {
                if (player != null)
                {
                    player.AddScore(score);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
