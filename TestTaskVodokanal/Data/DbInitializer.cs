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
                new Application{Name = "Заявка 1", Description = "Описание завки 1", RegistrationDate = new DateTime(2019, 8, 10), Status = Status.Open, }, 
                new Application{Name = "Заявка 2", Description = "Описание завки 2", RegistrationDate = new DateTime(2019, 8, 11), Status = Status.Close, }, 
                new Application{Name = "Заявка 3", Description = "Описание завки 3", RegistrationDate = new DateTime(2019, 8, 12), Status = Status.Completed, }, 
                new Application{Name = "Заявка 4", Description = "Описание завки 4", RegistrationDate = new DateTime(2019, 8, 13), Status = Status.Return, }, 
                new Application{Name = "Заявка 5", Description = "Описание завки 5", RegistrationDate = new DateTime(2019, 8, 14), Status = Status.Return, }, 
                new Application{Name = "Заявка 6", Description = "Описание завки 6", RegistrationDate = new DateTime(2019, 8, 15), Status = Status.Return, }, 
            };

            foreach (var item in application)
            {
                context.Application.Add(item);
            }
            context.SaveChanges();

            var history = new History[]
            {
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 1").ApplicationID, Status=Status.Open, Comment = "Статус заявки 1 открыт", RegistrationDate = new DateTime(2019, 8, 10) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 1").ApplicationID, Status=Status.Completed, Comment = "Статус заявки 1 решена", RegistrationDate = new DateTime(2019, 8, 10) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 2").ApplicationID, Status=Status.Open, Comment = "Статус заявки 2 открыт", RegistrationDate = new DateTime(2019, 8, 11) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 2").ApplicationID, Status=Status.Completed, Comment = "Статус заявки 2 решена", RegistrationDate = new DateTime(2019, 8, 11) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 3").ApplicationID, Status=Status.Open, Comment = "Статус заявки 3 открыт", RegistrationDate = new DateTime(2019, 8, 12) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 3").ApplicationID, Status=Status.Completed, Comment = "Статус заявки 3 решена", RegistrationDate = new DateTime(2019, 8, 12) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 4").ApplicationID, Status=Status.Open, Comment = "Статус заявки 4 открыт", RegistrationDate = new DateTime(2019, 8, 13) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 4").ApplicationID, Status=Status.Completed, Comment = "Статус заявки 4 решена", RegistrationDate = new DateTime(2019, 8, 13) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 5").ApplicationID, Status=Status.Open, Comment = "Статус заявки 5 открыт", RegistrationDate = new DateTime(2019, 8, 14) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 5").ApplicationID, Status=Status.Completed, Comment = "Статус заявки 5 решена", RegistrationDate = new DateTime(2019, 8, 14) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 6").ApplicationID, Status=Status.Open, Comment = "Статус заявки 6 открыт", RegistrationDate = new DateTime(2019, 8, 15) },
                new History() {ApplicationId = application.Single(s => s.Name == "Заявка 6").ApplicationID, Status=Status.Completed, Comment = "Статус заявки 6 решена", RegistrationDate = new DateTime(2019, 8, 15) },
            };

            foreach (var item in history)
            {
                context.History.Add(item);
            }
            context.SaveChanges();

        }
    }
}
