using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Matrix4x4 originalProjection;
  public CharacterController characterController;
  public Camera camera;
  public float speed = 6;
  public float mouseSpeed = 150.0f;
  float scroll = 1;


  public float left = -0.2F;
  public float right = 0.2F;
  public float top = 0.2F;
  public float bottom = -0.2F;


  private float yaw = 0.0f;
  private float pitch = 0.0f;



  // Start is called before the first frame update
  void Start()
  {
    originalProjection = camera.projectionMatrix;
  }

  void LateUpdate() {
    // Matrix4x4 m = perspectiveOffCenter(left, right, bottom, top, camera.nearClipPlane, camera.farClipPlane);
    // camera.projectionMatrix = m;
  }
  
  static Matrix4x4 perspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
  {
    float x = 2.0F * near / (right - left);
    float y = 2.0F * near / (top - bottom);
    float a = (right + left) / (right - left);
    float b = (top + bottom) / (top - bottom);
    float c = -(far + near) / (far - near);
    float d = -(2.0F * far * near) / (far - near);
    float e = -1.0F;
    Matrix4x4 m = new();
    m[0, 0] = x;
    m[0, 1] = 0;
    m[0, 2] = a;
    m[0, 3] = 0;
    m[1, 0] = 0;
    m[1, 1] = y;
    m[1, 2] = b;
    m[1, 3] = 0;
    m[2, 0] = 0;
    m[2, 1] = 0;
    m[2, 2] = c;
    m[2, 3] = d;
    m[3, 0] = 0;
    m[3, 1] = 0;
    m[3, 2] = e;
    m[3, 3] = 0;
    return m;
  }

  // Update is called once per frame
  void Update()
  {
    // Matrix4x4 p = originalProjection;
    // p.m01 += Mathf.Sin(Time.time * 1.2F) * 0.1F;
    // p.m10 += Mathf.Sin(Time.time * 1.5F) * 0.1F;
    // camera.projectionMatrix = p;

    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");
    // var scrollChange = Input.GetAxis("Mouse ScrollWheel");
    var mouseX = Input.GetAxis("Mouse X");
    var mouseY = Input.GetAxis("Mouse Y");
    // scroll += scrollChange;
    
    // Debug.Log("mouseX: " + mouseX);
    // Debug.Log("mouseY: " + mouseY);

    // camera.nearClipPlane = scroll;
    // camera.farClipPlane = scroll + 5;
    // // if(scrollChange != 0) {
    // //   Debug.Log("scroll: " + scroll);
    // //   Debug.Log("scrollChange: " + scrollChange);
    // //   // Debug.Log("camera.barrelClipping: " + camera.barrelClipping);
    // //   // Debug.Log("camera.lensShift: " + camera.lensShift);
    // //   // camera.barrelClipping += scrollChange;
    // //   // camera.lensShift = new Vector2(camera.lensShift.x, scroll);
    // //   // camera.
    // // }

    var forward = this.camera.transform.forward.normalized;
    forward.y = 0;
    Vector3 move = forward * vertical + this.camera.transform.right.normalized * horizontal;
    // characterController.Move(speed * Time.deltaTime * move);
    this.camera.transform.position += speed * Time.deltaTime * move;

    if (Input.GetMouseButton(0)) {
      var multiply = Time.deltaTime * mouseSpeed;
      yaw   += multiply * Input.GetAxis("Mouse X");
      pitch -= multiply * Input.GetAxis("Mouse Y");
      this.camera.transform.eulerAngles = new Vector3(pitch, yaw, 0);
      Cursor.lockState = CursorLockMode.Locked;
    } else {
      Cursor.lockState = CursorLockMode.None;
    }
  }
}
