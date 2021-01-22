using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBlocks : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameLord.blocksDestroyed++;
        Destroy(this.gameObject);
    }
}
