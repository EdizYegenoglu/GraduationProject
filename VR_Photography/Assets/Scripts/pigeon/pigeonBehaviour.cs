using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pigeonBehaviour : MonoBehaviour
{
    private NavMeshAgent _agent;
    public bool walking;
    public bool flying;
    public bool eating;
    public GameObject Player;
    public GameObject Food;
    public float EnemyDistanceRun;
    public float feedingDistance;
    public float radius;
    public Animator anim;
    public int delay;
    public spawner spawner;
    
    void Start(){
        _agent = GetComponent<NavMeshAgent>();
        Food = GameObject.FindGameObjectWithTag("Food");
        walking = true;
    }

    private void Update(){
        Food = FindClosestFood();
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        float foodDistance = Vector3.Distance(transform.position, Food.transform.position);
        if(foodDistance < feedingDistance){
            Vector3 DirToFood = transform.position - Food.transform.position;
            Vector3 runFood = transform.position - DirToFood;
            _agent.SetDestination(runFood);
            _agent.acceleration = 3;
            eating = true;
        } else if(distance < EnemyDistanceRun){
            Vector3 DirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + DirToPlayer;
            _agent.SetDestination(newPos);
            _agent.acceleration = 6;
        } else if(!_agent.hasPath && walking){
            StartCoroutine(TimedDelay());
            walking = false;
        }
        Animations();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Food"){
            Destroy(Food);
            spawner.counter -= 1;
            eating = false;
        }
    }

    public GameObject FindClosestFood(){
        GameObject[] allFood;
        allFood = GameObject.FindGameObjectsWithTag("Food");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject food in allFood){
            Vector3 diff = food.transform.position - position;
            float currentDistance = diff.sqrMagnitude;
            if(currentDistance < distance){
                closest = food;
                distance = currentDistance;
            }
        }
        return closest;
    }

    IEnumerator TimedDelay(){
        delay = Random.Range(5, 20);
        yield return new WaitForSeconds(delay);
        _agent.SetDestination(walkArea.Instance.GetRandomPoint());
        _agent.acceleration = 1;
        walking = true;
    }

    public void Animations(){
        if(walking){
            anim.SetTrigger("walking");
        }else if(eating){
            anim.SetTrigger("eating");            
        }else if(flying){
            anim.SetTrigger("flying");            
        }else{
            anim.SetTrigger("idle");
        }
    }


    #if UNITY_EDITOR
        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    #endif
}
