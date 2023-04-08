using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    private NavMeshAgent agent;

    public bool pause = true;

    public int delay;

    public float radius;

    private void Start ()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    private void Update ()
    {

        if (!agent.hasPath && pause)
        {
            pause = false;
            StartCoroutine(TimedDelay());
        }
    }

    IEnumerator TimedDelay(){
        delay = Random.Range(10, 25);
        yield return new WaitForSeconds(delay);
        agent.SetDestination (GetPoint.Instance.GetRandomPoint (transform, radius));
        pause = true;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, radius);
    }

#endif
}
