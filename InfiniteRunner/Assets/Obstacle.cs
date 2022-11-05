using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(-8 * Time.deltaTime, 0f, 0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
        }
    }
}
