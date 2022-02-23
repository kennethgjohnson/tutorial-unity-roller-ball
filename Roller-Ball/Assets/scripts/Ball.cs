using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vio.rollerballnormal
{
  public class Ball : MonoBehaviour
  {
    [SerializeField]
    private float speed = 1;
    void FixedUpdate()
    {
      Rigidbody rb = GetComponent<Rigidbody>();
      Vector3 currentInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      rb.velocity += speed * currentInput * Time.fixedDeltaTime;
    }
  }
}