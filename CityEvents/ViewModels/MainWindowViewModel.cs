using Avalonia;
using CityEvents.Models;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;

namespace CityEvents.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CityEvent cItem;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems2;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems3;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems4;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems5;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems6;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems7;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems8;
        private readonly ReadOnlyObservableCollection<CityEvent> cItems9;
        private SourceList<CityEvent> sourceList;
        private CityEvent[] events;

        public MainWindowViewModel()
        {
            events = new CityEvent[]
            {
                new CityEvent{Header = "Чебурашка (фильм)", Image = "Assets/pic/cheburashka.jpg", Category = new CategoryItem{ForChildren = true, Show=true}, Date = "29/02/2023 18:00", Price=300, Description="Иногда, чтобы вернуть солнце и улыбки в мир взрослых, нужен один маленький ушастый герой. Мохнатого непоседливого зверька из далекой апельсиновой страны ждут удивительные приключения в тихом приморском городке, где ему предстоит найти себе имя, друзей и дом. Помогать — и мешать! — ему в этом будут нелюдимый старик-садовник, странная тетя-модница и ее капризная внучка, мальчик, который никак не начнет говорить, и его мама, которой приходится несладко, хотя она и варит самый вкусный на свете шоколад. И многие-многие другие, в чью жизнь вместе с ароматом апельсинов вот-вот ворвутся волшебство и приключения."},
                new CityEvent{Header = "Зоопарк", Image = "Assets/pic/zoo.jpg", Category = new CategoryItem{ ForChildren = true, Culture = true, Excursions = true}, Date = "Ежедневно с 10:00 до 19:00", Price=150, Description="Один из крупнейших зоопарков России. Занимает площадь 65 га, в нём содержится около 11 000 особей 770 видов. Более 350 видов занесены в Международную красную книгу. Около 180 видов внесено в Красную книгу России и Региональные Красные Книги."},
                new CityEvent{Header = "Спектакль 'Синий трактор'", Image = "Assets/pic/blue_tractor.jpg", Category = new CategoryItem{ForChildren = true, Show = true }, Date = "11/04/2023 11:00", Price = 800, Description="Развивающее музыкальное шоу песенных хитов «Синего Трактора». Все дети любят «Синий трактор». А кто не любит – тот просто ещё не видел этих добрых, забавных мультфильмов-песен, полных запоминающихся шуток, которые с удовольствием повторяет вся семья."},
                new CityEvent{Header = "Парк чудес Галилео", Image = "Assets/pic/galileo.jpg", Category = new CategoryItem{ForChildren = true, Culture = true, Education = true}, Date = "Ежедневно с 10:00 до 20:00", Price=1200, Description="Время нахождения в Парке не ограничено, но по одному билету можно сделать только один круг. Среднее время прогулки по Парку - 1 час." },
                new CityEvent{Header = "Парк культуры и отдыха\nЗаельцовский", Image = "Assets/pic/park.jpg", Category = new CategoryItem{ForChildren = true, Culture = true, Lifestyle = true}, Date = "Ежедневно", Description="Парк для отдыха всей семьей" },
                new CityEvent{Header = "Гонка героев", Image = "Assets/pic/race_of_heroes.jpg", Category = new CategoryItem{Sport = true, Lifestyle = true }, Date = "09/09/2023 10:00", Price = 3000, Description = "Гонка Героев - это крутой забег с препятствиями в твоем городе! Драйвовое приключение для каждого - ты испытаешь свои силы и поверишь, что для тебя нет ничего невозможного."},
                new CityEvent{Header = "Сибирь - Автомобилист", Image = "Assets/pic/sibir.jpg", Category = new CategoryItem{Sport = true, Show = true }, Date = "26/02/2023 16:30", Price=5000, Description = "Хоккейный матч Сибирь - Автомобилист" },
                new CityEvent{Header = "Дальше", Image = "Assets/pic/next.jpg", Category = new CategoryItem{Culture = true, Show = true}, Date = "14/03/2023 19:00", Price = 500, Description = "Формат спектакля — рок-концерт, состоящий из современных музыкальных отрывков, атмосферных монологов и диалогов с использованием авторских песен и текстов участников проекта и бывших студийцев. Живой звук — барабанная установка, гитары-акустика, бас, синтезатор, аккордеон, мелодика, виолончель, ксилофон и другие инструменты, — а также вокал создают и яркую, драйвовую, и трогательную, доверительную атмосферу."},
                new CityEvent{Header = "Экскурсия театральных\nвпечатлений в Музыкальном\nтеатре", Image = "Assets/pic/excurs.jpg", Category = new CategoryItem{Education = true, Culture = true, Excursions = true }, Date = "31/03/2023 16:00", Price=300, Description="Новосибирский музыкальный театр приглашает всех желающих совершить путешествие по театральному зданию и получить новые театральные впечатления. Ведущие экскурсии покажут гостям театральный зал, сцену, служебные артистические помещения, гримерки, а главное — производственные цеха театра." },
                new CityEvent{Header = "КОРОЛЕВА ТАНЦПОЛА!\nПОДЗЕМКА! 18+", Image = "Assets/pic/podzemka.jpg", Category=new CategoryItem{Lifestyle=true, Party = true, Show = true }, Date = "07/03/2023", Price=400, Description="В программе:\n• FREAK & DANCE SHOW;\n• DJ'S; MC; ФОТО; ВИДЕО;\n• СПЕЦИАЛЬНОЕ МЕНЮ В БАРЕ\n• ДИДЖЕИ НЕ ТОЛЬКО ИГРАЮТ, НО И ПЬЮТ, И ТАНЦУЮТ ВМЕСТЕ С ВАМИ!" },
                new CityEvent{Header = "Диско 90-х", Image = "Assets/pic/disko.jpg", Category = new CategoryItem{Lifestyle = true, Party = true}, Date = "25/05/2023", Price=500, Description="Супер фестиваль популярной музыки «Диско 90-х» представляет лучшее из золотой коллекции хитов 90-х и 2000-х годов. Одно из главных музыкальных событий собирающее аншлаги стартовал в 2017 году и продолжает своё шествие по стране." },
                new CityEvent{Header = "Научно-популярное ток-шоу\n\"Суд над Супергероем\"", Image = "Assets/pic/super.jpg", Category=new CategoryItem{Education = true, Online = true, Show = true },Date = "10/04/2023 12:00" , Price = 150, Description = "Преступник в прошлом, ныне супергерой, популярный персонаж комиксов и фильмов Человек-муравей предстанет перед научным судом. При использовании специального газа он способен уменьшить себя, а также других людей и объекты до размеров муравья. Виновен ли он в нарушении законов природы? Информационные центры по атомной энергии (ИЦАЭ) Красноярска и Новосибирска приглашают найти ответ."},
                new CityEvent{Header = "Диагностическая сессия\n\"Личная Сила\"", Image = "Assets/pic/lek.jpg", Category=new CategoryItem{Education = true, Online = true}, Date = "28/03/2023 17:00", Description = "Получи пошаговый план личностного развития совершенно бесплатно!"},
                new CityEvent{Header = "Прямой эфир в ВК с Пермьстат", Image = "Assets/pic/efir.jpg", Category = new CategoryItem{Online = true}, Date="14/02/2023 23:00", Description="По итогам каждого года юрлица отчитываются о том, куда и сколько денег вложили. Специалист Пермьстат расскажет, кому и в какие сроки необходимо сдать отчет, а также даст инструкцию, как правильно ее заполнять. Вы сможете задать интересующие вас вопросы спикеру в прямом эфире." },
            };


            sourceList = new SourceList<CityEvent>();

            foreach (CityEvent c in events)
            {
                sourceList.Add(c);
            }


            Serializer<CityEvent[]>.Save("../../../../data.xml", events);

            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.ForChildren == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Sport == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems2).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Culture == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems3).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Excursions == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems4).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Lifestyle == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems5).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Party == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems6).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Education == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems7).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Online == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems8).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category.Show == true).ObserveOn(RxApp.MainThreadScheduler).Bind(out cItems9).Subscribe();
        }

        public ReadOnlyObservableCollection<CityEvent> CItems => cItems;
        public ReadOnlyObservableCollection<CityEvent> CItems2 => cItems2;
        public ReadOnlyObservableCollection<CityEvent> CItems3 => cItems3;
        public ReadOnlyObservableCollection<CityEvent> CItems4 => cItems4;
        public ReadOnlyObservableCollection<CityEvent> CItems5 => cItems5;
        public ReadOnlyObservableCollection<CityEvent> CItems6 => cItems6;
        public ReadOnlyObservableCollection<CityEvent> CItems7 => cItems7;
        public ReadOnlyObservableCollection<CityEvent> CItems8 => cItems8;
        public ReadOnlyObservableCollection<CityEvent> CItems9 => cItems9;
    }
}
