using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollers : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(25, 0, 0) * Time.deltaTime);
    }
}

