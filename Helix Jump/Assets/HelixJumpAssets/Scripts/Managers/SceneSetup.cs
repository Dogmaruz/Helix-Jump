using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private BallController _ballController;
    [SerializeField] private LevelProgress _levelProgress;

    private void Awake()
    {
        _levelGenerator.Generate(_levelProgress.CurrentLevel);
       _ballController.transform.position = new Vector3(_ballController.transform.position.x, _levelGenerator.LastFloorY, _ballController.transform.position.z);
    }
}
