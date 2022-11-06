using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchControl : MonoBehaviour
{
    public Animator anim;
    public GameObject playerMesh;
    float playerx;
    public float speed;
    public bool canMove = false;
    bool canMovex = true;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

    public void Button()
    {
        canMove = true;
        anim.SetBool("Run", true);
    }

    private void OnEnable()
    {       
        FingerGestures.OnFingerDragMove += OnFingerDragMove;
    }

    private void OnDisable()
    {
        FingerGestures.OnFingerDragMove -= OnFingerDragMove;
    }

    private void OnFingerDragMove(int fingerIndex, Vector2 fingerPos, Vector2 delta)
    {
        if (delta.x > 0f && canMovex)
        {
            canMovex = false;
            playerx = Mathf.Clamp(playerx + 1, -1, 1);
            playerMesh.transform.DOLocalMove(new Vector3(playerx, 0, 0), 0.5f).OnComplete(() => canMovex = true);
        }

        if (delta.x < 0f && canMovex)
        {
            canMovex = false;
            playerx = Mathf.Clamp(playerx - 1, -1, 1);
            playerMesh.transform.DOLocalMove(new Vector3(playerx, 0, 0), 0.5f).OnComplete(() => canMovex = true);

        }
    }

    void Update()
    {
        
        if (canMove == true)
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
    }
    Vector3 GetWorldPos(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        //we solve for intersection with y = 0 plane
        float t = -ray.origin.z / ray.direction.z;

        return ray.GetPoint(t);
    }


}
