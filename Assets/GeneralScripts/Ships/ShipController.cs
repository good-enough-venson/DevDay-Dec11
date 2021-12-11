using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb;
    new public Rigidbody2D rigidbody {
        get { return rb == null ? rb = GetComponent<Rigidbody2D>() : rb; }
        set { rb = value; }
    }

    public float targetHorizontalPosition = 0;
    public float targetVerticalPosition = 50;

    //public float verticalForce = 10;
    //public float horizontalForce = 10;
    //public float slowdownForce = 0.1f;
    public float maxSpeed = 2;

    //public float cushion = 0;

    private void FixedUpdate() {
        rigidbody.MovePosition(Vector2.MoveTowards(rigidbody.position,
            new Vector2(targetHorizontalPosition, targetVerticalPosition), maxSpeed * Time.fixedDeltaTime));
    }

    //private void FixedUpdate() {
    //    if (rigidbody.velocity.magnitude < maxSpeed) {
    //        rigidbody.AddForce(GetTargetVelocity() * Time.fixedDeltaTime);
    //    } else if (rigidbody.velocity.magnitude > maxSpeed) {
    //        rigidbody.AddForce(-rigidbody.velocity * slowdownForce * Time.fixedDeltaTime);
    //    }
    //}

    //Vector2 GetTargetVelocity()
    //{
    //    bool moveUp = transform.position.y < targetVerticalPosition,
    //        moveDown = transform.position.y > targetVerticalPosition,
    //        moveRight = transform.position.x < targetHorizontalPosition,
    //        moveLeft = transform.position.x > targetHorizontalPosition;

    //    return new Vector2(moveRight ? horizontalForce * Mathf.Clamp01(Vector2.Distance()) : moveLeft ? -horizontalForce : 0f,
    //        moveUp ? verticalForce : moveDown ? -verticalForce : 0f);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(new Vector2(targetHorizontalPosition, targetVerticalPosition), 1);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(new Ray(new Vector2(targetHorizontalPosition, targetVerticalPosition), GetTargetVelocity() * 5));
    //}
}
