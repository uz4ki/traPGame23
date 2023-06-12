using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Games.Uzaki
{
    public class BallThrower : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ball;
        [SerializeField] private Transform arrow;
        [Header("Options")]
        [SerializeField] private float swayAngleLimit;
        [SerializeField] private float swayAngleSpeed;
        [SerializeField] private float randomOffsetLimit;
        private float _startAngle;
        

        private void Start()
        {
            _startAngle = arrow.rotation.z;
            arrow.position += Vector3.right * Random.Range(-randomOffsetLimit, randomOffsetLimit);
        }

        private void Update()
        {
            
        }
    }
}
