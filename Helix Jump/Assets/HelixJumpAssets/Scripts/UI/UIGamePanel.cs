using UnityEngine;

public class UIGamePanel : BallEvent
{
    [SerializeField] private GameObject _passedPanel;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private AudioSource _trapSound;

    private void Start()
    {
        _passedPanel.SetActive(false);
        _defeatPanel.SetActive(false);
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Trap)
        {
            _defeatPanel.SetActive(true);
            _trapSound.volume = 0.2f;
            _trapSound.Play();
        }

        if (type == SegmentType.Finish)
        {
            _passedPanel.SetActive(true);
        }
    }
}
