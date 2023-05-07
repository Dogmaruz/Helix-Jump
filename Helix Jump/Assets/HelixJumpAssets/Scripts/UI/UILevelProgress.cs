using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UILevelProgress : BallEvent
{
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private LevelGenerator _levelGenerator;

    [SerializeField] private Text _currentLevelText;
    [SerializeField] private Text _nextLevelText;
    [SerializeField] private Image _progressBar;
    [SerializeField] private UnityEvent _progressBarEvent;

    private float _fillAmountStep;

    private void Start()
    {
        _currentLevelText.text = _levelProgress.CurrentLevel.ToString();
        _nextLevelText.text = (_levelProgress.CurrentLevel + 1).ToString();
        _progressBar.fillAmount = 0;

        _fillAmountStep = 1 / (_levelGenerator.FloorAmount - 1);
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty || type == SegmentType.Finish)
        {
            _progressBar.fillAmount += _fillAmountStep;
            _progressBarEvent?.Invoke();
        }
    }
}
