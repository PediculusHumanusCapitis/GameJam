using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable, IAttacking, IMoving
{

    public GameObject target;
    Vector3 destination;
    NavMeshAgent agent;
    
    public int damage = 5;
    public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    [SerializeField] private int maxSpeed;
    [SerializeField] private int maxHealth;
    private Color startColor;
    private Color currentColor;
    //public int damage = 5;


    private void Start() {
        target = GameObject.FindWithTag("House");
        agent = GetComponent<NavMeshAgent>();
        startColor = GetComponent<SpriteRenderer>().color;
        currentColor = transform.GetComponent<SpriteRenderer>().color;
        destination = agent.destination;
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }
    private void Update() {
        Move();
        Attack();
    }
    public void ApplyDamage(int countDamage) {
        maxHealth -= countDamage; 
        agent.speed = 0.75f;
        transform.GetComponent<SpriteRenderer>().color = Color.red;
        if(CheckDeathed()) {
            Destroy(gameObject);
        }
        Invoke("ResetColor", 0.5f);
        Invoke("ResetSpeed", 0.5f);
    }
    private bool CheckDeathed() {
        return MaxHealth < 0 ? true : false;
    }
    public void Move() {
        if (Vector3.Distance(destination, target.transform.position) > 1.0f) {
            destination = target.transform.position;
            agent.destination = destination;
        }
    }
    public void Attack() {
        //Debug.Log(Vector.Distance(destination, target.position));
        if (Vector3.Distance(destination, target.transform.position) > 1f && target.transform.TryGetComponent(out IDamagable idamagable)) {
            idamagable.ApplyDamage(damage);
        }
        else return;
    }
    private void ResetColor() {
        transform.GetComponent<SpriteRenderer>().color = startColor;
    }
    private void ResetSpeed() {
        agent.speed = 1.5f;
    }
}
