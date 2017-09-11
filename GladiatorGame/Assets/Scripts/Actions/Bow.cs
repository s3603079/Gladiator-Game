using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    [SerializeField]
    private GameObject arrowPrefab;

    private bool isShot;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void Attack(float InputValue) {
        //// 持っている武器に応じてモーションが異なる
        //switch (haveWeapon)
        //{
        //    case WeaponType.Punch:
        //        arm.localPosition = (-transform.up * 0.2F) + (Vector3.MoveTowards(Vector3.zero, transform.up, InputValue) * 1F);
        //        break;
        //    case WeaponType.Sword:
        //        arm.localEulerAngles = (Vector3.MoveTowards(transform.forward * 0F, transform.forward * 90F, InputValue) * 120F);
        //        break;
        //    case WeaponType.Shield:
        //        arm.localPosition = (Vector3.MoveTowards(Vector3.zero, transform.up, InputValue) * 0.5F);
        //        break;
        //    case WeaponType.Bow:
        //        var arrow = arm.GetChild((int)haveWeapon).GetChild(0);
        //        arrow.localPosition = (Vector3.MoveTowards(Vector3.zero, -transform.right, InputValue) * 1.25F);
        //        break;
        //    default:
        //        break;
        //}

        var arm = transform.parent;
        arm.localPosition = (Vector3.MoveTowards(Vector3.zero, -transform.right, InputValue) * 1.25F);

        if(InputValue < 0F && isShot)
        {
            var arrow = Instantiate(arrowPrefab);

        }
        if (InputValue >= 1F) isShot = true;
    }
}
