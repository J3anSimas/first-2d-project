using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  public Rigidbody2D _playerRigidBody;
  public float jumpForce;
  public float speed;
  private bool onGround;
  public LayerMask _groundLayer;
  public float _groundRaycastLength;
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    var dir = Input.GetAxisRaw("Horizontal");
    _playerRigidBody.velocity = new Vector2(dir * speed, _playerRigidBody.velocity.y);
    if (dir == 1)
    {
      transform.localScale = new Vector3(1, 1, 1);
    }
    else if (dir == -1)
    {
      transform.localScale = new Vector3(-1, 1, 1);
    }
    CheckCollisions();
    if (Input.GetButton("Jump") && onGround)
    {
      _playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      Debug.Log("Pressed");
    }
  }

  private void CheckCollisions()
  {
    onGround = Physics2D.Raycast(transform.position * _groundRaycastLength, Vector2.down, _groundRaycastLength, _groundLayer);
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRaycastLength);
  }
}
