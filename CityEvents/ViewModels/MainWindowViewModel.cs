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
                new CityEvent{Header = "��������� (�����)", Image = "Assets/pic/cheburashka.jpg", Category = new CategoryItem{ForChildren = true, Show=true}, Date = "29/02/2023 18:00", Price=300, Description="������, ����� ������� ������ � ������ � ��� ��������, ����� ���� ��������� ������� �����. ��������� ������������� ������� �� ������� ������������ ������ ���� ������������ ����������� � ����� ���������� �������, ��� ��� ��������� ����� ���� ���, ������ � ���. �������� � � ������! � ��� � ���� ����� ��������� ������-��������, �������� ����-������� � �� ��������� ������, �������, ������� ����� �� ������ ��������, � ��� ����, ������� ���������� ��������, ���� ��� � ����� ����� ������� �� ����� �������. � ������-������ ������, � ��� ����� ������ � �������� ���������� ���-��� �������� ���������� � �����������."},
                new CityEvent{Header = "�������", Image = "Assets/pic/zoo.jpg", Category = new CategoryItem{ ForChildren = true, Culture = true, Excursions = true}, Date = "��������� � 10:00 �� 19:00", Price=150, Description="���� �� ���������� ��������� ������. �������� ������� 65 ��, � �� ���������� ����� 11 000 ������ 770 �����. ����� 350 ����� �������� � ������������� ������� �����. ����� 180 ����� ������� � ������� ����� ������ � ������������ ������� �����."},
                new CityEvent{Header = "��������� '����� �������'", Image = "Assets/pic/blue_tractor.jpg", Category = new CategoryItem{ForChildren = true, Show = true }, Date = "11/04/2023 11:00", Price = 800, Description="����������� ����������� ��� �������� ����� ������� ��������. ��� ���� ����� ������ �������. � ��� �� ����� � ��� ������ ��� �� ����� ���� ������, �������� ������������-�����, ������ �������������� �����, ������� � ������������� ��������� ��� �����."},
                new CityEvent{Header = "���� ����� �������", Image = "Assets/pic/galileo.jpg", Category = new CategoryItem{ForChildren = true, Culture = true, Education = true}, Date = "��������� � 10:00 �� 20:00", Price=1200, Description="����� ���������� � ����� �� ����������, �� �� ������ ������ ����� ������� ������ ���� ����. ������� ����� �������� �� ����� - 1 ���." },
                new CityEvent{Header = "���� �������� � ������\n������������", Image = "Assets/pic/park.jpg", Category = new CategoryItem{ForChildren = true, Culture = true, Lifestyle = true}, Date = "���������", Description="���� ��� ������ ���� ������" },
                new CityEvent{Header = "����� ������", Image = "Assets/pic/race_of_heroes.jpg", Category = new CategoryItem{Sport = true, Lifestyle = true }, Date = "09/09/2023 10:00", Price = 3000, Description = "����� ������ - ��� ������ ����� � ������������� � ����� ������! ��������� ����������� ��� ������� - �� ��������� ���� ���� � ��������, ��� ��� ���� ��� ������ ������������."},
                new CityEvent{Header = "������ - ������������", Image = "Assets/pic/sibir.jpg", Category = new CategoryItem{Sport = true, Show = true }, Date = "26/02/2023 16:30", Price=5000, Description = "��������� ���� ������ - ������������" },
                new CityEvent{Header = "������", Image = "Assets/pic/next.jpg", Category = new CategoryItem{Culture = true, Show = true}, Date = "14/03/2023 19:00", Price = 500, Description = "������ ��������� � ���-�������, ��������� �� ����������� ����������� ��������, ����������� ��������� � �������� � �������������� ��������� ����� � ������� ���������� ������� � ������ ���������. ����� ���� � ���������� ���������, ������-��������, ���, ����������, ���������, ��������, ����������, �������� � ������ �����������, � � ����� ����� ������� � �����, ���������, � ������������, ������������� ���������."},
                new CityEvent{Header = "��������� �����������\n����������� � �����������\n������", Image = "Assets/pic/excurs.jpg", Category = new CategoryItem{Education = true, Culture = true, Excursions = true }, Date = "31/03/2023 16:00", Price=300, Description="������������� ����������� ����� ���������� ���� �������� ��������� ����������� �� ������������ ������ � �������� ����� ����������� �����������. ������� ��������� ������� ������ ����������� ���, �����, ��������� ������������� ���������, ��������, � ������� � ���������������� ���� ������." },
                new CityEvent{Header = "�������� ��������!\n��������! 18+", Image = "Assets/pic/podzemka.jpg", Category=new CategoryItem{Lifestyle=true, Party = true, Show = true }, Date = "07/03/2023", Price=400, Description="� ���������:\n� FREAK & DANCE SHOW;\n� DJ'S; MC; ����; �����;\n� ����������� ���� � ����\n� ������ �� ������ ������, �� � ����, � ������� ������ � ����!" },
                new CityEvent{Header = "����� 90-�", Image = "Assets/pic/disko.jpg", Category = new CategoryItem{Lifestyle = true, Party = true}, Date = "25/05/2023", Price=500, Description="����� ��������� ���������� ������ ������ 90-�� ������������ ������ �� ������� ��������� ����� 90-� � 2000-� �����. ���� �� ������� ����������� ������� ���������� ������� ��������� � 2017 ���� � ���������� ��� ������� �� ������." },
                new CityEvent{Header = "������-���������� ���-���\n\"��� ��� �����������\"", Image = "Assets/pic/super.jpg", Category=new CategoryItem{Education = true, Online = true, Show = true },Date = "10/04/2023 12:00" , Price = 150, Description = "���������� � �������, ���� ����������, ���������� �������� �������� � ������� �������-������� ���������� ����� ������� �����. ��� ������������� ������������ ���� �� �������� ��������� ����, � ����� ������ ����� � ������� �� �������� �������. ������� �� �� � ��������� ������� �������? �������������� ������ �� ������� ������� (����) ����������� � ������������ ���������� ����� �����."},
                new CityEvent{Header = "��������������� ������\n\"������ ����\"", Image = "Assets/pic/lek.jpg", Category=new CategoryItem{Education = true, Online = true}, Date = "28/03/2023 17:00", Description = "������ ��������� ���� ����������� �������� ���������� ���������!"},
                new CityEvent{Header = "������ ���� � �� � ���������", Image = "Assets/pic/efir.jpg", Category = new CategoryItem{Online = true}, Date="14/02/2023 23:00", Description="�� ������ ������� ���� ������ ������������ � ���, ���� � ������� ����� �������. ���������� ��������� ���������, ���� � � ����� ����� ���������� ����� �����, � ����� ���� ����������, ��� ��������� �� ���������. �� ������� ������ ������������ ��� ������� ������� � ������ �����." },
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
