using UnityEngine;

public class knife : item
{
    public override void Useitem()
    {

    }
    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(0.3f, -1, 1);
    }

    void Update()
    {

    }
}
