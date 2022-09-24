using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class Selecting_Room : MonoBehaviour
{
    //Alternative code for between-subject design (currently not used)

    public int[] sceneArray = {0,1,2,3};
    public static int sceneInx = 0;

    private float timer = 0.0f;
    [SerializeField] GameObject questionnaire;


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

        if(timer > 180f) // task duration in each room
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
