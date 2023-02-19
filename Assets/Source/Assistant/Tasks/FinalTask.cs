using UnityEngine.Events;

public class FinalTask : AssistantTask
{
    public UnityAction Trainingcompleted;

    private void OnEnable()
    {
        ShowMessage(this);
    }
}
