using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidEnemies : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
