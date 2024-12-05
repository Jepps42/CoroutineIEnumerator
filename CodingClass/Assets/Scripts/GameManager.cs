using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Variables
    private GameObject square;
    private SpriteRenderer squareColor;
    public Color startCol;
    public Color endCol;
    public float colTime;

    // Start is called before the first frame update
    void Start()
    {
        square = this.gameObject;
        squareColor = square.GetComponent<SpriteRenderer>();
        StartCoroutine(WaitandAppear(2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitandAppear(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        square.SetActive(true);
        StartCoroutine(Rotation(360, 1));
        StartCoroutine(ColorChange(startCol, endCol, colTime));

    }

    IEnumerator Rotation(float angle, float roatTime)
    {
       Quaternion startRotation = square.transform.rotation;
        float t = 0;

        while (t < 1f)
        {
            t = Mathf.Min(1f, t + Time.deltaTime / roatTime);
            Vector3 newEuler = Vector3.forward * (angle * t);
            square.transform.rotation =  Quaternion.Euler(newEuler) * startRotation;
            yield return null;
        }
    }


    IEnumerator ColorChange(Color startColor, Color endColor,float changeSpeed)
    {
        float t = 0;
        while (squareColor.color != endColor)
        {
            t += Time.deltaTime * changeSpeed;
            squareColor.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
    }
}
