using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  public Rigidbody2D _playerRigidBody;
  public float jumpForce;
  bool facingRight = true;
  public float fallMultiplier;
  public float speed;
  private bool onGround;
  public LayerMask _groundLayer;
  public float _groundRaycastLength;

  public GameObject axe;
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    CheckCollisions();
    if (Input.GetKey(KeyCode.Q))
    {
      ThrowAxe();
    }
  }
  void FixedUpdate()
  {
    var dir = Input.GetAxisRaw("Horizontal");
    _playerRigidBody.velocity = new Vector2(dir * speed, _playerRigidBody.velocity.y);
    if (Input.GetButton("Jump") && onGround)
    {
      _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, jumpForce);
    }
    if (_playerRigidBody.velocity.y < 0)
    {
      _playerRigidBody.velocity -= new Vector2(0, -Physics2D.gravity.y) * fallMultiplier * Time.deltaTime;
    }
  }

  private void CheckCollisions()
  {
    Vector3 checkGroundRaycastOrigin = new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z);
    onGround = Physics2D.Raycast(checkGroundRaycastOrigin, Vector2.down, _groundRaycastLength, _groundLayer);
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    // Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRaycastLength);
    Vector3 from = new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z);
    Vector3 to = from - new Vector3(0, _groundRaycastLength, 0);
    Gizmos.DrawLine(from, to);
  }

  private void ThrowAxe()
  {
    axe.GetComponent<AxeBehaviour>().BeThrown();

  }
}
