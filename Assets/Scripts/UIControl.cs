using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    int score;
    [SerializeField]
    GameObject nameofGameText = default;
    [SerializeField]
    GameObject finishText = default;
    [SerializeField]
    GameObject Playbutton = default;
    [SerializeField]
    Text scoreText = default;
    // Start is called before the first frame update
    void Start()
    {
        finishText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }
    public void GameStarted()
    {
        score = 0;
        UpdateScore();
        nameofGameText.gameObject.SetActive(false);
        Playbutton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        finishText.gameObject.SetActive(false);
    }
    void UpdateScore()
    {
        scoreText.text = "Puan: " + score;
    }
    public void GameOver()
    {
        finishText.gameObject.SetActive(true);
        Playbutton.gameObject.SetActive(true);
    }
    public void AsteroidExtermination(GameObject asteroid)
    {
        switch (asteroid.gameObject.name[8])
        {
            case '1':
                score += 15;
                UpdateScore();
                break;
            case '2':
                score += 5;
                UpdateScore();
                break;
            case '3':
                score += 10;
                UpdateScore();
                break;
            default:
                break;
        }
    }
}
