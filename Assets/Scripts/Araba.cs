using UnityEngine;

public class araba : MonoBehaviour
{
    public bool ilerle;
    //
    //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(ilerle)
            transform.Translate(15f * Time.deltaTime * transform.forward);
    }
}
