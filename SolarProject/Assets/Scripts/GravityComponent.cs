using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GravityComponent : MonoBehaviour
{
    public float Mass;

    public Vector3 InitialVelocity;
    
    private const float GravitationalConstant = 6.67430E-5F;

    private float _startMass;

    private Vector3 _startVelocity;
    private Vector3 _startPosition;
    private Vector3 _currentVelocity;

    private void Start()
    {
        _currentVelocity = InitialVelocity;
        _startVelocity = InitialVelocity;
        
        _startPosition = transform.position;

        _startMass = Mass;
    }
    
    public void ResetComponent()
    {
        InitialVelocity = _startVelocity;
        _currentVelocity = _startVelocity;

        transform.position = _startPosition;

        Mass = _startMass;
    }

    public void ChangeMass(string newMass)
    {
        try
        {
            Mass = float.Parse(newMass);
        }
        catch (Exception e)
        {
            Debug.LogError("Invalid mass!");
            Debug.LogException(e);
        }
    }

    public void ChangePosition(string newPosition)
    {
        try
        {
            transform.position = new Vector3(float.Parse(newPosition), 0, 0);
        }
        catch (Exception e)
        {
            Debug.LogError("Invalid position!");
            Debug.LogException(e);
        }
    }

    public void ChangeVelocity(string newVelocity)
    {
        try
        {
            _currentVelocity = new Vector3(0, 0, float.Parse(newVelocity));
        }
        catch (Exception e)
        {
            Debug.LogError("Invalid velocity!");
            Debug.LogException(e);
        }
    }

    public void UpdateVelocity(GravityComponent[] gravityComponents, float deltaTime)
    {
        foreach (var otherPlanet in gravityComponents)
        {
            if (otherPlanet != this)
            {
                float distance = (otherPlanet.transform.position - transform.position).sqrMagnitude;

                if (distance == 0) return;

                float acceleration = GravitationalConstant * otherPlanet.Mass / distance;

                var force = acceleration * deltaTime * (otherPlanet.transform.position - transform.position).normalized;

                _currentVelocity += force;
            }
        }
    }

    public void UpdatePosition(float deltaTime)
    {
        gameObject.transform.position += _currentVelocity * deltaTime;
    }
}
