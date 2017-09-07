using UnityEngine;

public class Punch : Weapon
{
    void Start()
    {
        base.Start();
        weaponPrefab_ = Resources.Load(PrefabsPath + "Arm") as GameObject;
    }

    void Update ()
    {
	}

    public void Attack(Charctor argCharcter)
    {
        base.Attack(argCharcter);
    }
}
