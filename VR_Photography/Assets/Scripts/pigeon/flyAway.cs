using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class flyAway : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject pigeon;
    public GameObject Player;
    public float fly;
    public float EnemyDistanceRun;
    public Animator anim;
    public bool flying;
        public AnimationCurve m_Curve = new AnimationCurve();

    private void Start(){
        flying = false;
        _agent = GetComponent<NavMeshAgent>();

    }
    private void Update(){
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance < EnemyDistanceRun){
            flying = true;
        }
        if(flying){
            Vector3 movement = new Vector3(0, 1f, .3f);
            anim.SetTrigger("flying");            
            pigeon.transform.Translate(movement * fly * Time.deltaTime);
        }
    }
}
