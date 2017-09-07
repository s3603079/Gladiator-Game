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
            var pad1 = GamePad.GetState(GamePad.Index.One);
            player1.Walk(pad1.LeftStickAxis.x);
            player1.Jump(pad1.A);
        }

        if (player2)
        {
            var pad2 = GamePad.GetState(GamePad.Index.Two);
            player2.Walk(pad2.LeftStickAxis.x);
            player2.Jump(pad2.A);
        }
    }
}
