using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class nball : MonoBehaviour
{
    Text texto;
    private float updateInterval;
    private float nextUpdateTime;

    void Start()
    {
        texto = GetComponent<Text>();
        updateInterval = 0.25f;
        nextUpdateTime = 0f;
    }

    void Update()
    {
        if (Time.time >= nextUpdateTime)
        {
            nextUpdateTime = Time.time + updateInterval;
            texto.text = "N Balls: " + GameObject.FindGameObjectsWithTag("ball").Length.ToString();
        }
    }
}
