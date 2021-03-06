﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Timer : MonoBehaviour {
    public static event Action TriggerNewDay;

    public static int Days = 0;
    public static float secondsPerDay = 30;
    private static float currentCount = 0;

    private static Text daysText;
    private static Image sunImage;
	// Use this for initialization
	void Start () {
        daysText = GameObject.Find("Days Text").GetComponent<Text>();
        sunImage = GameObject.Find("Clock Sun").GetComponent<Image>();
        daysText.text = Days.ToString();
	}

    void OnGUI()
    {
        sunImage.fillAmount = (secondsPerDay - currentCount) / secondsPerDay;
    }
	
	// Update is called once per frame
	void Update () {
        currentCount += Time.deltaTime;
        if (currentCount > secondsPerDay)
        {
            Days += 1;
            daysText.text = Days.ToString();
            TriggerNewDay();
            currentCount -= secondsPerDay;
        }
	}
}
