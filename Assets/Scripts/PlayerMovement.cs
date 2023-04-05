using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayer
{
    public float speed;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
        transform.Rotate(transform.up * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
    }
}

public interface IPlayer
{

}
