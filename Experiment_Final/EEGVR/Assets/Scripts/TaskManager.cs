using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class TaskManager : MonoBehaviour
{
    // Manage the scene sequence

    private int[] sceneArray = { 0, 1, 2, 3 }; // Scene indices from build setting
    private static int sceneInx = 0;
    private int scenePicked;


    private float timer = 0.0f;
    [SerializeField] private GameObject questionnaire;


    void Start()
    {
        // Random assignment of scene/experimental condition
        if (sceneInx == 0)
        {
            RandomPick();
        }
    }


    private void RandomPick()
    {
        scenePicked = sceneArray[Random.Range(0, sceneArray.Length - 1)];
    }


    public void GoToRoom()
    {
        SceneManager.LoadScene(sceneArray[scenePicked]);
        sceneInx++;
    }


    void Update()
    {
        // Set the task duration in the virtual room
        timer += Time.deltaTime;

        if (timer > 300f && sceneInx != (sceneArray.Length - 1) ) // currently 5 min
        {
            questionnaire.SetActive(true);
        }

    }


    public void CompleteScene()
    {
        SceneManager.LoadScene(sceneArray[(sceneArray.Length -1)]);
    }


    public void EndExperiment()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; // for testing in the editor
    }
}
