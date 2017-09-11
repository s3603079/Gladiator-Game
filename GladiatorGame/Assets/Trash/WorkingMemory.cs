using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Strikes
{
    Punch,
    Unknown,
}

public class WorkingMemory : MonoBehaviour
{
    Strikes[] antecedent_;  //  !<  前の行動データ
    Strikes consequent_;    //  !<  次の行動の予測

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

    void Start ()
    {
        antecedent_ = new Strikes[2];
    }

}