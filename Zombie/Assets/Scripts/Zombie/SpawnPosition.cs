using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    private int _spawnPositionCount = 3;

    //Points for screen boards 
    private int _topScreenBoard;
    private int _midleXScreenBoard;
    private int _leftScreenBoard;
    private int _rightScreenBoard;

    private void Awake()
    {
        _topScreenBoard = Mathf.FloorToInt(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).z) + 1;
        _midleXScreenBoard = Mathf.FloorToInt(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2)).z) + 1;
        _leftScreenBoard = Mathf.FloorToInt(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x) + 1;
        _rightScreenBoard = Mathf.FloorToInt(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 1;
    }

    private void OnDisable()
    {
       transform.position = CalculatePosition();
    }

    private Vector3 CalculatePosition()
    {
        int place = Random.Range(0, _spawnPositionCount);

        switch (place)
        {
            case 0:
                return RightPositionSpawn();
            case 1:
                return LeftPositionSpawn();
            case 2:
            default:
                return TopPositionSpawn();
        }
    }

    private Vector3 TopPositionSpawn() => new Vector3(Random.Range(_leftScreenBoard, _rightScreenBoard), 0, _topScreenBoard);
    private Vector3 LeftPositionSpawn() => new Vector3(_leftScreenBoard, 0, Random.Range(_midleXScreenBoard, _topScreenBoard));
    private Vector3 RightPositionSpawn() => new Vector3(_rightScreenBoard, 0, Random.Range(_midleXScreenBoard, _topScreenBoard));
}
