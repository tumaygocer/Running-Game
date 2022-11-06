using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Vector3 distance;

    public Transform target;
   
    private void Start()
    {
        distance = transform.position - target.transform.position;
    }
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime);
    }

    

}
