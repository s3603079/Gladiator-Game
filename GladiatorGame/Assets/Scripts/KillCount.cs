using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour {

    [SerializeField]
    private int killNumber = 0;
    [SerializeField]
    private int maxKillCount = 100;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Text killText;

    // Use this for initialization
    void Start () {
        slider.maxValue = maxKillCount;
        slider.value = slider.maxValue;

        killNumber = maxKillCount;
    }

    // Update is called once per frame
    void Update () {
        killNumber = Mathf.Clamp(killNumber, 0, maxKillCount);

        slider.value = killNumber;
        killText.text = killNumber.ToString();
    }
}
