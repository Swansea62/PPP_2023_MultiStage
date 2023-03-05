using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI stopwatchText;

    [Header("Stopwatch Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Format Settings")]
    public bool hasFormat;
    public StopwatchFormats format;
    private Dictionary<StopwatchFormats, string> stopwatchFormats = new Dictionary<StopwatchFormats, string>();

    void Start()
    {
        stopwatchFormats.Add(StopwatchFormats.Whole, "0");
        stopwatchFormats.Add(StopwatchFormats.TenthDecimal, "0.0");
        stopwatchFormats.Add(StopwatchFormats.HundrethDecimal, "0.00");
    }

    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        SetStopwatchText();
    }

    private void SetStopwatchText()
    {
        stopwatchText.text = hasFormat ? currentTime.ToString(stopwatchFormats[format]) : currentTime.ToString();
    }
}

public enum StopwatchFormats
{
    Whole,
    TenthDecimal,
    HundrethDecimal,
}