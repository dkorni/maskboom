using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var directionVertical = transform.forward * vertical *_speed * Time.deltaTime;
        var directionHorizontal = transform.right * horizontal *_speed * Time.deltaTime;


        //_characterController.Move(direction);
        _rigidbody.MovePosition(transform.position + directionVertical);
        _rigidbody.MovePosition(transform.position + directionHorizontal);
        //_rigidbody.velocity =  + direction);

    }
}
