using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject laserPrefab;

    public float fireRate = 0.5f;

    public float canFire = -1f;

    public Vector3 direction = Vector3.up;

    public int score;

    private UI_Manager uiManager;

    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        if (uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }

    }

    void Update()
    {
        Vector3 position = this.transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += this.speed * Time.deltaTime;
        }

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);
        this.transform.position = position;

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Time.time > canFire)
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        canFire = Time.time + fireRate;

        Instantiate(laserPrefab, transform.position + new Vector3(0, 2.0f, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            uiManager.GameOverSequence();
            Destroy(this.gameObject);
        }
        
    }

    public void AddScore(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

}
