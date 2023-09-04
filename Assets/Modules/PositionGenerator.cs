using UnityEngine;

public class PositionGenerator : MonoBehaviour
{
    [Space]
    [Header("Config Spawn Field")]
    [SerializeField] private Transform _centerSpawnPoint;

    [SerializeField] private Vector3 _squareSpawn;

    [SerializeField] private float _distanceBetweenEntity;

    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private int _buffer = 8;


    public Vector3 GetPosition()
    {
        var position = GeneratePosition();
        var counter = 0;

        while (CheckFreePosition(position) == false)
        {
            position = GeneratePosition();
            
            if (counter++ > 5)
                break;
        }

        return position;
    }

    private Vector3 GeneratePosition()
    {
        var posEnemy = new Vector3(
            Random.Range(_centerSpawnPoint.position.x - _squareSpawn.x / 2, _centerSpawnPoint.position.x + _squareSpawn.x / 2),
            _centerSpawnPoint.position.y,
            Random.Range(_centerSpawnPoint.position.z - _squareSpawn.z / 2, _centerSpawnPoint.position.z + _squareSpawn.z / 2)
            );

        return posEnemy;
    }

    private bool CheckFreePosition(Vector3 pos)
    {
        var result = new Collider[_buffer];

        var colliders = Physics.OverlapSphereNonAlloc(pos, _distanceBetweenEntity, result, _layerMask);

        if (colliders > 0)
            return false;
        else
            return true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(_centerSpawnPoint.position, _squareSpawn);
        Gizmos.color = Color.yellow;
    }
#endif
}
