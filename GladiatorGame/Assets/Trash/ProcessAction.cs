using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessAction : SingletonMonoBehaviour<ProcessAction>
{
    const int RuleMax = 1;
    EnemyAIRule[] rules_ = new EnemyAIRule[RuleMax];  //  !<  敵AIのルール
    Strikes prediction_;                    //  !<  前回のプレイヤーの行動
    Strikes randomPrediction_;              //  !<  比較用のランダムな行動予想
    int successCnt_ = 0;                    //  !<  ルールの的中率
    int randomSuccessCnt_ = 0;              //  !<  ランダムルールの的中率
    int previousRuleFired_ = -1;            //  !<  エラーチェック用に -1 で初期化
    int ruleToFire_ = -1;                   //  !<  エラーチェック用に -1 で初期化

    override protected void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        rules_[0] = CharacterManager.Instance.Enemy.GetComponent<EnemyAIRule>();        
        rules_[0].SetRule(Strikes.Punch, Strikes.Punch, Strikes.Punch);
    }

    public Strikes UpdateProcess(WorkingMemory argWorkingMemory, Strikes argPlayerLastAction)
    {
        //  ワーキングメモリの設定
        if (argWorkingMemory.Antecedent[0] == Strikes.Unknown)
        {
            argWorkingMemory.Antecedent[0] = argPlayerLastAction;
            return Strikes.Unknown;
        }
        if (argWorkingMemory.Antecedent[1] == Strikes.Unknown)
        {
            argWorkingMemory.Antecedent[1] = argPlayerLastAction;
            return Strikes.Unknown;
        }

        //  前回の予想を処理
        //  ウェイトを計算して調整する
        if (argPlayerLastAction == prediction_)
        {
            successCnt_++;
            if (previousRuleFired_ != -1)
            {
                rules_[previousRuleFired_].Weight++;
            }
        }
        else
        {
            if (previousRuleFired_ != -1)
            {
                rules_[previousRuleFired_].Weight--;
            }

            //  呼び出すべきであったルールを後ろ向き推論して、
            //  そのルールのウェイトを増やす
            foreach (var rule in rules_)
            {
                if (rule.IsMatched && rule.Consequent == argPlayerLastAction)
                {
                    rule.Weight++;
                    break;
                }
            }
        }


        if (randomPrediction_ == argPlayerLastAction)
        {
            randomSuccessCnt_++;
        }


        //  ロールバック
        argWorkingMemory.Antecedent[0] = argWorkingMemory.Antecedent[1];
        argWorkingMemory.Antecedent[1] = argPlayerLastAction;

        //  新しい予想を立てる
        foreach (var rule in rules_)
        {
            if (rule.Antecedent[0] == argWorkingMemory.Antecedent[0] &&
                rule.Antecedent[1] == argWorkingMemory.Antecedent[1])
            {
                rule.IsMatched = true;
            }
            else
            {
                rule.IsMatched = false;
            }
        }

        //  一致したルールのうち最もウェイトの重いものを選ぶ
        ruleToFire_ = -1;

        for (int lRuleIndex = 0; lRuleIndex < RuleMax; lRuleIndex++)
        {
            if (rules_[lRuleIndex].IsMatched)
            {
                if (ruleToFire_ == -1)
                {
                    ruleToFire_ = lRuleIndex;
                }
                else if (rules_[lRuleIndex].Weight > rules_[ruleToFire_].Weight)
                {
                    ruleToFire_ = lRuleIndex;
                }
            }
        }

        //  ルールの呼び出し
        if (ruleToFire_ != -1)
        {
            argWorkingMemory.Consequent = rules_[ruleToFire_].Consequent;
            previousRuleFired_ = ruleToFire_;
        }
        else
        {
            argWorkingMemory.Consequent = Strikes.Unknown;
            previousRuleFired_ = -1;
        }


        return argWorkingMemory.Consequent;
    }
}