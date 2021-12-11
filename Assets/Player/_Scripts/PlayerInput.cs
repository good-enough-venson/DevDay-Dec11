using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls inputManager;
    private ShipController sc;
    public ShipController ship {
        get { return sc == null ? sc = GetComponent<ShipController>() : sc; }
        set { sc = value; }
    }

    public Transform gunEnd;
    public GenericGameObjectPool projectilePool;
    public float projectileSpeed;

    private void Awake()
    {
        inputManager = new PlayerControls();
        inputManager.Controls.MovementControl.performed +=
            (val) => { UpdateControls(val.ReadValue<Vector2>()); };
        inputManager.Controls.MovementControl.canceled +=
            (val) => { UpdateControls(val.ReadValue<Vector2>()); };
        inputManager.Controls.Fire.performed += (val) => { Fire(); };
    }

    private void OnEnable()
    {
        inputManager.Enable();
    }

    private void OnDisable()
    {
        inputManager.Disable();
    }

    bool up, down, left, right;

    void UpdateControls(Vector2 inputVal)
    {
        up = inputVal.y > 0;
        down = inputVal.y < 0;
        right = inputVal.x > 0;
        left = inputVal.x < 0;

        ship.targetVerticalPosition = up && !down ? 1000 :
            down && !up ? -1000 : ship.transform.position.y;

        ship.targetHorizontalPosition = right && !left ? 1000 :
            left && !right ? -1000 : ship.transform.position.x;

        Debug.Log(string.Format("Control({0}, {1})", ship.targetHorizontalPosition, ship.targetVerticalPosition));
    }

    void Fire()
    {
        var projectile = projectilePool.UnpoolItem<ProjectileScript>();
        projectile.transform.position = gunEnd.position;
        projectile.transform.rotation = gunEnd.rotation;
        projectile.velocity = new Vector3((gunEnd.position.x > transform.position.x ? 1 : -1) * projectileSpeed, 0);
    }
}
