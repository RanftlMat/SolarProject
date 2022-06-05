using UnityEngine;

public class SimulationComponent : MonoBehaviour
{
    private GravityComponent[] _gravityComponents;
    private PlanetComponent[] _planetComponents;

    private bool _simulate;
    
    private void Start()
    {
        _gravityComponents = FindObjectsOfType<GravityComponent>();
        _planetComponents = FindObjectsOfType<PlanetComponent>();
    }

    public void OnStart()
    {
        _simulate = true;
    }

    public void OnPause()
    {
        _simulate = false;
    }

    public void OnReset()
    {
        _simulate = false;

        foreach (var gravityComponent in _gravityComponents)
        {
            gravityComponent.ResetComponent();
        }

        foreach (var planetComponent in _planetComponents)
        {
            planetComponent.ResetComponent();
        }
    }
    
    public void OnExit()
    {
        Application.Quit();
    }
    
    private void FixedUpdate()
    {
        if (!_simulate) return;

        foreach (var gravityComponent in _gravityComponents)
        {
            gravityComponent.UpdateVelocity(_gravityComponents, Time.fixedDeltaTime);
        }

        foreach (var gravityComponent in _gravityComponents)
        {
            gravityComponent.UpdatePosition(Time.fixedDeltaTime);
        }

        foreach (var planetComponent in _planetComponents)
        {
            planetComponent.Rotate();
        }
    }
}
