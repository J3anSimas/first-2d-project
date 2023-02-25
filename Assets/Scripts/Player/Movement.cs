using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public Rigidbody2D rb;
  public float speed;
  public Animator animator;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
  }
  void FixedUpdate()
  {
    var dir = Input.GetAxisRaw("Horizontal");

    rb.velocity = new Vector2(dir * speed, rb.velocity.y * Time.deltaTime);
  }
}
