using UnityEngine;
using System.Collections;
using AssistanObejcts;

namespace Units {

    [RequireComponent(typeof(BotBaseCharacter))]
    public class BotBaseAIControl : MonoBehaviour {

        protected BotBaseCharacter m_Character;       // персонаж
        protected VisonDetector m_VisionDetector; //зрение
        protected float m_hmove;                  //вектор движения
        protected Timer m_waitTimer;              //таймер ожидания
        [SerializeField] protected float m_PatrolTimerLim = 1f;         //время простоя при патруле
        [SerializeField] protected float m_HitTimerLim = 1f;          //время простоя между ударами

        [SerializeField] protected Transform m_target;        //цель
        [SerializeField] protected float m_Rattack = 5f;      //радиус аттаки

        [SerializeField] protected float m_RPoint = 1f; //радиус достижения точки

        [SerializeField] public Transform[] m_PatrolPoint;
        protected int m_CurrentPoint;                         //текущая точка потрулирования
        protected int m_CountPoint;                           //всего точек

        protected AISTATE aiBackstate;            //предыдущее состояние ии

        protected enum AISTATE
        {
            PATROL_GO,
            PATROL_WAIT,
            PERSECUTE,
            HIT,
            HIT_WAIT,
            DEAD
        }

        [SerializeField] protected AISTATE aistate;

        protected void Awake()
        {
            m_Character = GetComponent<BotBaseCharacter>();
        }

        protected void Start()
        {
            //нач. сост. ии
            m_waitTimer = new Timer();
            aiBackstate = aistate;
            m_CountPoint = m_PatrolPoint.Length;
            m_CurrentPoint = 0;            

            m_target = GameObject.FindGameObjectWithTag("Player").transform;
            m_VisionDetector = transform.FindChild("VisionDetector").GetComponent<VisonDetector>();
            m_VisionDetector.SetVisionTarget(m_target);
        }
        public void Inicialize() {
            m_Character = GetComponent<BotBaseCharacter>();
            m_waitTimer = new Timer();
            //нач. сост. ии
            aiBackstate = aistate;
            m_CountPoint = m_PatrolPoint.Length;
            m_CurrentPoint = 0;

            m_target = GameObject.FindGameObjectWithTag("Player").transform;
            m_VisionDetector = transform.FindChild("VisionDetector").GetComponent<VisonDetector>();
            m_VisionDetector.SetVisionTarget(m_target);
        }

        protected void FixedUpdate()
        {        
            m_waitTimer.Ticking_fixedDeltaTime();
            AIDoIt();
        }
        protected void Update()
        {
            AIChooseState();// ??
        }

        protected void AIChooseState()
        {        //проверяем условия
            switch (aistate)
            {
                case AISTATE.PATROL_GO:
                    if (m_VisionDetector.isISee || Check_InRattack())                    //если увидели
                    {
                        aistate = AISTATE.PERSECUTE;
                    }
                    else
                        if ((this.transform.position - m_PatrolPoint[m_CurrentPoint].position).magnitude < m_RPoint)    //дошли до точки
                    {
                        aistate = AISTATE.PATROL_WAIT;
                    }
                    break;

                case AISTATE.PATROL_WAIT:
                    if (m_VisionDetector.isISee || Check_InRattack())                    //если увидели
                    {
                        aistate = AISTATE.PERSECUTE;
                    }
                    else if ((m_waitTimer.End || m_PatrolTimerLim == 0) && m_CountPoint > 1)//время ожидания закончено
                    {
                        aistate = AISTATE.PATROL_GO;
                    }
                    break;

                case AISTATE.PERSECUTE:
                    if (Check_InRattack())              //если догнали
                        aistate = AISTATE.HIT;
                    break;

                case AISTATE.HIT:
                    if (!Check_InRattack())             //если убегает
                        aistate = AISTATE.PERSECUTE;
                    /* else
                         if (m_EndHitEvent)              //если удар закончился и пауза между ударами !=0, делаем паузу
                     {
                         m_EndHitEvent = false;
                         if (m_HitTimerLim != 0)
                             aistate = AISTATE.HIT_WAIT;
                     }*/ //проверяется в Send_EndHitEvent()
                    break;

                case AISTATE.HIT_WAIT:
                    if (!Check_InRattack())            //если убегает
                    {
                        m_waitTimer.Off();
                        aistate = AISTATE.PERSECUTE;
                    }
                    else
                       if (m_waitTimer.End || m_HitTimerLim == 0)             //время ожидания закончено
                    {
                        m_waitTimer.Off();
                        aistate = AISTATE.HIT;
                    }
                    break;
            }
        }
        protected void AIDoIt()
        {
            if (m_Character.CheckDead()) {
                aistate = AISTATE.DEAD;
                m_Character.Die();
            }
            switch (aistate)
            {
                case AISTATE.PATROL_GO:
                    if (aiBackstate != aistate)//если только вошли в это состояние
                    {
                        m_CurrentPoint++;
                        if (m_CurrentPoint >= m_CountPoint)
                            m_CurrentPoint = 0;
                    }
                    m_hmove = (m_PatrolPoint[m_CurrentPoint].position - this.transform.position).normalized.x;
                    m_Character.Move(m_hmove);
                    break;

                case AISTATE.PATROL_WAIT:
                    if (aiBackstate != aistate)
                    {
                        m_Character.StopAttack();
                        m_waitTimer.Off();
                        m_waitTimer.Begin(m_PatrolTimerLim);
                    }
                    m_Character.Move(0f);
                    break;

                case AISTATE.PERSECUTE:
                    m_Character.StopAttack();
                    m_hmove = (m_target.position - this.transform.position).normalized.x;
                    m_Character.Move(m_hmove);
                    break;

                case AISTATE.HIT:
                    m_Character.LookAtTarget(m_target.position);
                    m_Character.Move(0f);
                    m_Character.Attack();
                    break;

                case AISTATE.HIT_WAIT:
                    if (aiBackstate != aistate)
                    {
                        m_waitTimer.Off();
                        m_waitTimer.Begin(Random.Range(0, m_HitTimerLim));
                    }
                    m_Character.Move(0f);
                    break;
            }
            aiBackstate = aistate;
        }

        protected bool Check_InRattack()
        {
            if (m_Rattack >= (this.transform.position - m_target.position).magnitude)
                return true;
            else return false;
        }

        protected void Send_AIEndHitEvent() {
            m_Character.StopAttack();
            aistate = AISTATE.HIT_WAIT;
        }
    }
}