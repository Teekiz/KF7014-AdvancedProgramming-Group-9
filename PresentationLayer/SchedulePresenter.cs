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
        Order order;

        public SchedulePresenter(ISchedule screen, IScheduleModel model)
        {
            this.screen = screen;
            this.model = model;
            screen.register(this);
            loadScreenData();
        }

        public void loadScreenData()
        {
            foreach (Order order in model.GetAllOrdersWithinTwoMonths().OrderBy(o=>o.scheduledStartDate))
            {
                string onTarget = "";
                if (model.OnTarget(order) == true) { onTarget = "Yes"; }
                else { onTarget = "No"; }
                screen.populateScheduleDataGrid(order, model.GetEnquiryFromOrder(order), model.GetOrderItemsFromOrder(order).Count(), onTarget);
            }
            screen.changeDGVColour();
        }

        public void rowSelected(int id)
        {
            //loading a new screen
            order = model.GetOrder(id);
            model.GetEnquiryFromOrder(order);
            model.GetOrderItemsFromOrder(order);

            IEnquiryGateway enquiryGateway = EnquiryGateway.Instance;
            IOrderItemGateway orderItemGateway = OrderItemGateway.Instance;
            ICustomerGateway customerGateway = CustomerGateway.Instance;
            IOrderGateway orderGateway = OrderGateway.Instance;

            ScheduleOrderScreen newscreen = new ScheduleOrderScreen();
            IScheduleModel newModel = new ScheduleModel(orderGateway, enquiryGateway, orderItemGateway);
            ScheduleOrderScreenPresenter presentation = new ScheduleOrderScreenPresenter(newscreen, newModel, order, model.GetEnquiryFromOrder(order), model.GetOrderItemsFromOrder(order));
            newscreen.ShowDialog();
        }
    }
}
