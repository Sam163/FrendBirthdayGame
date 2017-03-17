using UnityEngine;
using System.Collections;

namespace Level1
{
    public class OtecDialog : BaseDialog
    {

        void Start()
        {
            Inicialize();

            talkers.Add("Отец");
            dialog.Add("Привет, сына!");

            talkers.Add("Буздя");
            dialog.Add("Привет.");

            talkers.Add("Отец");
            dialog.Add("В твоей палате, слишком мрачно. Ты не находишь? Надо сделать ремонтик.");

            talkers.Add("Буздя");
            dialog.Add("Да ну... Меня все устраивает.");

            talkers.Add("Отец");
            dialog.Add("А меня нет! Ты уже взрослый. Бывал и в море и в бою! А живешь как в хлеву!");
            talkers.Add("Отец");
            dialog.Add("Ты отправишся в рейс. Заработаешь себе денег на новые харомы.");

            talkers.Add("Буздя");
            dialog.Add("Вот блин!");

            talkers.Add("Отец");
            dialog.Add("Так что собирайся. Скоро отплытие.");

            repeated = false;
        }

    }
}
