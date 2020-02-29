using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
  
    public int[][] wave;
    public int waveDepth = 0;
    public int waveDepthSpacing = 10;

    public int[][] basePattern = new int[][] { new int[] { -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 } };

    public static int[][] pattern_1 = new int[][] { new int[] { -7, -6, -3, -1, 0, 2, 5, 6 } };

    public static int[][] pattern_2 = new int[][] { new int[] { -7, -6 }, new int[] { -5, -4 }, new int[] { -3, -2 }, new int[] { -1, 0 }, new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } };


    public static int[][] pattern_3 = new int[][] {
        new int[] { -7, -6 },
        new int[] { -6, -4 },
        new int[] { -4, -3 },
        new int[] { -3, -2 },
        new int[] { -2 , -1 },
        new int[] { -1, 0 },
        new int[] { 0, 1 }
    };

    public static int[][] pattern_4 = new int[][] {
        new int[] { 7, 6 },
        new int[] { 6, 4 },
        new int[] { 4, 3 },
        new int[] { 3, 2 },
        new int[] { 2 , 1 },
        new int[] { 1, 0 },
        new int[] { 0, -1 }
    };




    public int[][][] level; 

    private int levelCounter = 1;
    private int totalPatterns;

    public float spawnTime = 1f;
    public float spawnDelay = 6f;

    void Start()
    {
        int[][] pattern_5 = new int[][] {
        new int[] { Random.Range(-7, 7), Random.Range(-7, 7) },
        new int[] { Random.Range(-7, 7), Random.Range(-7, 7) },
        new int[] { Random.Range(-7, 7), Random.Range(-7, 7) },
        new int[] { Random.Range(-7, 7), Random.Range(-7, 7) },
        new int[] { Random.Range(-7, 7), Random.Range(-7, 7) },
        new int[] { Random.Range(-7, 7), Random.Range(-7, 7)},
        new int[] { Random.Range(-7, 7), Random.Range(-7, 7) }
    };

        level = new int[][][] { pattern_1, pattern_2, pattern_3, pattern_4, pattern_5 };

        totalPatterns = level.Length;

        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        if (levelCounter < totalPatterns)
        {
            // more level to generate
            wave = level[levelCounter];

            foreach (int[] arr in wave)
            {
                foreach (int element in arr)
                {
                    Instantiate(obstacle, new Vector3(element, 0, 100 + (waveDepth * waveDepthSpacing)), Quaternion.identity);
                }
                waveDepth++;
            }
            waveDepth = 0;
            levelCounter++;
        }
        else
        {
            Debug.Log("the level is over");
            CancelInvoke("SpawnObject");
        }
    }
    
}
