using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable, IAttacking, IMoving
{

    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;

    public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    [SerializeField] private int maxSpeed;
    [SerializeField] private int maxHealth;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }
    private void Update() {
        Move();
    }
    public void ApplyDamage(int countDamage) {
        maxHealth -= countDamage; 

        if(CheckDeathed()) {
            Destroy(gameObject);
        }
    }
    private bool CheckDeathed() {
        return MaxHealth < 0 ? true : false;
    }
    public void Move() {
        if (Vector3.Distance(destination, target.position) > 1.0f) {
            destination = target.position;
            agent.SetDestination(destination);
        }
    }
    public void Attack() {

    }
    
}
