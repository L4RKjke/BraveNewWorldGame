using UnityEngine;

[RequireComponent(typeof(Assistant))]
[RequireComponent(typeof(HintController))]

public class AssistantTask : Task
{
    private Assistant _assistant => GetComponent<Assistant>();

    protected HintController HintController => GetComponent<HintController>();

    protected void ShowMessage(Task task)
    {
        _assistant.ActivateAssistant(task);
    }
}
