using UnityEngine;
using System.Collections;

namespace Level2
{
    public class SkyChanger : MonoBehaviour
    {
        SpriteRenderer skyDay;
        SpriteRenderer skyEvning;
        SpriteRenderer skyNight;

        bool evning= false;
        bool night= false;
        [SerializeField] float speedEvning = 0.02f;
        [SerializeField] float speedNight = 0.08f;
        int sy=1900;
        int sx=2560;

        Vector3 skyScale;

        Camera camera;

        void OnEnable()
        {
            EventorL2.OnFrogQuestBegin += BeginEvning;
            EventorL2.OnFrogDied += BeginNight;
        }


        void OnDisable()
        {
            EventorL2.OnFrogQuestBegin -= BeginEvning;
            EventorL2.OnFrogDied -= BeginNight;
        }

        void Start() {
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            skyScale = transform.localScale;

            skyDay = transform.FindChild("day").gameObject.GetComponent<SpriteRenderer>();
            skyEvning = transform.FindChild("evning").gameObject.GetComponent<SpriteRenderer>();
            skyNight = transform.FindChild("night").gameObject.GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            if (evning) {
                SetEvning();
            }
            if (night) {
                SetNight();
            }
        }

        void LateUpdate()
        {

            skyScale.x = (float)camera.pixelWidth / (float)camera.pixelHeight * this.transform.localScale.y*0.75f;

            //Debug.Log(camera.pixelHeight + " " + camera.pixelWidth);
            this.transform.localScale = skyScale;
        }

        void SetEvning() {
            skyDay.color = Color.Lerp(skyDay.color, Color.clear, speedEvning * Time.deltaTime);

            if (skyDay.color.a <= 0.01f)
            {
                skyDay.color = Color.clear;
                //skyDay.enabled = false;
                evning = false;
            }
        }

        void SetNight()
        {
            skyEvning.color = Color.Lerp(skyEvning.color, Color.clear, speedNight * Time.deltaTime);

            if (skyEvning.color.a <= 0.01f)
            {
                skyEvning.color = Color.clear;
                //skyDay.enabled = false;
                night = false;
            }
        }

        void BeginEvning() {
            evning = true;
        }
        void BeginNight() {
            night = true;
        }
        /* public Material skyDay;
         public Material skyEvning;
         public Material skyNight;
         static Material Ref;
         public float duration = 2.0F;
         public Renderer rend = new Renderer();
         public bool huy=false;
         void Awake()
         {
             Ref = skyDay;

         }

         // Update is called once per frame
         void Update()
         {
             if (huy)
             {
                 //huy = false;
                 SetEvning();
                 //DynamicGI.UpdateEnvironment();
             }

         }
         void SetEvning() {
             RenderSettings.skybox = skyEvning;
             Debug.Log(RenderSettings.skybox);
         }*/

    }
}

