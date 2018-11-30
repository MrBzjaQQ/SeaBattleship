using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationModel
{
    //модель должна быть максимально простой.
    //есть слушатель, который получает пакет и через событие возвращает запрос
    //есть обработчик, который рассматривает текущий запрос, и преобразует его из HTTP запроса в нечто понятное модели
    //есть отправитель, который выбирает тип ответа и отправляет соответствующий ответ
    public class CommunicationModel
    {
        public CommunicationModel()
        {

        }
    }
}
