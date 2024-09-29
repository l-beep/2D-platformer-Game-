using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershhot : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;

    public GameObject bullet;
    public Transform bulletHole;
    public float force = 200;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.shoot.performed += context => Fire();
    }

    void Fire()
    {
        animator.SetTrigger("shoot");
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
        if (GetComponent<PlayerMovements>().isFacingRight)
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        else
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
    }

}
