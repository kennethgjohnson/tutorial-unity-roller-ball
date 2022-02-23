using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    public static Camera instance;
    public GameObject playerBall;
    public Vector3 offset;

    private void Awake()
    {
      if (instance != null && instance != this)
      {
        Destroy(this.gameObject);
        return;
      }
      instance = this;
    }

  private void LateUpdate()
  {
    if (playerBall == null) return;
    this.transform.position = playerBall.transform.position + offset;
  }
}
