using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] public float scrollSpeed = 0.5f;

    [SerializeField] public Rigidbody2D rbForOffset;
    [SerializeField] private float offset = 0;
    [SerializeField] private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // scrollSpeed.x = rbForOffset.velocity.x;
        // scrollSpeed.y = rbForOffset.velocity.y;
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

}
