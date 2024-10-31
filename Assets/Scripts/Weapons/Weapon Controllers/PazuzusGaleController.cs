using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PazuzusGaleController : WeaponController
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
        GameObject spawnedGale = Instantiate(weaponData.Prefab);
        spawnedGale.transform.position = transform.position;
        spawnedGale.transform.parent = transform;
    }
}
