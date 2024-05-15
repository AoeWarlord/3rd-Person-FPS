using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController2 : MonoBehaviour
{
    //Private variable to be assigned in the inspector
    //with what enemy prefab to spawn
    [SerializeField] GameObject enemyPrefab;

    //Private variable containing a reference
    //to the enemy instance in the scene
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        /*Private variable containing a reference to the
         * enemy instance in the scene
         * private GameObject[] enemy;
         * private int activeEnemies = 0;
         * Chapter 3 Part 2 end
         */
    }

    // Update is called once per frame
    void Update()
    {
        //If there isn't an enemy, spawn one
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(-11, 5.0f / 3, 3); //See if we can change y to 1.66 to make enemy "fly"
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
