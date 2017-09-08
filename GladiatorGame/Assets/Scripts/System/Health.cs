using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField]
    VirtualChatactor _chara;

    //体力ゲージ
    private int _healthPoint;
    //マックスの体力(スタート時のキャラクターの体力)
    private int _healthMax;

    [SerializeField]
    GameObject _model;

    //体力を表示している
    [SerializeField]
    private Image _healthGauge;
    //private Text _healthText;

    //動きをつけた表示用
    private int _displayHealthPoint;

    //デバッグ用
    private bool _hit;
    float _time;
    
    //ダメージ
    private int _damage;

	// Use this for initialization
	void Start() {
        //--------------------------------------------
        //※ここを変更してプレイヤーのステータスをもらう
        //体力
        _healthMax = _chara.Life();
        //攻撃量
        _damage = _chara.Power();
        //--------------------------------------------
        _healthPoint = _healthMax;//体力を最大値にする
        _displayHealthPoint = _healthPoint;

        //デバッグ用
        _hit = false;//デバッグ用のヒットフラグをFalseにする
        _time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        //プレイヤーの上に表示する
        this.transform.position = Camera.main.WorldToScreenPoint(_model.transform.position + new Vector3(0f, 1.0f, 0f));

        //【統合用】プレイヤーのライフを常に受け取る
        _healthPoint = _chara.Life();

        //体力の減少に動きをつける
        if(_displayHealthPoint!=_healthPoint)
        {
            _displayHealthPoint = (int)Mathf.Lerp(_displayHealthPoint, _healthPoint, 0.05f);
        }

        //体力の表示
        //_healthText.text = string.Format("{0:0000} / {1:0000}", _displayHealthPoint, _healthMax);
        _healthGauge.transform.localScale = new Vector3((float)_displayHealthPoint / _healthMax,1.0f,1.0f);

        //デバッグ用【仮想ダメージ】
        _time += Time.deltaTime;
        if (_time >= 3.0f)
        {
            _chara.Damage();
            _time = 0f;
        }
	}
}