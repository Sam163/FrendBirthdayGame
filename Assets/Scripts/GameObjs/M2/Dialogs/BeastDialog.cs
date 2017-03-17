using UnityEngine;
using System.Collections;

namespace Level2
{
    public class BeastDialog : BaseDialog
    {
        void Start()
        {

            Inicialize();

            talkers.Add("Буздя");
            dialog.Add("Выходи на битву Синий Зверь! Я тебя не боюсь!...");

            talkers.Add("Буздя");
            dialog.Add("Дэн?...");

            talkers.Add("Синий Зверь");
            dialog.Add("Нет, блин, Курт Рассел! Буздя, ты же должен быть уже в порту!");

            talkers.Add("Буздя");
            dialog.Add("Да... но, какого черта, Синий Зверь - это ты?!");

            talkers.Add("Синий Зверь");
            dialog.Add("Всё из-за какой-то падлы, которая в злосчастный день крикнула - Пей!");

            talkers.Add("Буздя");
            dialog.Add("Ну... Сорян.");

            talkers.Add("Синий Зверь");
            dialog.Add("Эх... Пошли до порта дорогу покажу, а то уже ночь. Заплутаешь.");

            repeated = false;
        }

        public override void SendEvents()
        {
            EventorL2 e = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<EventorL2>();
            e.EventOnBeastDialog();
        }

    }
}

