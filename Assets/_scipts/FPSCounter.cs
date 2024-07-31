using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private int frameCount = 0;
    private float dt = 0.0f;
    private float fps = 0.0f;
    private float updateRate = 4.0f;

    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1.0f / updateRate;
        }
    }

    public float GetFPS()
    {
        return fps;
    }
}