using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIcon : MonoBehaviour {

    [SerializeField]
    VirtualChatactor chara;//所持している武器を取得するため

    private List<int> actions;//できるアクション(全4種)を入れる。学習による行動の追加(エネミー)のためリストで持つ



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
