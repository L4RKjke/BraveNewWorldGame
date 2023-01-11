using UnityEngine.Events;

public class FindTargetState : State
{
    public UnityAction StateActivated;

    /// �������� ���� �� �� ������, ����� ��� ��������

    private void OnEnable()
    {
        GetComponent<Fighter>().UpdateCurrentTarget();
        StateActivated?.Invoke();
    }
}
