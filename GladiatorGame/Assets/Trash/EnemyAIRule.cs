using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIRule : MonoBehaviour
{
    Strikes[] antecedent_ = new Strikes[2];  //  !<  前の行動データ
    Strikes consequent_;    //  !<  次の行動の予測

    bool isMatched_;        //  !<  ルールの一致フラグ
    int weight_;            //  !<  ルールのウェイト

    public Strikes[] Antecedent
    {
        get { return antecedent_; }
        set { antecedent_ = value; }
    }
    public Strikes Consequent
    {
        get { return consequent_; }
        set { consequent_ = value; }
    }
    public bool IsMatched
    {
        get { return isMatched_; }
        set { isMatched_ = value; }
    }
    public int Weight
    {
        get { return weight_; }
        set { weight_ = value; }
    }

    void Start()
    {
    }

    public void SetRule(Strikes argAntecedentA, Strikes argAntecedentB, Strikes argConsequent)
    {
        antecedent_[0] = argAntecedentA;
        antecedent_[1] = argAntecedentB;
        consequent_ = argConsequent;
    }
}
