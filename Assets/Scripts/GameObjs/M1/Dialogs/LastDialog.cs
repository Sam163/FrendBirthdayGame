using UnityEngine;
using System.Collections;

namespace Level1
{
    public class LastDialog : BaseDialog
    {
        void Start()
        {
            Inicialize();

            talkers.Add("Тевтонец");
            dialog.Add("Ну что готов?");

            talkers.Add("Буздя");
            dialog.Add("Нет ещё.");

            repeated = true;
        }

        public override void SendEvents()
        {
            if (repeated == false)
            {
                EventorL1 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL1>();
                e.EventLastDialog();
            }
        }

        public void RewriteDialog() {
            talkers.Clear();
            dialog.Clear();

            talkers.Add("Тевтонец");
            dialog.Add("Ну что готов?");

            talkers.Add("Буздя");
            dialog.Add("Да.");

            talkers.Add("Тевтонец");
            dialog.Add("Тогда дуй в порт, ты отправляешься в Казахстан.");

            talkers.Add("Буздя");
            dialog.Add("Что? Какой к черту Казахстан? Что я там забыл? Мне там по степи плавать?");

            talkers.Add("Тевтонец");
            dialog.Add("Трансатлантические компании не интересует ваше мнение, умник. Так то там Каспийское море.");

            talkers.Add("Тевтонец");
            dialog.Add("Чего тебе ещё надо? И кстати, тебя у двери друзья ждут.");

            repeated = false;
            started = false;
            ended = false;
            fstTime = true;
            Debug.Log(dialog.Count);
        }

    }
}

