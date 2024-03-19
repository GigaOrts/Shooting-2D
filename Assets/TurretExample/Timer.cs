using System;

public class Timer
{
    private float _counter;

    public void ComputeTime(float speed, float delay, Action action)
    {
        _counter += speed;

        if(_counter >= delay)
        {
            action.Invoke();
            _counter = 0f;
        }
    }
}
