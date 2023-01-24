using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _moveObj = null;
    [SerializeField]
    private float _runSpeed = default(float);

    private Rigidbody _rb = null;

    [SerializeField]
    private Camera _mainCamera = null;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _mainCamera.transform.position += gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 moveForward = Vector3.forward * _runSpeed;
            _rb.AddForce(moveForward);
        }
    }
}
