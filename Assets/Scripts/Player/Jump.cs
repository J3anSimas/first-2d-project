using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
  public Rigidbody2D rb;
  public float fallMultiplier = 2.5f;
  public float lowJumpMultiplier = 2f;
  public float jumpForce;
  public Vector2 bottomOffset;
  public float collisionRadius;
  public LayerMask groundLayer;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // if (rb.velocity.y < 0)
    // {
    //   rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    // }
    // else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
    // {
    //   rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    // }
    if (Input.GetButton("Jump") && onGround())
    {
      rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
      Debug.Log("Jump");

    }
    bool onGround()
    {
      return Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
      return true;
    }

    void OnDrawGizmos()
    {
      Gizmos.color = Color.red;

      Gizmos.DrawSphere(transform.position, collisionRadius);
    }
  }
}
