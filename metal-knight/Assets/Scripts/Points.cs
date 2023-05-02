using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text pointText;
    public int currentPoints;

   
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "KILLS: " + currentPoints.ToString();
    }

    void Update()
    {
        ShowKills();
    }

    public void ShowKills()
    {
        pointText.text = "KILLS: " + currentPoints.ToString();
    }
    public void IncreasePoints(int point)
    {
        currentPoints += point;
        pointText.text = "KILLS: " + currentPoints.ToString();
    }

   
}
