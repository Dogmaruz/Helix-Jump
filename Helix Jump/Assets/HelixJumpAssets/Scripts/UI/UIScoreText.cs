using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIScoreText : BallEvent
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private ScoreCollector _scoreCollector;
    
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Trap)
        {
            _scoreText.text = _scoreCollector.Scores.ToString();
        }
    }
}
