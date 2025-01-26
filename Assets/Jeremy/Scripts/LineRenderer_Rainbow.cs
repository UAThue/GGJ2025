using UnityEngine;

public class LineRenderer_Rainbow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LineRenderer line;
    public Transform[] bubble;
    private bool alive = true;
    private float frame;

    public void SetUpLine(Transform[] points)
	{
        line.positionCount = points.Length;
        bubble = points;
	}

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            for (int i = 0; i < bubble.Length; i++)
            {
                line.SetPosition(i, bubble[i].position);
            }
            frame += Time.deltaTime;
            if(frame>0.03f)
			{
                //Cycle
                bubble = CycleArray();
                frame = 0;

            }
		}
		else
		{
            line.positionCount = 0;
            line.enabled = false;
		}
    }

    public void Done()
	{
        alive = false;
	}

    public Transform[] CycleArray()
	{
        Transform[] returner = new Transform[bubble.Length];
        for(int i = 0; i < bubble.Length-1; i++)
		{
            returner[i] = bubble[i + 1];
		}
        returner[bubble.Length - 1] = bubble[0];
        return returner;
 	}
}
