using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallEventsController : MonoBehaviour
{
    [Header("Get bonus score")]
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Show collected particles bonus")]
    [SerializeField] private int amountParticles = 5;
    [SerializeField] private List<GameObject> listParticlePooling;
    [SerializeField] private GameObject particle;

    private void Start()
    {
        score = 0;

        InstantiateParticlesInScene();
    }

    private void InstantiateParticlesInScene()
    {
        for (int i = 0; i < amountParticles; i++)
        {
            GameObject newParticle = Instantiate(particle, transform.position, Quaternion.identity);
            listParticlePooling.Add(newParticle);
            newParticle.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            ShowParticle();

            score++;
            scoreText.text = score.ToString();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene(2);
        }
    }

    private void ShowParticle()
    {
        for (int i = 0; i < amountParticles; i++)
        {
            if (listParticlePooling[i].activeSelf == false)
            {
                listParticlePooling[i].transform.position = transform.position;
                listParticlePooling[i].SetActive(true);

                break;
            }
        }
    }
}
