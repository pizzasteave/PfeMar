using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Singleton<Rotate>
{
    public Vector3 rotation; 
    public float rotSpeed = 50f;

     void Update()
    {
        transform.Rotate(rotation * rotSpeed * Time.deltaTime);
    }
}
