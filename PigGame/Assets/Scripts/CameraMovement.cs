using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _cameraOffsetX;
    [SerializeField] private float _cameraOffsetY;

    [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
    [SerializeField] private float _upperLimit;
    [SerializeField] private float _bottomLimit;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //CameraMovement
        //target = _playerPosition.position;
        //target.x += _cameraOffsetX;
        //target.y += _cameraOffsetY;
        //target.z = -10f;
        //transform.position = Vector3.Lerp(transform.position, target, _movementSpeed*Time.deltaTime);
        ////Limit camera
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
        //    transform.position.y,
        //    transform.position.z);
    }
}
