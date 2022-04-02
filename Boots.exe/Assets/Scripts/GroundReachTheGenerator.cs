using UnityEngine;

public class GroundReachTheGenerator : MonoBehaviour
{
    RandomLevelGenerator randomGenerator;
    Renderer render;

    bool isCreated = false;

    private void Start()
    {
        randomGenerator = GameObject.FindGameObjectWithTag("Generator").GetComponent<RandomLevelGenerator>();

        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (render.isVisible && !isCreated)
        {
            randomGenerator.CreatePlatform(transform.position);
            isCreated = true;
        }
    }
}
