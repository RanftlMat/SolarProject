using UnityEngine;

public class PlanetComponent : MonoBehaviour
{
    public float RotationSpeed;

    public void ResetComponent()
    {
        transform.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 1, 0), RotationSpeed * Time.deltaTime);
    }
}
