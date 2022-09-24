using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class Selecting_Room : MonoBehaviour
{
    public int[] sceneArray = {0,1,2,3};
    public static int sceneInx = 0;

    private float timer = 0.0f;
    [SerializeField] GameObject questionnaire;

    /*
    // SWITCH TO ROOMS 
    private void Update()
    {

        if (Input.GetKeyDown("a"))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown("b"))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown("c"))
        {
            SceneManager.LoadScene(3);
        }
    }
    */

    void Start()
    {
        if (sceneInx == 0)
        {
            Shuffle();

        }
        

    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10f) //
        {
            questionnaire.SetActive(true);
        }

    }

    private void Shuffle()
    {
        for (int i = 0; i < sceneArray.Length; i++)
        {
            int rnd = Random.Range(i, sceneArray.Length);
            int tempGO = sceneArray[rnd];
            sceneArray[rnd] = sceneArray[i];
            sceneArray[i] = tempGO;
        }

    }


    public void NextCondition()
    {
        if (sceneInx < sceneArray.Length)
        {
            SceneManager.LoadScene(sceneArray[sceneInx]);

            sceneInx++;
        }

        if (sceneInx == 3)
        {
            SceneManager.LoadScene(sceneArray[sceneInx]);
        }

    }

}
