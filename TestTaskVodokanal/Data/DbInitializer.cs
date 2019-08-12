using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskVodokanal.Models;

namespace TestTaskVodokanal.Data
{
    /// <summary>
    /// Иницализация первичных данных
    /// </summary>
    public class DbInitializer
    {
        public static void Initialize(TestTaskVodokanalContext context)
        {

            // Если база не пустая заполнение данными не происходит
            if (context.Application.Any())
            {
                return;  
            }

            var application = new Application[]
            {
                new Application{Name = "Заявка 1", Description = "Описание завки 1", RegistrationDate = DateTime.Today, Status = Status.Open, }, 
                new Application{Name = "Заявка 2", Description = "Описание завки 2", RegistrationDate = DateTime.Today, Status = Status.Close, }, 
                new Application{Name = "Заявка 3", Description = "Описание завки 3", RegistrationDate = DateTime.Today, Status = Status.Completed, }, 
                new Application{Name = "Заявка 4", Description = "Описание завки 4", RegistrationDate = DateTime.Today, Status = Status.Return, }, 
            };

            foreach (var item in application)
            {
                context.Application.Add(item);
            }
            context.SaveChanges();

            var history = new History[]
            {
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 1").ApplicationID, Status=Status.Open, Comment = "Статус заявки 1 открыт", RegistrationDate = DateTime.Today },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 1").ApplicationID, Status=Status.Close, Comment = "Статус заявки 1 закрыт", RegistrationDate = DateTime.Today },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 2").ApplicationID, Status=Status.Open, Comment = "Статус заявки 2 открыт", RegistrationDate = DateTime.Today },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 2").ApplicationID, Status=Status.Close, Comment = "Статус заявки 2 закрыт", RegistrationDate = DateTime.Today },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 3").ApplicationID, Status=Status.Open, Comment = "Статус заявки 3 открыт", RegistrationDate = DateTime.Today },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 3").ApplicationID, Status=Status.Close, Comment = "Статус заявки 3 закрыт", RegistrationDate = DateTime.Today },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 4").ApplicationID, Status=Status.Open, Comment = "Статус заявки 4 открыт", RegistrationDate = DateTime.Today },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 4").ApplicationID, Status=Status.Close, Comment = "Статус заявки 4 закрыт", RegistrationDate = DateTime.Today },
            };

            foreach (var item in history)
            {
                context.History.Add(item);
            }
            context.SaveChanges();

        }
    }
}
