using Avalonia;
using CityEvents.Models;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

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
            events = Serializer<CityEvent[]>.Load("../../../../data.xml");


            sourceList = new SourceList<CityEvent>();

            foreach (CityEvent c in events)
            {
                sourceList.Add(c);
            }

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
