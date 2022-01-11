using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    UIControl uicontrol;
    [SerializeField]
    GameObject spaceShipPrefab;
    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();
    GameObject spaceShip;
    [SerializeField]
    int difficulty = 1;
    [SerializeField]
    int multiplier = 5;
    List<GameObject> asteroidList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        uicontrol = GetComponent<UIControl>();
    }
    public void StartGame()
    {
        spaceShip = Instantiate(spaceShipPrefab);
        spaceShip.transform.position = new Vector3(0, ScreenCalculator.Lower + 1.5f);
        GenerateAsteroid(5);
        uicontrol.GameStarted();
    }
    void GenerateAsteroid(int number)
    {
        Vector3 position = new Vector3();
        for (int i = 0; i < number; i++)
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(ScreenCalculator.Left, ScreenCalculator.Right);
            position.y = ScreenCalculator.Upper - 1;
            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity);
            asteroidList.Add(asteroid);
        }

    }
    public void FinishGame()
    {
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().DestroyAsteroid();
        }
        asteroidList.Clear();
        difficulty = 1;
        uicontrol.GameOver();
    }
    public void AsteroidExtermination(GameObject asteroid)
    {
        uicontrol.AsteroidExtermination(asteroid);
        asteroidList.Remove(asteroid);
        if (asteroidList.Count <= difficulty)
        {
            difficulty++;
            GenerateAsteroid(difficulty * multiplier);
        }
    }
}
