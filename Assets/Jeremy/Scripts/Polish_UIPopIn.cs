using UnityEngine;
using UnityEngine.UI;

public class Polish_UIPopIn : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;

    private float timer1;
    private float timer2;
    private float timer3;
    private float timer4;
    private float goneTimer;

    private void Start()
    {
        one.transform.localScale = Vector3.zero;
        two.transform.localScale = Vector3.zero;
        three.transform.localScale = Vector3.zero;
        four.transform.localScale = Vector3.zero;
    }

	// Update is called once per frame
	void Update()
    {
        Vector3 bubble = new Vector3(1.25f, 1.25f, 1.25f);
        timer1 += Time.deltaTime*3;
        if (timer1 < 0.9f)
        {
            one.transform.localScale = Vector3.Lerp(Vector3.zero, bubble, timer1);
		}
		else
		{
            one.transform.localScale = Vector3.Lerp(bubble, Vector3.one, (timer1 -0.9f)*10);

            if (timer2 < 0.9f)
            {
                two.transform.localScale = Vector3.Lerp(Vector3.zero, bubble, timer2);
            }
            else
            {
                two.transform.localScale = Vector3.Lerp(bubble, Vector3.one, (timer2 - 0.9f) * 10);

                if (timer3 < 0.9f)
                {
                    three.transform.localScale = Vector3.Lerp(Vector3.zero, bubble, timer3);
                }
                else
                {
                    three.transform.localScale = Vector3.Lerp(bubble, Vector3.one, (timer3 - 0.9f) * 10);

                    if (timer4 < 0.9f)
                    {
                        four.transform.localScale = Vector3.Lerp(Vector3.zero, bubble, timer4);
                    }
                    else
                    {
                        four.transform.localScale = Vector3.Lerp(bubble, Vector3.one, (timer4 - 0.9f) * 10);
                    }
                }
            }
        }
        if(timer1>4.5f)
		{
            timer2 += Time.deltaTime * 3;
            if (timer2 > 4.5f)
            {
                timer3 += Time.deltaTime * 3;
                if(timer3>4.5f)
				{
                    timer4 += Time.deltaTime * 3;
                }
            }

        }            
        if(timer1>45)
		{
            goneTimer += Time.deltaTime * 4;
            one.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, goneTimer);
            two.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, goneTimer);
            three.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, goneTimer);
            four.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, goneTimer);
        }
    }
}
