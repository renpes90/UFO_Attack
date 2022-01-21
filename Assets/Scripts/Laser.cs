using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20.0f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(this.gameObject, 3.0f);
    }

}
