using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : BallEvent
{
    [SerializeField] private Text _scoreText;

    [SerializeField] private ScoreCollector _scoreCollector;
    
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Trap)
        {//Обновления счета очков.
            _scoreText.text = _scoreCollector.Scores.ToString();
        }
    }
}
