using UnityEngine;

public class testCubeMaterial : MonoBehaviour
{
    public Color _material;

    private void Update()
    {
        GetComponent<Renderer>().material.color = _material;
    }
}
