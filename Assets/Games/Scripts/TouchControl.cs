using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchControl : MonoBehaviour
{
    public Animator anim;
    private Camera _camera;
    void Start()
    {
        anim = GetComponent<Animator>();
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        FingerGestures.OnFingerMoveBegin += OnFingerMoveBegin;
        FingerGestures.OnFingerMove += OnFingerMove;
        FingerGestures.OnFingerMoveEnd += OnFingerMoveEnd;
        FingerGestures.OnDragMove += OnFingerDrag;
    }

    private void OnFingerDrag(Vector2 fingerPos, Vector2 delta)
    {
       
    }

    private void OnDisable()
    {
        FingerGestures.OnFingerMoveBegin -= OnFingerMoveBegin;
        FingerGestures.OnFingerMove -= OnFingerMove;
        FingerGestures.OnFingerMoveEnd -= OnFingerMoveEnd;
    }

    private void OnFingerMoveBegin(int fingerIndex, Vector2 fingerPos)
    {

    }

    private void OnFingerMove(int fingerIndex, Vector2 fingerPos)
    {
        if (fingerPos.x > 20f)
        {
            transform.DOMoveX(1, 1f);
        }

        if (fingerPos.x < -20f)
        {
            transform.DOMoveX(-1, 1f);
        }
    }

    private void OnFingerMoveEnd(int fingerIndex, Vector2 fingerPos)
    {
       
    }

    void Update()
    {
        
    }

    
}
