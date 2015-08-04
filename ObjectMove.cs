using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour
{
    public float speed = 15;

	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
