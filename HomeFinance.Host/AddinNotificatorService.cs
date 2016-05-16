using System;
using System.Timers;
using HomeFinance.Contract;

namespace HomeFinance.Host
{
    public class AddinNotificatorService : IAddinNotificatorService
    {
        private Timer timer;
        public AddinNotificatorService()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        public IResult<bool> UpdateAccount()
        {
            throw new NotImplementedException();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateAccount();
        }
    }
}
