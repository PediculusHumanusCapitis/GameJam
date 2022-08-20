using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour, IHouse, IDamagable
{
    public int Level { get => level; set => level = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    [SerializeField] private int level;
    [SerializeField] private int maxHealth;

    public void ApplyDamage(int countDamage) {
        maxHealth -= countDamage;
    }
    public void Open() {
        
    }
}
