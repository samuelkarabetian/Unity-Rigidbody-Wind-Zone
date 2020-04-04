using UnityEngine;

[System.Serializable]
public class Wind
{
    [Range(0.1f, 100f)] public float _strength = 1f;
    [Range(0.01f, 20f)] public float _turbulence = 1f;
    public Vector3 _direction = Vector3.forward;
    public float _windDirectionRandomization = 0.5f;
    public float _directionChangeSpeed = 1f;

    public Vector3 GetWindForceAtPosition(Vector3 position)
    {
        var randomWindDirection = (new Vector3(Mathf.PerlinNoise(Time.time * _directionChangeSpeed, 0f) - 0.5f, 0f, Mathf.PerlinNoise(0f, Time.time * _directionChangeSpeed) - 0.5f));
        var windDirection = _direction.normalized * (1f - _windDirectionRandomization) + randomWindDirection * _windDirectionRandomization;
        var windForce = windDirection * Mathf.PerlinNoise(Time.time * _turbulence + position.x, Time.time * _turbulence + position.y) * _strength;
        return windForce;
    }
}