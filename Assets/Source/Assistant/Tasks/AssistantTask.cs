using UnityEngine;

[RequireComponent(typeof(Assistant))]

public class AssistantTask : Task
{
    private Assistant _assistant => GetComponent<Assistant>();

    protected void ShowMessage(Task task)
    {
        _assistant.ActivateAssistant(task);
    }
}
