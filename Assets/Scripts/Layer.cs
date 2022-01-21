using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 direction = Vector3.right;
    private Vector3 initialPosition;
    private UI_Manager uiManager;

    private void Awake()
    {
        initialPosition = this.transform.position;
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    private void Update()
    {
        this.transform.position += this.direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        if (this.transform.childCount <= 0)
        {
            uiManager.WinSequence();
            Destroy(this.gameObject);
        }

        foreach (Transform enemy in this.transform)
        {
            if (this.direction == Vector3.right && enemy.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();
                break;
            }
            else if (this.direction == Vector3.left && enemy.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
                break;
            }
        }
    }

    private void AdvanceRow()
    {
        this.direction = new Vector3(-this.direction.x, 0.0f, 0.0f);

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }
}
