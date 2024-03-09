using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShader : MonoBehaviour
{
  public Camera camera;
  public Shader shader;

  // Start is called before the first frame update
  void Start()
  {
    camera.SetReplacementShader(shader, "RenderType");
  }

  // Update is called once per frame
  void Update()
  {
    
  }
}
