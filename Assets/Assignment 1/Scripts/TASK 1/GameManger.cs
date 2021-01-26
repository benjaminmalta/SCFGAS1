using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public GameObject robotAI;
    public GameObject obstacleObject;
    
    List<Vector3> positionRecord = new List<Vector3> { };

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Task1")
        {
            Task1();
        }
    }

    private void Task1() 
    {
        //The order of executution of these methods is intentional to 
        //Ensure that first the obstacles are generated then scanned 
        ObstacleGenerator(5);
        Scan();
        StartExample();

    }

    private void ObstacleGenerator(int obstacles) 
    {
        for (int i = 0; i < obstacles; i++)
        {
            AddObstacle();
        }
    }










    public void Scan() {
        GameObject.Find("AStarGrid").GetComponent<AstarPath>().Scan();
    }

    public void AddObstacle()
    {
        Vector3 randomPos = new Vector3(Random.Range(-49, 49), Random.Range(-49, 49), 0);
        Instantiate(obstacleObject, randomPos, Quaternion.identity);
        positionRecord.Add(randomPos);
        print("Adding Obstacle");

    }

    public void AddAI() 
    {
        print("Not Adding AI");
        Vector3 randomPos = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
        if (!positionRecord.Contains(randomPos))
        {
           Instantiate(robotAI, randomPos, Quaternion.identity);            
            print("Adding AI");
        }

    }

    public void StartExample()
    {
        GameObject[] allRobots = GameObject.FindGameObjectsWithTag("Robot");

        foreach (GameObject robots in allRobots) 
        {
            robots.GetComponentInChildren<customAIMoveScriptGrid>().enabled = true;
        }
    }


}
