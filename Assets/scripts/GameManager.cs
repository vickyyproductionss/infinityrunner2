using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject roadParent;
    public GameObject endGamePanel;
    public static GameManager instance;
    public GameObject player;
    Vector3 nextSpawnPos= new Vector3();
    int roadsSpawnedCount;
    public int skippedTiles;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        spawnInitialRoad();
    }
    void Update()
    {

    }
    public void setNextPos(Vector3 pos)
    {
        nextSpawnPos = pos;
    }
    public void GameOver()
    {
        endGamePanel.SetActive(true);
    }
    void spawnInitialRoad()
    {
        for (int i =0; i < 10; i++)
        {
            GameObject road = Instantiate(roadPrefab, nextSpawnPos, Quaternion.identity);
            road.transform.parent = roadParent.transform;
            setNextPos(road.transform.GetChild(5).transform.position);
            roadsSpawnedCount++;
            if(roadsSpawnedCount%2==0)
            {
                int indexToleave = Random.Range(2, 5);
                for(int j =2; j < 5; j++)
                {
                    if(j!=indexToleave)
                    {
                        int indexToActiveObstacle = Random.Range(0, 3);
                        road.transform.GetChild(j).GetChild(indexToActiveObstacle).gameObject.SetActive(true);
                    }
                }
            }
        }
        
    }
    public void spawnATile()
    {
        GameObject road = Instantiate(roadPrefab, nextSpawnPos, Quaternion.identity);
        road.transform.parent = roadParent.transform;
        setNextPos(road.transform.GetChild(5).transform.position);
        roadsSpawnedCount++;
        if (roadsSpawnedCount % 2 == 0)
        {
            int indexToleave = Random.Range(2, 5);
            for (int j = 2; j < 5; j++)
            {
                if (j != indexToleave)
                {
                    int indexToActiveObstacle = Random.Range(0, 3);
                    road.transform.GetChild(j).GetChild(indexToActiveObstacle).gameObject.SetActive(true);
                }
            }
        }
    }
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
