using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public int maxEnemiesOnBoard;
    public GameObject enemy;

    // Update is called once per frame
    void Update () {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemiesOnBoard)
        {
            // create an enemy
            Instantiate(enemy);
        }
	}
}
