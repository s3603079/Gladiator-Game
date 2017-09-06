using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : Weapon
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void Attack(Charcter argCharcter)
    {
        base.Attack(argCharcter);
        argCharcter.LogNumTable.Add(0, Logger.Log("Attaking : Punch"));
    }
}
