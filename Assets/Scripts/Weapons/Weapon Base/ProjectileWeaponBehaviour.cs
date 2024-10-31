using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// base script of all proj based weapon behaviours [place on prefab of a weapon which is projectile]
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;

    public float destroyAfterSeconds;

    //current stats
    protected float currentDamage;//protected is used as it prevents the variable from being referenced outside of this script but allows override.
    protected float currentSpeed;
    protected float currentCooldownDur;
    protected int currentPierce;
    
    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDur = weaponData.CooldownDur;
        currentPierce = weaponData.Pierce;
    }

   protected virtual void Start() //allows only child classes under the parent to override and call functions
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

   
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0) //down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0) //up
        {
            scale.x = scale.x * -1;
        }
        else if (dirx > 0 && diry > 0) //right up
        {
            rotation.z = 0f;
        }
        else if (dirx > 0 && diry < 0) //right down
        {
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry > 0) //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry < 0) //left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); //cant convert quartenion into vector3
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
            {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); //using current dmg instead of weaponData.damage in case of any damage multipliers etc
        }
    }
}
