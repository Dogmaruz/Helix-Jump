using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private List<Segment> _defaultSegments;

    //Добавляем пустые сегменты на этаже.
    public void AddEmptySegment(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _defaultSegments[Random.Range(0, _defaultSegments.Count)].SetEmpty();
        }

        //Удалил этот код.
        // Обратный цикл, так как при удалении, массив сдвагается влево
        //for (int i = amount; i >= 0; i--)
        //{
        //    _defaultSegments.RemoveAt(i);
        //}
    }

    //Добавляем ловушки на этаже.
    public void AddRandomTrapSegment(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, _defaultSegments.Count);

            //Изменил код из обучающего видео, т.к. код стал более понятным и читаемым.
            if (_defaultSegments[index].Type == SegmentType.Empty) return;

                _defaultSegments[index].SetTrap();
            //Удалил этот код.
            // _defaultSegments.RemoveAt(index);
        }
    }

    //Добавляем сегменты финального этажа.
    public void SetFinishAllSegment()
    {
        for (int i = 0; i < _defaultSegments.Count; i++)
        {
            _defaultSegments[i].SetFinish();
        }
    }

    //Задаем случайный поворот.
    public void SetRandomRotation()
    {
        transform.eulerAngles = -new Vector3(0, Random.Range(0, 360), 0);
    }

}
