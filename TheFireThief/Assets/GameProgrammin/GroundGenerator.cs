using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform[] grounds;
    public Vector3 generatingNewPosition;

     public float generatingDistance;
     public float deletingDistance;
     public Transform prometheus;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (Vector2.Distance(prometheus.transform.position, generatingNewPosition) < generatingDistance)
        {
            Transform randomGround = grounds[Random.Range(0, grounds.Length)];

            Vector2 preferredPosition = new Vector2(generatingNewPosition.x - randomGround.Find("StartPosition").position.x, 0);

            Transform selectedGrounds = Instantiate (randomGround, preferredPosition, transform.rotation, transform);

            generatingNewPosition = selectedGrounds.Find("EndPosition").position;

        }

        DeletingGroundParts();
        
    }

    private void DeletingGroundParts()
    {
        if(transform.childCount > 0)
        {
            Transform deletingGround = transform.GetChild(0);

            if(Vector2.Distance(prometheus.transform.position, deletingGround.transform.position) > deletingDistance)

            Destroy(deletingGround.gameObject);
        }
    }
}
