using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float distance = 5f;
    public float duration = 1.5f;

    private IEnumerator MoveObject()
    {
        while (true)
        {
            yield return MoveToX(-distance, duration);
            yield return MoveToZ(distance, duration);
            yield return MoveToX(distance, duration);
            yield return MoveToZ(-distance, duration);
        }
    }

    private IEnumerator MoveToX(float targetX, float moveDuration)
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(targetX, startPosition.y, startPosition.z);
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }

    private IEnumerator MoveToZ(float targetZ, float moveDuration)
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y, targetZ);
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveObject());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
