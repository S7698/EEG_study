using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selecting_Room : MonoBehaviour
{
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
}
