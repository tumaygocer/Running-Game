using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    void Update()
    {
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.deltaPosition.x >= 30f)
            {
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
            }

            if (finger.deltaPosition.x <= -30f)
            {
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
            }

            if (finger.deltaPosition.y >=30f)
            {
                anim.SetTrigger("Jump");
            }
        }
    }
}
