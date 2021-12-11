using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimit : MonoBehaviour
{
    private Rigidbody2D rb;
    new public Rigidbody2D rigidbody {
        get { return rb == null ? rb = GetComponent<Rigidbody2D>() : rb; }
        set { rb = value; }
    }

    public float maxSpeed = 10;

    private void FixedUpdate() {
        rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
    }
}
