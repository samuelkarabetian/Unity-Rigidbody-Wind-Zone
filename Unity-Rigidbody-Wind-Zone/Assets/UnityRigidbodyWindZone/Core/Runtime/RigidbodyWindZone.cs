using System.Collections.Generic;
using UnityEngine;

public class RigidbodyWindZone : MonoBehaviour
{
    [Header("Wind Settings")]
    [SerializeField] [Range(0f, 100f)] private float _masterWindStrength = 1f;
    [SerializeField] private Wind[] _winds = null;

    [Header("Zone Settings")]
    [SerializeField] private float _zoneRadius = 20f;
    [SerializeField] private LayerMask _layerMask = default;
    [SerializeField] private float _getRigidbodiesInterval = 1f;

    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    public void SetMasterWindStrength(float masterWindStrength)
    {
        _masterWindStrength = masterWindStrength;
    }

    private void Awake()
    {
        InvokeRepeating("GetRigidbodiesInZone", 0f, _getRigidbodiesInterval);
    }

    private void FixedUpdate()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            foreach (var wind in _winds)
            {
                var windForce = wind.GetWindForceAtPosition(rigidbody.position) * _masterWindStrength;
                rigidbody.AddForce(windForce, ForceMode.Force);
            }
        }
    }

    private void GetRigidbodiesInZone() 
    {
        _rigidbodies.Clear();
        var colliders = Physics.OverlapSphere(transform.position, _zoneRadius, _layerMask);
        foreach (var collider in colliders)
        {
            var rigidbody = collider.GetComponent<Rigidbody>();
            if (rigidbody) _rigidbodies.Add(rigidbody);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 0f, 1f, 0.3f);
        Gizmos.DrawSphere(transform.position, _zoneRadius);
    }
}
