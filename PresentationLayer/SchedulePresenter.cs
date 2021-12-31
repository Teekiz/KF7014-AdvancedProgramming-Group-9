using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    public class SchedulePresenter
    {
        private IScheduleModel model;
        private ISchedule screen;

        public SchedulePresenter(ISchedule screen, IScheduleModel model)
        {
            this.screen = screen;
            this.model = model;
            screen.register(this);
            loadScreenData();
        }

        public void loadScreenData()
        {
            foreach (Order order in model.GetAllOrdersWithinTwoMonths())
            { 
                //screen.scheduleBox = 
            }
        }

    }
}
