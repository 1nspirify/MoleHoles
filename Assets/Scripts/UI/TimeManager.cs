using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    private float _timer;
    public int Multiplier = 2;
    public GameObject BlackPanel;
    public TextMeshProUGUI Score;
    public PointsCollector PointsCollector;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 99f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime*Multiplier;
        Timer.text = "TIMER " + _timer.ToString("f0");
        if (_timer <= 0f)
        {
            BlackPanel.SetActive(true);
            Score.text = "SCORE: " + PointsCollector.Points.ToString();
            Time.timeScale = 0f;
            _timer = 99f;

        }
    }
   
}
