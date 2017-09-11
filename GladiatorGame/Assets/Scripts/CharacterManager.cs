using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : SingletonMonoBehaviour<CharacterManager>
{
    List<TestPlayer> playerList_ = new List<TestPlayer>();
    BaseEnemy enemy_;

    public BaseEnemy Enemy
    {
        get { return enemy_; }
        set { enemy_ = value; }
    }
    public List<TestPlayer> PlayerList
    {
        get { return playerList_; }
    }

    override protected void Awake()
    {
        base.Awake();
        //if(SceneManager.GetActiveScene().name == "Play")
        //{//   プレイシーンに入ったらオブジェクト格納
        //}
        //  HACK    :   デバックシーンの為、仮の処理

    }

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var player in players)
        {
            playerList_.Add(player.GetComponent<TestPlayer>());
        }
        enemy_ = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BaseEnemy>();
    }
	
	void Update ()
    {
	}
}
