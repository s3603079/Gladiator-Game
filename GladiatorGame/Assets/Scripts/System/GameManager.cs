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

<<<<<<< HEAD:GladiatorGame/Assets/Scripts/System/GameManager.cs
    public float GetTime()
    {
        return Time.time - timer;
=======
        if (player1)
        {
            var pad = GamePad.Index.One;
            player1.Walk(GamePad.GetAxis(GamePad.Axis.LeftStick, pad).x);
            player1.Jump(GamePad.GetButtonDown(GamePad.Button.A, pad));
            player1.RotaShoulder(GamePad.GetAxis(GamePad.Axis.RightStick, pad));
            player1.Attack(GamePad.GetTrigger(GamePad.Trigger.RightTrigger, pad));
        }
>>>>>>> feature/Player:GladiatorGame/Assets/Scripts/GameManager.cs
    }
}
