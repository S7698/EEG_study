using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class WriteCSV : MonoBehaviour
{
    private string filename = "";
    private TextWriter csvFile;


    void Start()
    {
        filename = Application.dataPath + "/Data/" + Guid.NewGuid() + ".csv";
    }


    public void MakeCSV(string header, List<string> data)
    {
        csvFile = new StreamWriter(filename, false);
        csvFile.WriteLine(header);

        for (int i = 0; i < data.Count; i++)
        {
            csvFile.WriteLine(data[i]);
        }

        csvFile.Close();
    }

}
