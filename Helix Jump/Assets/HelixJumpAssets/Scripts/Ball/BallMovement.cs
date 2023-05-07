using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class BallMovement : MonoBehaviour
{
    [Header("Fall")]
    [SerializeField] private float _fallHeight;
    [SerializeField] private float _fallSpeedDefault;
    [SerializeField] private float _falltSpeedMax;
    [SerializeField] private float _falltSpeedAxeleration;
    [SerializeField] private AudioSource _ballSound;
    [SerializeField] private UnityEvent _jumpFeedBack;
    //[SerializeField] private GameObject _ballPrefab;


    private Animator _animator;

    private float _fallSpeed;
    private float _floorY;

    private void Start()
    {
        enabled = false;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.y > _floorY)
        {
            transform.Translate(0, -_fallSpeed * Time.deltaTime, 0);

            if (_fallSpeed < _falltSpeedMax)
            {
                _fallSpeed += _falltSpeedAxeleration * Time.deltaTime;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, _floorY, transform.position.z);
            enabled = false;
        }
    }
    public void Jump()
    {
        _animator.speed = 1;
        _animator.Play("Ball_Animation");
        _fallSpeed = _fallSpeedDefault;
        _ballSound.volume = 0.2f;
        _ballSound.Play();

        _jumpFeedBack?.Invoke();
    }

    public void Fall(float startFloorY)
    {
        _animator.speed = 0;
        _floorY = startFloorY - _fallHeight;
        enabled = true;
    }

    public void Stop()
    {
        _animator.speed = 0;
    }
}
