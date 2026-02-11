using UnityEngine;

public class ParallacEffect : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;  // 0= se mueve con la cámara, 1 = no se mueve 
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Cuánto nos hemos movido respecto al mundo 
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        //Cuánto debe moverse la capa
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        //Lógica de repetición infinita 
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
