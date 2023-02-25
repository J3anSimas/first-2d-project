using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  public Collider2D _playerCollider;
  public float jumpForce;
  bool facingRight = true;
  public float fallMultiplier = 2.5f;
  public float lowJumpMultiplier = 2f;
  private bool onGround;
  public LayerMask _groundLayer;
  public float _groundRaycastLength;

  public Rigidbody2D rb;
  public float dir = 0;
  public GameObject axe;
  // Start is called before the first frame update
  void Start()
  {
    Debug.Log(_playerCollider.bounds.extents);
    Debug.Log(transform.position);

  }

  // Update is called once per frame
  void Update()
  {
    CheckCollisions();
    if (Input.GetKey(KeyCode.Q))
    {
      ThrowAxe();
    }
    if (Input.GetButton("Jump") && onGround)
    {
      Jump();
    }
    if (dir == -1)
    {
      GetComponent<SpriteRenderer>().flipX = false;
    }
    else if (dir == 1)
    {
      GetComponent<SpriteRenderer>().flipX = true;

    }
  }
  void FixedUpdate()
  {
    // if (_playerRigidBody.velocity.y < 0)
    // {
    //   _playerRigidBody.velocity -= new Vector2(0, -Physics2D.gravity.y) * fallMultiplier * Time.deltaTime;
    // }
  }

  private void CheckCollisions()
  {
    Vector3 checkGroundRaycastOrigin = new Vector3(transform.position.x, transform.position.y - _playerCollider.bounds.extents.y, 0);
    onGround = Physics2D.Raycast(checkGroundRaycastOrigin, Vector2.down, _groundRaycastLength, _groundLayer);
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    // Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRaycastLength);
    Vector3 from = new Vector3(transform.position.x, transform.position.y - _playerCollider.bounds.extents.y, 0);
    Vector3 to = from - new Vector3(0, _groundRaycastLength, 0);
    Gizmos.DrawLine(from, to);
  }

  private void ThrowAxe()
  {
    axe.GetComponent<AxeBehaviour>().BeThrown();

  }
  private void Jump()
  {
    if (rb.velocity.y < 0)
    {
      rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
    else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
    {
      rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

  }
}
