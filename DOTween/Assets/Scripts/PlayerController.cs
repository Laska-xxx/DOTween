using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] float jumpDistance = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float jumpSpeed = 1;
    [SerializeField] KeyCode jumpKey;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Rotation();
        Jump();
    }
    void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.DORotate(new Vector3(0, transform.eulerAngles.y -90, 0), rotationSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.DORotate(new Vector3(0, transform.eulerAngles.y + 90, 0), rotationSpeed);
        }
        
    }
    void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            isGrounded = false;
            Vector3 endPosition = transform.position + transform.forward * jumpDistance;
            transform.DOJump(endPosition, jumpForce, 1, jumpSpeed).SetEase(Ease.OutBounce);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
