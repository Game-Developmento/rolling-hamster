using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainCreator : MonoBehaviour
{
    [SerializeField] public SpriteShapeController shape;
    [SerializeField] public int posScale = 1000;
    [SerializeField] public int ptScale = 5;
    [SerializeField] public int numOfPts = 100;
    [SerializeField] private float distBetweenPts; // Offset between points

    void Awake()
    {
        shape = GetComponent<SpriteShapeController>();
        distBetweenPts = (float)(posScale / numOfPts);
        shape.spline.SetPosition(2, shape.spline.GetPosition(2) + Vector3.right * posScale);
        shape.spline.SetPosition(3, shape.spline.GetPosition(3) + Vector3.right * posScale);

        for (int i = 0; i < numOfPts; ++i)
        {
            float xPos = shape.spline.GetPosition(i + 1).x + distBetweenPts;
            float noise = Mathf.PerlinNoise(i, 0);
            shape.spline.InsertPointAt(i + 2, new Vector3(xPos, ptScale * noise, 0));
        }

        // Make the curves smoother
        for (int i = 2; i < numOfPts + 2; ++i) // Start i from 2 (this is where the first point is!)
        {
            shape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            shape.spline.SetLeftTangent(i, new Vector3(-2f, 0, 0));
            shape.spline.SetRightTangent(i, new Vector3(2f, 0, 0));
        }
    }

    void Update()
    {

    }
}
