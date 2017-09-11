using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour {

    [SerializeField]
    [Tooltip("一番始めは0を入れてください")]
    private int[] _waveNumber;

    private int _now;

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
        _now = 1;
        maxKillCount = _waveNumber[_now];
        slider.maxValue = maxKillCount;
        slider.value = 0;

        //slider.value = slider.maxValue;
        //killNumber = maxKillCount;
    }

    // Update is called once per frame
    void Update () {

        killNumber = Mathf.Clamp(killNumber, 0, maxKillCount);
        
        //指定した番号ごとにゲージをリセット
        slider.value = (killNumber-_waveNumber[_now-1])%_waveNumber[_now];

        //アイコン上に討伐数を表示
        killText.text = killNumber.ToString();

        if(killNumber>=_waveNumber[_now])
        {
            _now++;
            maxKillCount = _waveNumber[_now];
            slider.maxValue = maxKillCount - _waveNumber[_now - 1];
            slider.value = 0;
        }
    }

    public void AddKillCount()
    {
        killNumber++;
    }

    public int GetKillNumber()
    {
        return killNumber;
    }
}
