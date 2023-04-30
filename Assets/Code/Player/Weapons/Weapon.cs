using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy") && other.transform.TryGetComponent(out IDamagable idamagable)) {
            idamagable.ApplyDamage(damage);
        }
    }

}
