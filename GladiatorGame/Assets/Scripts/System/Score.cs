using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //経過時間
    [SerializeField]
    GameManager _time;

    //キルカウント
    [SerializeField]
    KillCount _killCount;

    //スコア(８桁)
    int _score;

    //動きをつけた表示用
    private int _displayScore;

    //スコアのテキスト
    [SerializeField]
    private Text _scoreText;

    //スコア加算のタイミングを知るため(死亡時)
    [SerializeField]
    private VirtualChatactor _chara;

    // Use this for initialization
    void Start () {
        _score = 0;
        _displayScore = _score;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_chara.IsLiving())//敵が死んだら
        {
            _killCount.AddKillCount();//キルカウント＋１
            GetScore();//スコアを入手
            //敵を再び生存状態にする処理
        }

        //スコアの表示
        if(_displayScore!=_score)
        {
            _displayScore = (int)Mathf.Lerp(_displayScore, _score, 0.1f);
        }

        _scoreText.text = string.Format("{0:00000000}", _displayScore);
	}

    public int GetScore()
    {
        /*Pattern 1 shorter*/
        //_score = (600 - (int)_time.GetTime()) * 10 + _killCount.GetKillNumber() * 100;//仮に10分より早いと＋

        /*Pattern 2 longer*/
        _score = (int)_time.GetTime() * 10 + _killCount.GetKillNumber() * 100;

        return _score;
    }
}
