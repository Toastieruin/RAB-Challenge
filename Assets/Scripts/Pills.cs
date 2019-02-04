using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(30, 0, 45) * Time.deltaTime);
        
    }
}
