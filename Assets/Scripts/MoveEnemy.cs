using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}
