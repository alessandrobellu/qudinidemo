using Newtonsoft.Json;
using QudiniDemo.Helpers;
using QudiniDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.Web.Http;

namespace QudiniDemo.ViewModels
{
    public enum MainPageStates { Idle, Loading }

    public class MainViewModel : ViewModelBase
    {
        private const int SECONDS_SPAN = 30;
        private readonly HttpManager httpManager;
        private readonly DispatcherTimer timer;

        public MainViewModel()
        {
            httpManager = new HttpManager("codetest1", "codetest100");

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(SECONDS_SPAN);
        }

        private async void Timer_Tick(object sender, object e)
        {
            if (ReloadCommand.CanExecute(null))
                await ReloadCommand.Execute(null);
        }

        public async Task InitAsync()
        {
            await Reload(true);

            if (!timer.IsEnabled) timer.Start();
        }

        ~MainViewModel()
        {
            if (timer.IsEnabled) timer.Stop();
        }

        public AsyncCommand ReloadCommand
        {
            get { return reloadCommand = reloadCommand ?? new AsyncCommand(x => Reload(), x => !IsBusy); }
        }
        private AsyncCommand reloadCommand;
        private async Task Reload(bool init = false)
        {
            if (timer.IsEnabled) timer.Stop();

            if (!init)
            {
                State = MainPageStates.Loading;
                IsBusy = true;
            }

            Uri requestUri = new Uri("https://app.qudini.com/api/queue/gj9fs");

            ResponseModel response = await httpManager.GetObjectAsync<ResponseModel>(requestUri);

            if (response != null && response.QueueData != null)
            {
                Queue = response.QueueData.Queue;
            }

            State = MainPageStates.Idle;
            IsBusy = false;
            if (!timer.IsEnabled) timer.Start();
        }


        #region Properties
        public Queue Queue
        {
            get { return queue; }
            set { queue = value; OnPropertyChanged(); }
        }
        private Queue queue;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }
        private bool isBusy = true;

        public string BindState
        {
            get { return State.ToString(); }
        }
        private MainPageStates State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("BindState"); }
        }
        private MainPageStates state = MainPageStates.Loading;
        #endregion
    }
}
