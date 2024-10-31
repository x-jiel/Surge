using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeofBaalController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedEye = Instantiate(weaponData.Prefab);
        spawnedEye.transform.position = transform.position;
        spawnedEye.GetComponent<EyeofBaalBehaviour>().DirectionChecker(pm.lastMovedVector); // reference and sets direction
    }
}
