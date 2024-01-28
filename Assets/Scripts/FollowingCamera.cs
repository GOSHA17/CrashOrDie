using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform _mainCharacter;
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _rearDistance;
    [SerializeField] private float _height;

    private Vector3 _currentVector;
    private Vector3 _characterPosition => _mainCharacter.position;

    private void Start()
    {
        transform.position = new Vector3(_characterPosition.x, _characterPosition.y + _height, _characterPosition.z + _rearDistance);
        transform.rotation = Quaternion.LookRotation(_characterPosition - transform.position);
    }

    private void Update()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        _currentVector = new Vector3(_characterPosition.x, _characterPosition.y + _height, _characterPosition.z + _rearDistance);
        transform.position = Vector3.Lerp(transform.position, _currentVector, _returnSpeed * Time.deltaTime);
    }
}
