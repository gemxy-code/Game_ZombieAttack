using UnityEngine;

[CreateAssetMenu (fileName = "new Enemy Data", menuName = "Scriptable Objects/Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _zombieSpeed;
    [SerializeField] private float _health;
    [SerializeField] private int _score;
    [SerializeField] [Range(0, 100)] private int _chance;
    [HideInInspector] public int _weight;


    public float ZombieSpeed { get => _zombieSpeed;}
    public float Health { get => _health;}
    public int Score { get => _score;}
    public int Chance {  get => _chance;}

}
