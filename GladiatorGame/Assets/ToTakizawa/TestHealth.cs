using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeatHealth : MonoBehaviour
{
    [SerializeField]
    Character character_;
    [SerializeField]
    Image healthGauge_; //  !<  体力を表示している

    //体力ゲージ
    int healthPoint_;
    //マックスの体力(スタート時のキャラクターの体力)
    int healthMax_;

    RectTransform rt_;

    //動きをつけた表示用
    private int displayHealthPoint_;
    
    float time_;    //  !<  デバッグ用

    void Start()
    {
        //--------------------------------------------
        //※ここを変更してプレイヤーのステータスをもらう
        //体力
        healthMax_ = character_.Life;
        //--------------------------------------------
        displayHealthPoint_ = healthMax_;//体力を最大値にする

        rt_ = healthGauge_.GetComponent<RectTransform>();

        time_ = 0f;
    }

    void Update()
    {
        //プレイヤーの上に表示する
        transform.position = Camera.main.WorldToScreenPoint(character_.gameObject.transform.position + new Vector3(0f, 1.6f, 0f));
        
        if (displayHealthPoint_ != character_.Life)
        {// 体力の減少に動きをつける
            displayHealthPoint_ = (int)Mathf.Lerp(displayHealthPoint_, character_.Life, 0.05f);
        }

        //体力の表示
        float wid = Mathf.Clamp((displayHealthPoint_ / (float)healthMax_) * 95.0f, 0f, 95f);
        rt_.sizeDelta = new Vector2(wid, 6.0f);

#if false
        //デバッグ用【仮想ダメージ】
        Debug.Log("仮想ダメージ");
        time_ += Time.deltaTime;
        if (time_ >= 3.0f)
        {
            chara_.Damage(1, 100);
            time_ = 0f;
        }
#endif
    }
}