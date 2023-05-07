using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreCollector : BallEvent
{
    [SerializeField] private int _scores;

    [SerializeField] private int _record;

    [SerializeField] private LevelProgress _levelProgress;

    [SerializeField] private Text _recordText;

    [SerializeField] private Text _scoreText;

    [SerializeField] private UnityEvent _scoreEvent;

    [SerializeField] private UnityEvent _recordEvent;

    private bool _isEmpty;

    public int Scores { get => _scores; set => _scores = value; }
    public int Record => _record;

    protected override void Awake()
    {
        base.Awake();

        _record = PlayerPrefs.GetInt("ScoreCollector:Record", 0);

        _scores = PlayerPrefs.GetInt("ScoreCollrctor:Score", 0);

        _recordText.text = _record.ToString();

        _scoreText.text = _scores.ToString();
    }
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty && _isEmpty)
        {
            _scores++;

            _scoreEvent?.Invoke();
        }

        if (type == SegmentType.Empty)
        {
            _scores ++;

            _scoreEvent?.Invoke();

            _isEmpty = true;
        }

        if (type != SegmentType.Empty)
        {
            _isEmpty = false;
        }

        if (type == SegmentType.Finish)
        {
            if (_record < _scores) _record = _scores;
            
            PlayerPrefs.SetInt("ScoreCollector:Record", _record);

            _recordText.text = _record.ToString();

            _recordEvent?.Invoke();
        }
    }
}
