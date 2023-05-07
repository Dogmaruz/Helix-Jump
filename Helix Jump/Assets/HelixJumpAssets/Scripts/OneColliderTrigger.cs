using UnityEngine;

public abstract class OneColliderTrigger : MonoBehaviour
{
    private Collider _lastCollider;

    protected virtual void OnOneTriggerEnder(Collider other) { }

    private void OnTriggerEnter(Collider other)
    {
        if (_lastCollider == null )
        {
           _lastCollider = other;

            OnOneTriggerEnder(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_lastCollider == other)
        {
           _lastCollider = null;

        }
    }
}
