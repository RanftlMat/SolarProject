using UnityEngine;

public class ShowPlanetsEdit : MonoBehaviour
{
    private bool _show;

    private GameObject[] _planets;

    public GameObject ArrowSprite;

    private void Start()
    {
        _planets = GameObject.FindGameObjectsWithTag("EditPlanet");

        foreach (var planet in _planets)
        {
            planet.SetActive(false);
        }
    }

    public void OnShow()
    {
        _show = !_show;

        ArrowSprite.transform.Rotate(Vector3.forward, 180);
        
        foreach (var planet in _planets)
        {
            planet.SetActive(_show);
        }
    }
}
