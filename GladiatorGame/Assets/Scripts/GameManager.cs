using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    private float timer;

    [SerializeField]
    private Text time;

    [SerializeField]
    private Gladiator player1;
    [SerializeField]
    private Gladiator player2;

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

        if (player1)
        {
            var pad = GamePad.Index.One;
            player1.Walk(GamePad.GetAxis(GamePad.Axis.LeftStick, pad).x);
            player1.Jump(GamePad.GetButtonDown(GamePad.Button.A, pad));
            player1.RotaShoulder(GamePad.GetAxis(GamePad.Axis.RightStick, pad));
            player1.Attack(GamePad.GetTrigger(GamePad.Trigger.RightTrigger, pad));
        }
    }
}
