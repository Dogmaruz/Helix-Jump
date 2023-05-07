using UnityEngine;

public abstract class BallEvent : MonoBehaviour
{
    [SerializeField] protected BallController _ballController;

    protected virtual void Awake()
    {
        _ballController._ballOnTriggerEvent.AddListener(OnBallCollisionSegment);
    }

    protected virtual void OnDestroy()
    {
        _ballController._ballOnTriggerEvent.RemoveListener(OnBallCollisionSegment);
    }

    protected virtual void OnBallCollisionSegment(SegmentType type) { }
}
