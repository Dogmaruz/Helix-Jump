using UnityEngine;

public class CreaterMark : OneColliderTrigger
{
    [SerializeField] private GameObject _markPrefab;

    [SerializeField] private Material _ballMaterial;

    [SerializeField] private GameObject _ballPrefab;

    protected override void OnOneTriggerEnder(Collider other)
    {
        Segment segment = other.GetComponent<Segment>();

        if (segment.Type != SegmentType.Empty)
        { // ќставл€ет след от падающего м€ча при соприкосновении с этажем.
            Vector3 markPosition = new Vector3(_ballPrefab.transform.position.x, other.transform.position.y + 0.5f, _ballPrefab.transform.position.z);

            Quaternion markRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            _markPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterial.color = _ballMaterial.color;

            GameObject mark = Instantiate(_markPrefab, markPosition, markRotation, other.transform);
        }
    }
}
