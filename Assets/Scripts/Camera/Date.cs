using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Date : MonoBehaviour
{
    public Text textDate;
    public Text textHour;
    
    private string [] dateAndHour;
    
    private string date;
    private string hour;
    private string now;

    public 
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        now = System.DateTime.Now.ToString();
        

        dateAndHour = now.Split(' ');
        date = dateAndHour[0];
        hour = dateAndHour [1];

        textDate.text = date;
        textHour.text = hour;
    }
}
