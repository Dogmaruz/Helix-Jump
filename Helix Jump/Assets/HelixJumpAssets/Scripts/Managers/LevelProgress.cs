using UnityEngine;

public class LevelProgress : BallEvent
{
    private int _currentLevel = 1;
    public int CurrentLevel => _currentLevel;

    [SerializeField] private ScoreCollector _scoreCollector;
    [SerializeField] private SceneHelper _sceneHelper;

    protected override void Awake()
    {
        base.Awake();

        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            _sceneHelper.RestartLevel();
        }
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Finish)
        {
            _currentLevel++;
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("LevelProgress:CurrentLevel", _currentLevel);
        PlayerPrefs.SetInt("ScoreCollrctor:Score", _scoreCollector.Scores);
    }

    private void Load()
    {
        _currentLevel = PlayerPrefs.GetInt("LevelProgress:CurrentLevel", 1);
        _scoreCollector.Scores = PlayerPrefs.GetInt("ScoreCollrctor:Score", 0);
    }

    private void Reset()
    {
        PlayerPrefs.DeleteKey("LevelProgress:CurrentLevel");
        PlayerPrefs.DeleteKey("ScoreCollrctor:Score");

        _sceneHelper.RestartLevel();
    }
}
