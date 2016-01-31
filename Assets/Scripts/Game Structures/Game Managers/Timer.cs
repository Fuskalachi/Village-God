using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    public static int Days = 0;
    public static float secondsPerDay = 30;
    private static float currentCount = 0;

    private static Text daysText;
    private static Image timePanel;
	// Use this for initialization
	void Start () {
        daysText = GameObject.Find("Days Text").GetComponent<Text>();
        timePanel = GameObject.Find("Time Panel").GetComponent<Image>();
        daysText.text = Days.ToString();
	}

    void OnGUI()
    {
        Debug.Log((secondsPerDay - currentCount) / secondsPerDay);
        timePanel.fillAmount = (secondsPerDay - currentCount) / secondsPerDay;
    }
	
	// Update is called once per frame
	void Update () {
        currentCount += Time.deltaTime;
        if (currentCount > secondsPerDay)
        {
            Days += 1;
            daysText.text = Days.ToString();
            currentCount -= secondsPerDay;
        }
	}
}
