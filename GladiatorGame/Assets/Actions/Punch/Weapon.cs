using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject weaponPrefab_; //  !<  武器になるオブジェクトのプレハブ

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    protected virtual void Attack(Charcter argCharcter)
    {
        argCharcter.IsAttacking = true;
        GameObject weapon = Instantiate(weaponPrefab_, transform.position, Quaternion.identity) as GameObject;
        float adjustPosition = weapon.transform.localScale.x * 2;
        if (transform.localScale.x < 0)
        {
            adjustPosition = -adjustPosition;
            weapon.transform.localScale = -weapon.transform.localScale;
        }
        weapon.transform.parent = this.transform;
        weapon.transform.position = new Vector3(transform.position.x - adjustPosition, transform.position.y, transform.position.z);

        const float FistDestroyTime = 1f;
        Destroy(weapon, FistDestroyTime);
    }

}