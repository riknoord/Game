using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour {

    private Vector3 Destination = Vector3.zero;
    private float minDistance = 1.5f;

    private float moveSpeed = 0.025f;

    private Action Callback = null;

    public void MoveTo(Vector3 Destination, Action Callback)
    {
        this.Destination = Destination;
        this.Callback = Callback;
    }

    public void MoveTo(Vector3 Destination)
    {
        this.Destination = Destination;
    }

    void Update()
    {
        if (this.Destination == Vector3.zero) return;

        if(Vector3.Distance(transform.position, this.Destination) > minDistance)
        {
            Vector3 Dir = Destination - transform.position;
            transform.LookAt(this.Destination);
            transform.position += Dir.normalized * moveSpeed;
            return;
        }

        if(this.Callback != null)
            this.Callback();

        this.Callback = null;
        this.Destination = Vector3.zero;
    }
}
