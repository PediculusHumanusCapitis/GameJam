using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] int maxHealth;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public void ApplyDamage(int countDamage) {
        maxHealth -= countDamage; 

        if(CheckDeathed()) {
            //you dead
        }
    }
    private bool CheckDeathed() {
        return MaxHealth < 0 ? true : false;
    }
}
