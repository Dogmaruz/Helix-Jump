using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _axis; //Ось этажей.

    [SerializeField] private Floor _floorPrefab; //Префаб этажа.

    [SerializeField] private FloorDestroy _floorDestroyPrefab; //Префаб разрушеного этажа.

    [Header("Settings")]
    [SerializeField] private int _defaultFloorAmount;

    [SerializeField] private float _floorHeight;

    public float _floorAmount = 0;

    public float FloorAmount => _floorAmount;

    private float _lastFloorY = 0;
    public float LastFloorY => _lastFloorY;

    public List<Floor> Floors => _floors;

    public List<FloorDestroy> DestroyFloors => _destroyFloors;

    [SerializeField] private int _emptySegmentAmount;

    [SerializeField] private int _minTrapSegmentAmount;

    [SerializeField] private int _maxTrapSegmentAmount;

    private List<Floor> _floors = new List<Floor>();

    private List<FloorDestroy> _destroyFloors = new List<FloorDestroy>();

    //Генерация этажей.
    public void Generate(int level)
    {
        DestroyChild();

        _floorAmount = _defaultFloorAmount + level;

        _axis.transform.localScale = new Vector3(1, _floorAmount * _floorHeight, 1);

        for (int i = 0; i < _floorAmount; i++)
        {
            Floor floor = Instantiate(_floorPrefab, transform);

            floor.transform.Translate(0, i * _floorHeight, 0);

            floor.name = "Floor " + i;

            _floors.Add(floor);

            FloorDestroy floorDestroy = Instantiate(_floorDestroyPrefab, transform);

            floorDestroy.transform.Translate(0, i * _floorHeight, 0);

            floorDestroy.name = "FloorDestroy " + i;

            _destroyFloors.Add(floorDestroy);

            floorDestroy.gameObject.SetActive(false);

            if (i == 0)
            {
                floor.SetFinishAllSegment();
            }

            if (i > 0 && i < _floorAmount - 1)
            {
                floor.AddEmptySegment(_emptySegmentAmount);

                floor.SetRandomRotation();

                floor.AddRandomTrapSegment(Random.Range(_minTrapSegmentAmount, _maxTrapSegmentAmount + 1));
            }

            if (i == _floorAmount - 1)
            {
                floor.AddEmptySegment(_emptySegmentAmount);

                _lastFloorY = floor.transform.position.y;
            }
        }
    }

    //Удаляет все этажи.
    public void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == _axis) continue;

            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
