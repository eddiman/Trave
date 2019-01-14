using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    public class DetectFaces
    {

        public static int DetectSides(Vector3 transformVector, Dictionary<Vector3, int> rotAngleDict )
        {
            foreach (var entry in rotAngleDict)
            {
                var key = entry.Key;
                var euler = transformVector;

                if (key.ToString().Equals(euler.ToString()))
                {
                    Debug.Log("Angles are = " + entry.Key + ", cube code = " + entry.Value);
                    return entry.Value;

                }
            }
            return 0;

        }

        public static void setObjTagToFacingCam(GameObject gameObject, int currentCode, int correctCode)
        {
            gameObject.tag = "FacingCam";
        }
        
        public static void setObjTagToNotFacingCam(GameObject gameObject, int currentCode, int correctCode)
        {
            gameObject.tag = "NotFacingCam";
        }
    }
}