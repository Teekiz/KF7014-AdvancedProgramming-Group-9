﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer;
using DataAccessLayer;

//Developed by Lewis Barton
//GUI to allow a manager to change aspects of an enquiry such as the price and amount of hours needed.
//Allows a manager to accept or decline an order.
//Data handling performed by ManagerPresenter.

namespace PresentationLayer
{
    public interface IOrderManager
    {
     
        string orderNumber { set; get; }
        DateTime DateReceived { set; get; }
        string customerName { set; get; }
        string custPhone { set; get; }
        string custAddressline1 { set; get; }
        string custAddressline2 { set; get; }
        string custCountry { set; get; }
        string custType { set; get; }
        string price { set; get; }
        string timeHours { set; get; }
        DateTime deadline { set; get; }
        DateTime confirmedDeadline { set; get; }
        string orderNotes { get; set; }
        string custOrderNotes { get; set; }
        DateTime startDate { get; set; }
        void orderItemListView(List<String> orderItems);
        bool acceptOrderRadioButton();
        void clearItemView();
        void register(ManagerPresenter psr);
    }
    //Return values of customer enquiry if order number is found (functions through ManagerPresenter).
    public partial class OrderManager : Form, IOrderManager
    {
        private ManagerPresenter presenter;

        public OrderManager()
        {
            InitializeComponent();
        }

        public string orderNumber
        {
            get { return cmbOrderNumber.SelectedItem.ToString(); }
            set { cmbOrderNumber.Items.Add(value); }
        }
        public DateTime DateReceived 
        {
            get { return OFMdateF.Value; }
            set { OFMdateF.Value = value; }
        }
        public string customerName 
        {
            get { return OFNnameF.Text; }
            set { OFNnameF.Text = value; }
        }
        public string custPhone 
        {
            get { return OFMphoneF.Text; }
            set { OFMphoneF.Text = value; }
        }
        public string custAddressline1
        {
            get { return OFMaddr1F.Text; }
            set { OFMaddr1F.Text = value; }
        }
        public string custAddressline2
        {
            get { return OFMaddr2F.Text; }
            set { OFMaddr2F.Text = value; }
        }
        public string custCountry
        {
            get { return OFMcountyF.Text; }
            set { OFMcountyF.Text = value; }
        }
        public string custType
        {
            get { return txtCustomerType.Text; }
            set { txtCustomerType.Text = value; }
        }
        public string price
        {
            get { return txtPriceActual.Text; }
            set { txtPriceActual.Text = value; }
        }
        public string timeHours
        {
            get { return txtOFTime.Text; }
            set { txtOFTime.Text = value; }
        }
        public DateTime deadline 
        {
            get { return OFMrttcF.Value; }
            set { OFMrttcF.Value = value; }

        }
        public DateTime confirmedDeadline
        {
            get { return dtpMendDate.Value; }
            set { dtpMendDate.Value = value; }
        }
        public string orderNotes
        {
            get { return OFMmordernotesF.Text; }
            set { OFMmordernotesF.Text = value; }
        }

        public string custOrderNotes 
        {
            get { return OFMcnF.Text; }
            set { OFMcnF.Text = value; }
        }
        public DateTime startDate
        {
            get { return dtpMstartDate.Value; }
            set { dtpMstartDate.Value = value; }
        }
        public bool acceptOrderRadioButton()
        {
            if (OFMaoY.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void clearItemView()
        {
            lstBoxItems.Items.Clear();
        }
        public void orderItemListView(List<String> orderItems)
        {
            foreach (string item in orderItems)
            {
                lstBoxItems.Items.Add(item);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label18_Click(object sender, EventArgs e)
        {

        }
        public void register(ManagerPresenter psr)
        {
            presenter = psr;
        }
        private void txtOMOrderNumber_Leave(object sender, EventArgs e)
        {
            presenter.EnquiryUpdate();
        }
        //Save changes made to the enquiry.
        private void OFMsubmit_Click(object sender, EventArgs e)
        {
            presenter.SaveUpdateEnquiry();
        }

        private void dtpMendDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void OFMrttcF_ValueChanged(object sender, EventArgs e)
        {
            this.OFMrttcF.Enabled = false;
        }

        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            presenter.openSchedule();
        }

        private void cmbOrderNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.EnquiryUpdate();
        }
    }
}
