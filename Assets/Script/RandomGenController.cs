using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenController : MonoBehaviour
{
    public const int RangeZ = 3;
    public const int RangeX = 3;
    public const int RangeY = 7;
    
    // Start is called before the first frame update
    void Start()
    {


        for (int x = generateRandomMinCoord(RangeX); x < generateRandomMaxCoord(RangeX); x++)
        {
            for (int y = generateRandomMinCoord(RangeY); y < generateRandomMaxCoord(RangeY); y++)
            {
               // for (int z = generateRandomMinCoord(RangeZ); z < generateRandomMaxCoord(RangeZ); z++)
                //{
                    Instantiate(Resources.Load<GameObject>("Prefabs/rubiks_cube_gen"), new Vector3(x, y, 0),
                        Quaternion.identity);
                //}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    int generateRandomMaxCoord(int range)
    {
        //Find the minimum rang on th
        int minCoord = range * (-1);

       
        return Random.Range(1, range);

    }
    
    int generateRandomMinCoord(int range)
    {
        //Find the minimum rang on th
        int minCoord = range * (-1);

       
        return Random.Range(minCoord, 0);

    }
}
