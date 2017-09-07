using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected const string PrefabsPath = "Prefabs/Actions/";    //  !<  武器のプレハブのパス
    protected GameObject weaponPrefab_; //  !<  武器になるオブジェクトのプレハブ

    Transform GenerationPos;            //  !<  武器を出現させるトランスフォーム

    protected void Start ()
    {
        GenerationPos = transform.GetChild(0);
    }

    protected void Update ()
    {
	}

    public virtual void Attack(Charctor argCharcter)
    {
        argCharcter.RigitBody2D.velocity = new Vector2(0, 0);
        argCharcter.IsAttacking = true;

        GameObject weapon = Instantiate(weaponPrefab_, GenerationPos.position, GenerationPos.rotation) as GameObject;
        weapon.transform.parent = GenerationPos;

        if (transform.parent.transform.localScale.x < 0)
        {// 武器の画像の向きをキャラクターに合わせる
            weapon.transform.localScale = -weapon.transform.localScale;
        }
        const float WeaponDestroyTime = 1f;
        Destroy(weapon, WeaponDestroyTime);
    }

}