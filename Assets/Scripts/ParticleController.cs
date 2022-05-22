using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("WaitForHide", 1.5f);
    }

    private void WaitForHide()
    {
        gameObject.SetActive(false);
    }
}
