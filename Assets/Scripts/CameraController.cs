
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _yPosition = 6;
    private float _zOffset = -6;

    private void LateUpdate()
    {
        transform.position = new Vector3(0, _yPosition, _player.position.z + _zOffset);
    }
}
