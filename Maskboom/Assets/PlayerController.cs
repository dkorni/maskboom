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
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0,vertical) *_speed * Time.deltaTime;

        //_characterController.Move(direction);
        _rigidbody.MovePosition(transform.position + direction);
        //_rigidbody.velocity =  + direction);

    }
}
