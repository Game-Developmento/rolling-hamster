using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleCollisions : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Barrier")
        {
            SceneManager.LoadScene("level-1");
        }
        else if (other.collider.tag == "Child")
        {
            Destroy(other.gameObject);
        }

    }

}
