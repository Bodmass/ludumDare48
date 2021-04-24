using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        private Transform player;

        private Vector3 _cameraOffset;

        [Range(0.01f, 1.0f)]
        public float smoothFactor = 0.5f;
        public float RotationSpeed = 5.0f;


        private void Awake()
        {
            player = GameObject.FindObjectOfType<playerMovement>().transform;
        }

        void Start(){
            _cameraOffset = transform.position - player.position;
        }

        private void LateUpdate()
        {
            


            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
        
            _cameraOffset = camTurnAngle * _cameraOffset;


            Vector3 newPos = player.position + _cameraOffset;

            transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

            transform.LookAt(player);
        }
    }