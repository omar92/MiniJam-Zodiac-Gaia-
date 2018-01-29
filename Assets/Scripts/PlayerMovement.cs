using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{

    public float moveForce = 2;
    public float maxSpeed = 5;
    public Transform Body;

    private Rigidbody _rigidbody;
    private Player player;
    private int PlayerNum;
    private Animator bodyAnimator;
    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        PlayerNum = player.playerNum;
        bodyAnimator = this.GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal" + PlayerNum) * moveForce, 0, -Input.GetAxis("Vertical" + PlayerNum) * moveForce));
        if (Mathf.Abs(_rigidbody.velocity.x) > maxSpeed)
        {
            _rigidbody.velocity = new Vector3(maxSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);
        }
        if (Mathf.Abs(_rigidbody.velocity.z) > maxSpeed)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, maxSpeed);
        }
    }


    Vector3 oldVelocity = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, new Vector3(Input.GetAxis("Horizontal" + PlayerNum), 0, -Input.GetAxis("Vertical" + PlayerNum)));

        oldVelocity.x = /*Mathf.Abs(_rigidbody.velocity.x) > 1 ? */_rigidbody.velocity.x /*: oldVelocity.x*/;
        oldVelocity.z = /*Mathf.Abs(_rigidbody.velocity.z) > 1 ? */_rigidbody.velocity.z /*: oldVelocity.z*/;
        Body.LookAt(new Vector3(oldVelocity.x * 100, Body.position.y, oldVelocity.z * 100));
        bodyAnimator.SetFloat("IsRunning", Mathf.Abs(Vector3.Magnitude(_rigidbody.velocity)));
        bodyAnimator.SetBool("isCarrying", player.Hand.childCount > 0);
    }
}
