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

    //デバッグ用
    private float _time;

    // Use this for initialization
    void Start () {
        slider.maxValue = maxKillCount;
        slider.value = slider.maxValue;

        //killNumber = maxKillCount;
        _time = 0;
    }

    // Update is called once per frame
    void Update () {

        killNumber = Mathf.Clamp(killNumber, 0, maxKillCount);
        //指定した番号ごとにゲージをリセット
        slider.value = killNumber%10;
        //アイコン上に討伐数を表示
        killText.text = killNumber.ToString();
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
