using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallEventsController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);//Pooling
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene(2);
        }
    }
}
