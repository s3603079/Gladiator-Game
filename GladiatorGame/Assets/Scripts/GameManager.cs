using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    private float timer;

    [SerializeField]
    private Text time;

    protected override void Awake() {
        base.Awake();
    }

    // Use this for initialization
    void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        time.text = "Time:" + (Time.time - timer).ToString("f1");
	}
}
