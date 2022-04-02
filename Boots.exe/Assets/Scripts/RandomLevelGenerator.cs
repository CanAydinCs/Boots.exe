using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    public GameObject levelMaterial;
    public Vector2 xDistance, yDistance, xBoyut, yBoyut;

    public float lowestHeight;

    private bool isStart = true;

    List<GameObject> platforms;

    private PlayerMovement movementScript;

    private void Start()
    {
        platforms = new List<GameObject>();

        movementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void CreatePlatform(Vector3 konum)
    {
        //creating next platforms
        Vector3 esas = new Vector3(Random.Range(xBoyut.x, xBoyut.y), Random.Range(yBoyut.x, yBoyut.y), 1);
        Vector3 newKonum;
        if (!isStart) {
            newKonum = new Vector3(
               Random.Range(konum.x + xDistance.x + esas.x * 2 + platforms[platforms.Count - 1].transform.localScale.x * 2, konum.x + xDistance.y + esas.y * 2 + platforms[platforms.Count - 1].transform.localScale.y * 2),
               Random.Range(konum.y + yDistance.x + esas.y * 2 + platforms[platforms.Count - 1].transform.localScale.y * 2, konum.y + yDistance.y + esas.y * 2 + platforms[platforms.Count - 1].transform.localScale.y * 2),
               0);
        }
        else
        {
            newKonum = new Vector3(Random.Range(konum.x + xDistance.x, konum.x + xDistance.y), Random.Range(konum.y + yDistance.x, konum.y + yDistance.y), 1);
            isStart = true;
        }

        GameObject platform = Instantiate(levelMaterial, newKonum, Quaternion.identity);

        platform.transform.localScale = esas;

        platforms.Add(platform);

        //deleting extra platforms for performance
        if(platforms.Count > 15)
        {
            GameObject yokEt = platforms[0];
            platforms.RemoveAt(0);
            Destroy(yokEt);

            //updating lowest high possible
            lowestHeight = GetLowestHeight() - 2;
        }
    }

    float GetLowestHeight()
    {
        float lowestHeight = platforms[0].transform.position.y;

        foreach (GameObject platform in platforms)
        {
            if(platform.transform.position.y - 2 < lowestHeight)
            {
                lowestHeight = platform.transform.position.y - 2;
            }
        }

        return lowestHeight;
    }
}
