using UnityEngine;

public class InputManager : BallEvent
{
    [SerializeField] private MouseRotator _mouseRotator;
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Trap || type == SegmentType.Finish)
        {
            _mouseRotator.enabled = false;
        }
    }
}
