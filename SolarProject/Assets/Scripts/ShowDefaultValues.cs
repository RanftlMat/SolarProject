using TMPro;
using UnityEngine;

public class ShowDefaultValues : MonoBehaviour
{
    public GameObject Planet;

    public GameObject MassText;
    public GameObject VelocityText;
    public GameObject PositionText;

    // Start is called before the first frame update
    void Start()
    {
        var massText = MassText.GetComponent<TextMeshProUGUI>();
        massText.text = $"Default: {Planet.GetComponent<GravityComponent>().Mass}";
        
        var velocityText = VelocityText.GetComponent<TextMeshProUGUI>();
        velocityText.text = $"Default: {Planet.GetComponent<GravityComponent>().InitialVelocity.z}";
        
        var positionText = PositionText.GetComponent<TextMeshProUGUI>();
        positionText.text = $"Default: {Planet.GetComponent<GravityComponent>().transform.position.x}";
    }
}
