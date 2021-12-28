using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    public class ManagerPresenter
    {
        private IManagerModel model;
        private IOrderManager screen;

        public ManagerPresenter(IManagerModel screen, IManagerModel model)
        {
            this.screen = screen;
            this.model = model;
            screen.register(this);
        }

        public void GetEnquiry()
        {
            //id
            model.GetEnquiry();
        }

        public void UpdateEnquiry()
        {
            Enquiry enquiry
            model.UpdateEnquiry();
        }
    }
}
