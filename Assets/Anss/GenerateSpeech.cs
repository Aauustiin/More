using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateSpeech : MonoBehaviour
{

    [SerializeField] private String[] globalismNouns;
    [SerializeField] private String[] patriotismNouns;
    [SerializeField] private String[] ruralNouns;
    [SerializeField] private String[] urbanismNouns;
    [SerializeField] private String[] libertarianismNouns;
    [SerializeField] private String[] statismNouns;
    [SerializeField] private String[] traditionalismNouns;
    [SerializeField] private String[] innovationNouns;
    [SerializeField] private String[] equalityNouns;
    [SerializeField] private String[] marketsNouns;
    [SerializeField] private String[] positiveAdj;

    void Start()
    {
        CityStats stats = new CityStats();
        stats.Globalism = UnityEngine.Random.value;
        stats.Urbanism = UnityEngine.Random.value;
        stats.Statism = UnityEngine.Random.value;
        stats.Innovation = UnityEngine.Random.value;
        stats.Markets = UnityEngine.Random.value;
    }

    public String[] GenerateThoughts(CityStats stats, int population)
    {

        string[] result = new string[population];

        for (int i = 0; i <= population; i++)
        {

            if (stats.Globalism >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, globalismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(globalismNouns[index] + positiveAdj[index]);
                result[i] = globalismNouns[index] + positiveAdj[index];

            }

            else
            {

                int index = UnityEngine.Random.Range(0, patriotismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(patriotismNouns[index] + positiveAdj[index]);
                result[i] = patriotismNouns[index] + positiveAdj[index];
            }

            if (stats.Urbanism >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, urbanismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(urbanismNouns[index] + positiveAdj[index]);
                result[i] = urbanismNouns[index] + positiveAdj[index];
            }

            else
            {
                int index = UnityEngine.Random.Range(0, ruralNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(ruralNouns[index] + positiveAdj[index]);
                result[i] = ruralNouns[index] + positiveAdj[index];
            }

            if (stats.Statism >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, statismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(statismNouns[index] + positiveAdj[index]);
                result[i] = statismNouns[index] + positiveAdj[index];
            }

            else
            {
                int index = UnityEngine.Random.Range(0, libertarianismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(libertarianismNouns[index] + positiveAdj[index]);
                result[i] = libertarianismNouns[index] + positiveAdj[index];
            }

            if (stats.Innovation >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, innovationNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(innovationNouns[index] + positiveAdj[index]);
                result[i] = innovationNouns[index] + positiveAdj[index];
            }

            else
            {
                int index = UnityEngine.Random.Range(0, traditionalismNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(traditionalismNouns[index] + positiveAdj[index]);
                result[i] = traditionalismNouns[index] + positiveAdj[index];
            }

            if (stats.Markets >= 0.5)
            {
                int index = UnityEngine.Random.Range(0, marketsNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(marketsNouns[index] + positiveAdj[index]);
                result[i] = marketsNouns[index] + positiveAdj[index];
            }

            else
            {
                int index = UnityEngine.Random.Range(0, equalityNouns.Length);
                int index2 = UnityEngine.Random.Range(0, positiveAdj.Length);
                //Debug.Log(equalityNouns[index] + positiveAdj[index]);
                result[i] = equalityNouns[index] + positiveAdj[index];
            }

        }

        return result;
    }

} 
