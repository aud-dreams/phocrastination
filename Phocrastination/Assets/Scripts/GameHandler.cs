using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // declare all vars as public (static, dependent on environment, datastream)
    public bool gameInProgress;
    public double timer;

    // Start is called before the first frame update
    void Start()
    {
        gameInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (gameInProgress == true) {


            //endGame condition
        }
        
    }

    void dayConfig() {
        // reset state vars

        // switch between days
    }


    // log at start of day, end of day, enter & end scene, interacting w objects
}
