using UnityEngine;
using System.Collections;

//Note if your want to change it so it increments across the y then change the setting of the texture so it reads
//new Vector 2 (
//0, offset.y += Time.deltaTime / slowDown
//));
//Same if you want both!

public class ScrollingParticles : MonoBehaviour
{
    public float slowDown = 20f; //This slowing down the moving background

    public void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>(); //Geting the mesh render
        Material material1 = mr.material; //Getting all the materials down arrow (^)
        Material material2 = mr.materials[1];
        Vector2 offset1 = material1.GetTextureOffset("_MainTex"); //Getting a offset
        Vector2 offset2 = material2.GetTextureOffset("_MainTex"); //Getting a offset
        material1.SetTextureOffset("_MainTex", new Vector2( //Setting the offset of the texture (incrementing it)
            offset1.x += Time.deltaTime / slowDown, 0
            ));
        material2.SetTextureOffset("_MainTex", new Vector2( //Doing the same for the second texture ^^
    offset2.x -= (Time.deltaTime / slowDown), 0
    ));
    }
}
