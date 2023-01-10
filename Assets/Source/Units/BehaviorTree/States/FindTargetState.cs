using UnityEngine.Events;

public class FindTargetState : State
{
    private void Update()
    {
        GetComponent<Fighter>().UpdateCurrentTarget();
    }
}
