using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    

    void Update()
    {
        transform.Rotate(new Vector3(20,20,20) * Time.deltaTime);
    }
}
