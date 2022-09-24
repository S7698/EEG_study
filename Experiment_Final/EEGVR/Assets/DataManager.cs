using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static int[] q1 = { 0, 1, 1, 0];
    public static int[] q2 = { 0, 0, 1];
    public static int[] q2 = { 0, 1, 0];

    private int currAnswer;


    public void Q1_1()
    {

    }

    private void SaveTrialResponse()
    {
        string currData = (nrTrials.ToString() + "," + colorShown + "," + wordWritten + "," + _rt.ToString() + "," + response);

        _data.Add(currData);

    }
}
