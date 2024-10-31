using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="WeaponScriptableObject", menuName="ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]// serialize and seperating public ensures that the scriptable objects wont change by accident without us
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    //base stats for weapons

    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField]
    float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField]
    float cooldownDur;
    public float CooldownDur { get => cooldownDur; private set => cooldownDur = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
