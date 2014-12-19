using UnityEngine;
using System.Collections;

public class ScrollingParticles : MonoBehaviour
{
    public float slowDown = 20f;

    public void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material material1 = mr.material;
        Material material2 = mr.materials[1];
        Vector2 offset1 = material1.GetTextureOffset("_MainTex");
        Vector2 offset2 = material2.GetTextureOffset("_MainTex");
        material1.SetTextureOffset("_MainTex", new Vector2(
            offset1.x += Time.deltaTime / slowDown, 0
            ));
        material2.SetTextureOffset("_MainTex", new Vector2(
    offset2.x -= (Time.deltaTime / slowDown), 0
    ));
    }
}
