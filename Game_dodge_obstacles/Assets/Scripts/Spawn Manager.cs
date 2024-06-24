using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawn;
    private Vector3 spawnPosition = new Vector3(25,0,0);
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Spaw", 2, 2);
    }

    void Spaw()
    {
        if (PlayerController.instance.gameOver == false)
        {
            Instantiate(spawn, spawnPosition, spawn.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
