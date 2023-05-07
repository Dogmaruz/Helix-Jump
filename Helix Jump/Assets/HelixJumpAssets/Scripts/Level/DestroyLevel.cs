using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DestroyLevel : BallEvent
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private AudioSource finishSound;
    [SerializeField] private UnityEvent _eventDestroy;

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            Destroy(_levelGenerator.Floors[_levelGenerator.Floors.Count - 1].gameObject);
            _levelGenerator.Floors.Remove(_levelGenerator.Floors[_levelGenerator.Floors.Count - 1]);

            Destroy(_levelGenerator.DestroyFloors[_levelGenerator.DestroyFloors.Count - 1].gameObject, 0.5f);
            _levelGenerator.DestroyFloors[_levelGenerator.DestroyFloors.Count - 1].GameObject().SetActive(true);
            _levelGenerator.DestroyFloors.Remove(_levelGenerator.DestroyFloors[_levelGenerator.DestroyFloors.Count - 1]);

            if (_levelGenerator.DestroyFloors.Count < 2)
            {
                finishSound.volume = 0.2f;
                finishSound.Play();
            }

            _eventDestroy?.Invoke();
        }
    }
}
