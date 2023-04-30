using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour, IHouse, IDamagable
{
    public GameObject canvasEnd;
    public Image healthbar;
    public int Level { get => level; set => level = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    [SerializeField] private int level;
    [SerializeField] private int maxHealth;
    private float timer;
    

    private Color startColor;
    private Color currentColor;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        timer = Time.time;
//        startColor = transform.GetComponent<SpriteRenderer>().color;
    }

    public void ApplyDamage(int countDamage) {
        MaxHealth -= countDamage;
        //healthbar.fillAmount = (MaxHealth / 100);
        if(maxHealth <= 0) {
            Destroy(gameObject);
            canvasEnd.SetActive(true);
        }
        //healthbar.fillAmount -= (countDamage / 100);
    }
    public void Open() {
        
    }
    void OnCollisionStay2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy") && Time.time - timer > 2) {
            healthbar.fillAmount -= 0.1f;
            ApplyDamage(10);
            timer = Time.time;
            //transform.GetComponent<SpriteRenderer>().color = Color.red;
             //Invoke("ResetColor", 0.5f);
        }
    }
    private void ResetColor() {
        //transform.GetComponent<SpriteRenderer>().color = startColor;
    }
}
