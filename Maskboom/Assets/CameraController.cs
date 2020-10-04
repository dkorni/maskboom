using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _offset;

    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        _offset = new Vector3(Player.position.x - transform.position.x, transform.position.y,
            transform.position.z-Player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = new Vector3(Player.position.x, 0, Player.position.z) + _offset;
        }
    }
}
