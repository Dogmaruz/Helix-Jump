using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
    private BallMovement _movement;

    [SerializeField] private UnityEvent _scoreEvent;

    [HideInInspector] public UnityEvent<SegmentType> _ballOnTriggerEvent;

    private void Start()
    {
        _movement = GetComponent<BallMovement>();
    }

    //Проверка на столкновение с разными типами сегментов этажа.
    protected override void OnOneTriggerEnder(Collider other)
    {
        Segment segment = other.GetComponent<Segment>();

        if (segment.Type == SegmentType.Empty)
        {
            _movement.Fall(other.transform.position.y);
        }

        if (segment.Type == SegmentType.Default)
        {
            _movement.Jump();
        }

        if (segment.Type == SegmentType.Trap || segment.Type == SegmentType.Finish)
        {
            _movement.Stop();

            if (segment.Type == SegmentType.Trap)
            {
                _scoreEvent?.Invoke();
            }
        }

        _ballOnTriggerEvent.Invoke(segment.Type);
    }
}
