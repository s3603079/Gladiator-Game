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
        time.text = (Time.time - timer).ToString("000");

        SettingGladiator(player1, GamePad.Index.One);
        SettingGladiator(player2, GamePad.Index.Two);

        //if (player1 != null)
        //{
        //    var pad = GamePad.Index.One;
        //    player1.Walk(GamePad.GetAxis(GamePad.Axis.LeftStick, pad).x);
        //    player1.Jump(GamePad.GetButtonDown(GamePad.Button.A, pad));
        //    player1.RotaShoulder(GamePad.GetAxis(GamePad.Axis.RightStick, pad));
        //    player1.Attack(GamePad.GetTrigger(GamePad.Trigger.RightTrigger, pad));
        //}

        //if (player2 != null)
        //{
        //    var pad = GamePad.Index.Two;
        //    player2.Walk(GamePad.GetAxis(GamePad.Axis.LeftStick, pad).x);
        //    player2.Jump(GamePad.GetButtonDown(GamePad.Button.A, pad));
        //    player2.RotaShoulder(GamePad.GetAxis(GamePad.Axis.RightStick, pad));
        //    player2.Attack(GamePad.GetTrigger(GamePad.Trigger.RightTrigger, pad));
        //}
    }

    void SettingGladiator(Gladiator player, GamePad.Index index) {
        if (player == null) return;
        player.Walk(GamePad.GetAxis(GamePad.Axis.LeftStick, index).x);
        player.Jump(GamePad.GetButtonDown(GamePad.Button.A, index));
        player.RotaShoulder(GamePad.GetAxis(GamePad.Axis.RightStick, index));
        player.Attack(GamePad.GetTrigger(GamePad.Trigger.RightTrigger, index));
    }

    public float GetTime()
    {
        return Time.time - timer;
    }
}
