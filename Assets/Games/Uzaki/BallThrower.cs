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
        [SerializeField] private float throwingPower;
        private float _startAngle;
        

        private void Start()
        {
            _startAngle = arrow.rotation.eulerAngles.z;
            arrow.position += Vector3.right * Random.Range(-randomOffsetLimit, randomOffsetLimit);
        }

        private void Update()
        {
            var nowAngle = transform.rotation.eulerAngles.z;
            if (nowAngle > _startAngle + swayAngleLimit)
            {
                transform.rotation = Quaternion.Euler(0, 0, _startAngle + swayAngleLimit);
                swayAngleSpeed *= -1f;
            }
            if (nowAngle < _startAngle - swayAngleLimit)
            {
                transform.rotation = Quaternion.Euler(0, 0, _startAngle - swayAngleLimit);
                swayAngleSpeed *= -1f;
            }
            transform.Rotate(Vector3.forward * swayAngleSpeed * 0.01f);

            if (Input.anyKeyDown)
            {
                var ballObj= Instantiate(ball, transform.position, Quaternion.identity);
                ballObj.velocity = transform.up * throwingPower;
            }
        }
    }
}
