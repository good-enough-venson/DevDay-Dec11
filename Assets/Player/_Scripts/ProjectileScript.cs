using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody2D rb;
    new public Rigidbody2D rigidbody
    {
        get { return rb == null ? rb = GetComponent<Rigidbody2D>() : rb; }
        set { rb = value; }
    }

    public Vector3 velocity;

    public void FixedUpdate()
    {
        rigidbody.velocity = velocity;
    }
}
