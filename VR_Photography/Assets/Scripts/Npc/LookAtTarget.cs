using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
  public Transform target;

    void Update()
  {
    //    if(target != null)
    //    {
    //         transform.LookAt(target);
    //    }

    // Vector3 targetPostition = new Vector3( target.position.x, this.transform.position.y, target.position.z);
    // this.transform.LookAt(targetPostition);
    this.transform.LookAt(2 * transform.position - target.position);
  }
}
