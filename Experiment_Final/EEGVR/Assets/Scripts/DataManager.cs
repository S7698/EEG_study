using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour
{
    public WriteCSV writeCSV;

    // Answers to the questionnaire; 0:"No", 1:"Yes" 
    private int[] pink_answer = { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1 };
    private int[] neutral_answer = { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1 };
    private int[] blue_answer = { 0, 1, 1, 1, 1, 1, 1, 1, 0, 1 };
    private int[] answers;

    private string header = "ConditionIndex, QuestionIndex, Response, Answer";
    private string currData;
    private List<string> data = new List<string>();

    private int sceneIndex=0; 
    private int currResponse;
    private int currAnswer;
    public int qIndex = 0;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        // scene index from build setting
        // 0: blue, 1:neutral, 2: pink
        if (sceneIndex == 0)
        {
            answers = blue_answer;
        }
        if (sceneIndex == 1)
        {
            answers = neutral_answer;
        }
        if (sceneIndex == 2)
        {
            answers = pink_answer;
        }
    }


    //OnClick() event when the participant answers "Yes"
    public void QYes()
    {
        currResponse = 1;
        currAnswer = answers[qIndex];
        currData = (sceneIndex.ToString() + "," + qIndex.ToString() + "," + currResponse.ToString() + "," + currAnswer.ToString());
        data.Add(currData);
        qIndex++;
    }


    //OnClick() event when the participant answers "No"
    public void QNo()
    {
        currResponse = 0;
        currAnswer = answers[qIndex];
        currData = (sceneIndex.ToString() + "," + qIndex.ToString() + "," + currResponse.ToString() + "," + currAnswer.ToString());
        data.Add(currData);
        qIndex++;
    }


    public void SaveCSV()
    {
        writeCSV.MakeCSV(header, data);
    }
}
