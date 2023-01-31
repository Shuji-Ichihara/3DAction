using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private GameObject _player = null;
    [SerializeField]
    private float _runSpeed = 10.0f;

    private Rigidbody _rb = null;

    private Transform _cameraTransform = null;
    private Vector3 _offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _player = gameObject;
        _rb = GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.transform;
        _offset = _cameraTransform.position;
        _rb.freezeRotation = true;

        var startPosition = GameManager.Instance.StartZone.GetComponent<Transform>();
        _player.transform.position =
            new Vector3(startPosition.position.x
                       , startPosition.position.y + _player.transform.localScale.y / 2
                       , startPosition.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //MovePlayer();
    }

    private void FixedUpdate()
    {
        GameEnd();
        MovePlayer();
    }

    private void LateUpdate()
    {
        GameEnd();
        Camera.main.transform.position = _player.transform.position + _offset;
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 moveForward = Vector3.forward * _runSpeed * Time.deltaTime;
            _rb.AddForce(moveForward);
            //gameObject.transform.position += moveForward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 moveForward = Vector3.back * _runSpeed * Time.deltaTime;
            _rb.AddForce(moveForward);
            //gameObject.transform.position += moveForward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveForward = Vector3.left * _runSpeed * Time.deltaTime;
            _rb.AddForce(moveForward);
            //gameObject.transform.position += moveForward;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveForward = Vector3.right * _runSpeed * Time.deltaTime;
            _rb.AddForce(moveForward);
            //gameObject.transform.position += moveForward;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == GameManager.Instance.GameOver.name)
        {
            GameManager.Instance.IsOver = true;
        }
        if (other.gameObject.name == GameManager.Instance.GoalZone.name)
        {
            GameManager.Instance.IsClear = true;
        }
    }

    private void GameEnd()
    {
        if (true == GameManager.Instance.IsClear) { return; }
        if (true == GameManager.Instance.IsOver) { return; }
    }
}
