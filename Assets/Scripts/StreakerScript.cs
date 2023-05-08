using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakerScript : MonoBehaviour
{

    private Vector3 initialPosition;
    public float distance = 40f;
    public float duration = 1.5f;

    private IEnumerator MoveObject()
    {
        while (true)
        {
            yield return MoveToX(-distance, duration);
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
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        gameObject.SetActive(false);
        float random = Random.Range(1f, 60f);
        Debug.Log(random);
        Invoke("Appear", random);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Appear()
    {
        gameObject.SetActive(true);
        StartCoroutine(MoveObject());
    }
}
