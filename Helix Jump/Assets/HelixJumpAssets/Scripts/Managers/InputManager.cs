using UnityEngine;

public class InputManager : BallEvent
{
    [SerializeField] private MouseRotator _mouseRotator;
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Trap || type == SegmentType.Finish)
        {//Останавливает вращение при столкновении с ловушкой или финишным этажем.
            _mouseRotator.enabled = false;
        }
    }
}
