using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(29, "Паттерн «Фабрика» (уведомления)",
    "Реализовать фабрику уведомлений.",
    "Интерфейс INotification с методом Send(string message)",
    "Реализации: EmailNotification, SmsNotification, PushNotification",
    "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию",
    "enum NotificationType { Email, Sms, Push }",
    "Продемонстрировать создание и отправку через фабрику")]
public class Task29_FactoryPattern : ITask
{
    public void Run()
    {
        string message = "Ваш заказ готов!";

       
        INotification email = NotificationFactory.Create(NotificationType.Email);
        INotification sms = NotificationFactory.Create(NotificationType.Sms);
        INotification push = NotificationFactory.Create(NotificationType.Push);

        email.Send(message);
        sms.Send(message);
        push.Send(message);
    }
}