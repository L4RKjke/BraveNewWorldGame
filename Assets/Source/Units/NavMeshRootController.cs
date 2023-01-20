using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavMeshRootController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;

    private void OnEnable()
    {
        InitAgent();
    }

    public void SetStoppingDistance(float distance)
    {
        _navMesh.stoppingDistance = distance;
    }

    public void MoveTo(Vector3 position, float speed)
    {
        _navMesh.speed = speed;
        _navMesh.SetDestination(position);
    }

    public void StopAgent()
    {
/*        if (_navMesh != null)
            _navMesh.isStopped = true;*/
    }

    public void MakeMoveble()
    {
        _navMesh.isStopped = false;
    }

    private void InitAgent()
    {
        _navMesh.updateRotation = false;
        _navMesh.updateUpAxis = false;
        _navMesh.stoppingDistance = 0;
    }
}
