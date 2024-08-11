using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ServeAll.Configuration;
using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;

namespace ServeAll.MainForm
{
    public partial class FrmCustomers : Form
    {
        private  bool _add, _edt, _del, _cus, _typ, _crd;
        private int contact_Id = 0;
        private int address_id = 0;
        private int customerType_Id = 0;
        public FrmMain Main { get; set; }
        public FrmCustomers()
        {
            InitializeComponent();
        }
        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            BindCustomerList();
            _cus = true;
            _typ = false;
            _crd = false;
        }
        private void FrmCustomers_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }
        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }
        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }
        private void bntADD_Click(object sender, EventArgs e)
        {
            ButAdd();
        }
        private void bntUPD_Click(object sender, EventArgs e)
        {
            ButUpd();
        }
        private void bntSAV_Click(object sender, EventArgs e)
        {
            ButSav();
        }
        private void bntCLR_Click(object sender, EventArgs e)
        {
            ButClr();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
        }
        private void bntDEL_Click(object sender, EventArgs e)
        {
            InputWhit();
            if (_crd && _cus == false && _typ == false)
            {
                var que = PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Customer Credit: " + txtCUS.Text.Trim(' ') + " " + "?", "CREDIT Details");
                if (que)
                {
                    ButDel();
                }
                else { ButCan(); }
            }
            if (_crd == false && _cus && _typ == false)
            {
                var que = PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Customer Name: " + txtNAM.Text.Trim(' ') + " " + "?", "CREDIT Details");
                if (que)
                {
                    ButDel();
                }
                else { ButCan(); }
            }

            if (_crd|| _cus|| !_typ) return;
            {
                var que = PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Customer Type: " + txtDET.Text.Trim(' ') + " " + "?", "CREDIT Details");
                if (que)
                {
                    ButDel();
                }
                else { ButCan(); }
            }
        }
        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if (que <= 0) return;
            var log = new FrmLogin();
            log.Show();
            Close();
        }
        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();}
        private void ButtonAdd()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = false;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonUpd()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = true;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonDel()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = false;
            bntDEL.Enabled = true;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonSav()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonClr()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = false;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonCan()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        //INPUT MANIPULATION
        private void InputWhit()
        {
            txtCity.BackColor = Color.White;
            txtBarangay.BackColor = Color.White;
            txtCustomerId.BackColor = Color.White;
            txtCOD.BackColor = Color.White;
            txtNAM.BackColor = Color.White;
            cmbGEN.BackColor = Color.White;
            txtEML.BackColor = Color.White;
            txtPON.BackColor = Color.White;
            txtMOB.BackColor = Color.White;
            txtFAX.BackColor = Color.White;
            txtStreet.BackColor = Color.White;
            cmbPRV.BackColor = Color.White;
            txtZIP.BackColor = Color.White;
            cmbCustomerType.BackColor = Color.White;
            dkpREG.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtCity.Enabled = true;
            txtBarangay.Enabled = true;
            txtCustomerId.Enabled = true;
            txtCOD.Enabled = true;
            txtNAM.Enabled = true;
            cmbGEN.Enabled = true;
            txtEML.Enabled = true;
            txtPON.Enabled = true;
            txtMOB.Enabled = true;
            txtFAX.Enabled = true;
            txtStreet.Enabled = true;
            cmbPRV.Enabled = true;
            txtZIP.Enabled = true;
            cmbCustomerType.Enabled = true;
            dkpREG.Enabled = true;
        }
        private void InputDisb() {
            txtCity.Enabled = false;
            txtBarangay.Enabled = false;
            txtCustomerId.Enabled = false;
            txtCOD.Enabled = false;
            txtNAM.Enabled = false;
            cmbGEN.Enabled = false;
            txtEML.Enabled = false;
            txtPON.Enabled = false;
            txtMOB.Enabled = false;
            txtFAX.Enabled = false;
            txtStreet.Enabled = false;
            cmbPRV.Enabled = false;
            txtZIP.Enabled = false;
            cmbCustomerType.Enabled = false;
            dkpREG.Enabled = false;
        }
        private void InputClea()
        {
            txtCity.Clear();
            txtBarangay.Clear();
            txtCustomerId.Clear();
            txtCOD.Clear();
            txtNAM.Clear();
            cmbGEN.Text = "";
            txtEML.Clear();
            txtPON.Clear();
            txtMOB.Clear();
            txtFAX.Clear();
            txtStreet.Clear();
            cmbPRV.Text = "";
            txtZIP.Clear();
            cmbCustomerType.Text = "";
            dkpREG.Value = DateTime.Now.Date;
        }
        private void InputDimG()
        {
            txtCity.BackColor = Color.DimGray;
            txtBarangay.BackColor = Color.DimGray;
            txtCustomerId.BackColor = Color.DimGray;
            txtCOD.BackColor = Color.DimGray;
            txtNAM.BackColor = Color.DimGray;
            cmbGEN.BackColor = Color.DimGray;
            txtEML.BackColor = Color.DimGray;
            txtPON.BackColor = Color.DimGray;
            txtMOB.BackColor = Color.DimGray;
            txtFAX.BackColor = Color.DimGray;
            txtStreet.BackColor = Color.DimGray;
            cmbPRV.BackColor = Color.DimGray;
            txtZIP.BackColor = Color.DimGray;
            cmbCustomerType.BackColor = Color.DimGray;
            dkpREG.BackColor = Color.DimGray;
        }
        //INPUT MANIPULATION TYPE
        private void InputWhity()
        {
            txtCTR.BackColor = Color.White;
            txtDET.BackColor = Color.White;
        }
        private void InputEnaby()
        {
            txtCTR.Enabled = true;
            txtDET.Enabled = true;
        }
        private void InputDisby()
        {
            txtCTR.Enabled = false;
            txtDET.Enabled = false;
        }
        private void InputCleay()
        {
            txtCTR.Clear();
            txtDET.Clear();
        }
        private void InputDimGy()
        {
            txtCTR.BackColor = Color.DimGray;
            txtDET.BackColor = Color.DimGray;
        }
        //INPUT MANIPULATION CREDIT
        private void InputWhitc()
        {
            txtRID.BackColor = Color.White;
            txtCUS.BackColor = Color.White;
            txtLIM.BackColor = Color.White;
            txtUSE.BackColor = Color.White;
            txtBAL.BackColor = Color.White;
            txtROD.BackColor = Color.White;

        }
        private void InputEnabc()
        {
            txtRID.Enabled = true;
            txtCUS.Enabled = true;
            txtLIM.Enabled = true;
            txtUSE.Enabled = true;
            txtBAL.Enabled = true;
            txtROD.Enabled = true;
        }
        private void InputDisbc()
        {
            txtRID.Enabled = false;
            txtCUS.Enabled = false;
            txtLIM.Enabled = false;
            txtUSE.Enabled = false;
            txtBAL.Enabled = false;
            txtROD.Enabled = false;
        }
        private void InputDimGc()
        {
            txtRID.BackColor = Color.DimGray;
            txtCUS.BackColor = Color.DimGray;
            txtLIM.BackColor = Color.DimGray;
            txtUSE.BackColor = Color.DimGray;
            txtBAL.BackColor = Color.DimGray;
            txtROD.BackColor = Color.DimGray;
        }
        private void InputCleac()
        {
            txtRID.Clear();
            txtCUS.Text = "";
            txtLIM.Text = @"0.00";
            txtUSE.Text = @"0.00";
            txtBAL.Text = @"0.00";
            txtROD.Clear();
            lblBAL.Text = @"00.00";
            lblUSE.Text = @"00.00";
        }
        //GENERATE ID 
        private static int getLastCustomerId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewCustomers>(unitWork);
                var result = (from b in repository.SelectAll(Query.getCustomerId)
                              orderby b.customer_id descending
                              select b.customer_id).Take(1).SingleOrDefault();
                if (result > 0)
                {
                    return result;
                }
                return 0;
            }
        }
        private static string GetCreditLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewCredit>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllCustomerCredit)
                              orderby b.id descending
                              select b.credit_code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }
        private void GenerateCode()
        {
            var alphaNumeric = new GenerateAlpaNum(3, 2, getLastCustomerId(), "CU");
            alphaNumeric.Increment();
            txtCOD.Text = alphaNumeric.ToString();
        }
        private void GenerateCreditCode()
        {
            var lastCode = GetCreditLastId();
            var lastId = ConfigSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "CU");
            alphaNumeric.Increment();
            txtROD.Text = alphaNumeric.ToString();
        }
        #region LeaveKeyDownInput  
        //STRING MANIPULATION
        private void txtCOD_Leave(object sender, EventArgs e)
        {
            if (_add || _edt)
            {
                InputManipulation.InputBoxLeave(txtCOD, txtNAM,
                "Customer Code",
                Messages.TitleCustomer);
            }
        }
        private void txtCOD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtCOD, txtNAM,
                "Customer Code",
                Messages.TitleCustomer);
            }
        }
        private void txtNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtNAM, cmbGEN,
                "Customer Name",
                Messages.TitleCustomer);
            }
        }
        private void cmbGEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbGEN, txtEML,
                "Customer Gender",
                Messages.TitleCustomer);
            }
        }
        private void txtEML_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtEML, txtPON,
                "Customer Email",
                Messages.TitleCustomer);
            }
        }
        private void txtPON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtPON, txtMOB,
                "Customer Phone",
                Messages.TitleCustomer);
            }
        }
        private void txtMOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtMOB, txtFAX,
                "Customer Mobile",
                Messages.TitleCustomer);
            }
        }
        private void txtFAX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtFAX, txtStreet,
                "Customer Fax Number",
                Messages.TitleCustomer);
            }
        }
        private void txtADD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtStreet, cmbPRV,
                "Customer Address",
                Messages.TitleCustomer);
            }
        }
        private void cmbPRV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbPRV, txtZIP,
                "Customer Provincial Address",
                Messages.TitleCustomer);
            }
        }
        private void txtZIP_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtZIP, cmbCustomerType,
                "Customer Zip Code",
                Messages.TitleCustomer);
            }
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpREG, bntSAV,
                "Date Register",
                Messages.TitleCustomer);
            }
        }

        #endregion
        #region ButtonCRUD
        private void ButAdd() {
            if (_cus && _typ == false && _crd == false)
            {
                ButtonAdd();
                InputEnab();
                InputWhit();
                InputClea();
                GenerateCode();
                BindCustomerType();
                txtNAM.Focus();
                _add = true;
                _edt = false;
                _del = false;
                gridCtlCustomer.Enabled = false;
            }
            if (_cus == false && _typ && _crd == false)
            {
                ButtonAdd();
                InputEnaby();
                InputWhity();
                InputCleay();
                txtDET.Focus();
                _add = true;
                _edt = false;
                _del = false;
                gridCtlType.Enabled = false;
            }

            if (_cus == false && _typ == false && _crd)
            {
                ButtonAdd();
                InputEnabc();
                InputWhitc();
                InputCleac();
                GenerateCreditCode();
                txtCUS.Focus();
                _add = true;
                _edt = false;
                _del = false;
                gridCtlCredit.Enabled = false;

                BindCustomerName();
            }
        }
        private void ButUpd()
        {
            if (_cus && _typ == false && _crd == false)
            {
                var customerId = txtCustomerId.Text.Trim(' ');
                address_id = getAddressId(int.Parse(customerId));
                contact_Id = getContactId(int.Parse(customerId));
                ButtonUpd();
                InputEnab();
                InputWhit();
                _add = false;
                _edt = true;
                _del = false;
                gridCtlCustomer.Enabled = false;
            }
            if (_cus == false && _typ && _crd == false)
            {
                ButtonUpd();
                InputEnaby();
                InputWhity();
                _add = false;
                _edt = true;
                _del = false;
                gridCtlType.Enabled = false;
            }
            if (_cus == false && _typ == false && _crd)
            {
                ButtonUpd();
                InputEnabc();
                InputWhitc();
                _add = false;
                _edt = true;
                _del = false;
                gridCtlCredit.Enabled = false;
            }


        }
        private void ButDel()
        {
            if (_cus && _typ == false && _crd == false)
            {
                ButtonDel();
                InputEnab();
                InputWhit();
                _add = false;
                _edt = false;
                _del = true;
                gridCtlCustomer.Enabled = false;
            }
            if (_cus == false && _typ && _crd == false)
            {
                ButtonDel();
                InputEnaby();
                InputWhity();
                _add = false;
                _edt = false;
                _del = true;
                gridCtlType.Enabled = false;
            }
            if (_cus == false && _typ == false && _crd)
            {
                ButtonDel();
                InputEnabc();
                InputWhitc();
                _add = false;
                _edt = false;
                _del = true;
                gridCtlCredit.Enabled = false;
            }
        }
        private void ButClr()
        {
            if(_cus && _typ == false && _crd == false)
            {
                ButtonClr();
                InputEnab();
                InputWhit();
                InputClea();
                gridCtlCustomer.Enabled = true;
                cmbCustomerType.DataBindings.Clear();
            }
            if (_cus == false && _typ && _crd == false)
            {
                ButtonClr();
                InputEnaby();
                InputWhity();
                InputCleay();
                gridCtlType.Enabled = true;
            }
            if (_cus == false && _typ == false && _crd )
            {
                ButtonClr();
                InputEnabc();
                InputWhitc();
                InputCleac();
                gridCtlCredit.Enabled = true;
            }


        }
        private void ButCan()
        {
            if (_cus && _typ == false && _crd == false)
            {
                ButtonCan();
                InputDisb();
                InputDimG();
                InputClea();
                gridCtlCustomer.Enabled = true;
                cmbCustomerType.DataBindings.Clear();
            }
            if (_cus == false && _typ && _crd == false)
            {
                ButtonCan();
                InputDisby();
                InputDimGy();
                InputCleay();
                gridCtlType.Enabled = true;
            }
            if (_cus == false && _typ == false && _crd)
            {
                ButtonCan();
                InputDisbc();
                InputDimGc();
                InputCleac();
                gridCtlCredit.Enabled = true;
            }

        }
        private void ButSav() {
            if (_cus && _typ == false && _crd == false)
            {
                SavCus();
            }
            if (_cus == false && _typ && _crd == false)
            {
                SavTyp();
            }
            if (_cus == false && _typ == false && _crd)
            {
                SavCrt();
            }
        }
        private void SavCus() {
            if (_add && _edt == false && _del == false)
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindCustomerList();
            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindCustomerList();
            }
            if (_add == false && _edt == false && _del)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindCustomerList();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridCtlCustomer.Enabled = true;
            gridCtlType.Enabled = false;
            gridCtlCredit.Enabled = false;
            _cus = true;
            _typ = false;
            _crd = false;
            cmbCustomerType.DataBindings.Clear();
        }
        private void SavTyp()
        {
            if (_add && _edt == false && _del == false)
            {
                DataInserty();
                ButtonSav();
                InputDisby();
                InputDimGy();
                InputCleay();
                BindTypeList();
            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdatey();
                ButtonSav();
                InputDisby();
                InputDimGy();
                InputCleay();
                BindTypeList();
            }
            if (_add == false && _edt == false && _del)
            {
                DataDeletey();
                ButtonSav();
                InputDisby();
                InputDimGy();
                InputCleay();
                BindTypeList();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridCtlCustomer.Enabled = false;
            gridCtlType.Enabled = true;
            gridCtlCredit.Enabled = false;
            _cus = false;
            _crd = false;
            _typ = true;
        }
        private void SavCrt() {
            if (_add && _edt == false && _del == false)
            {
                DataInsertc();
                ButtonSav();
                InputDisbc();
                InputDimGc();
                InputCleac();
                BindCreditList(); 
            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdatec();
                ButtonSav();
                InputDisbc();
                InputDimGc();
                //InputCleac();
                BindCreditList();
            }
            if (_add == false && _edt == false && _del)
            {
                DataDeletec();
                ButtonSav();
                InputDisbc();
                InputDimGc();
                InputCleac();
                BindCreditList();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridCtlCustomer.Enabled = false;
            gridCtlType.Enabled = false;
            gridCtlCredit.Enabled = true;
            _cus = false;
            _crd = true;
            _typ = false;
        }
      
        #endregion
        #region DataCRUD
        private void BindCustomerList()
        {
            gridCtlCustomer.Update();
            try
            {
                gridCtlCustomer.DataBindings.Clear();
                gridCtlCustomer.DataSource = RebindCustomer().Select(p => new
                {
                    Id = p.customer_id,
                    Code = p.customer_code,
                    Name = p.customer_name,
                    Gender = p.gender,
                    EmailAddress = p.email_address,
                    TelephoneNo = p.telephone_number,
                    MobileNo = p.mobile_number,
                    FaxNo = p.fax_number,
                    Barangay = p.barangay,
                    Street = p.street,
                    Province = p.province,
                    City = p.city,
                    ZipCode = p.zip_code,
                    ClientType = p.client_type,
                    Reg = p.date_register
                }); ;
            }
            catch (Exception ex)
            {
                gridCtlCustomer.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableCustomer);
            }
        }
        private void BindTypeList()
        {
            gridCtlType.Update();
            try
            {
                gridCtlType.DataBindings.Clear();
                gridCtlType.DataSource = RebindType();
            }
            catch (Exception ex)
            {
                gridCtlType.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableCustomer);
            }
        }
        private void BindCreditList()
        {
            gridCtlCredit.Update();
            try
            {
                gridCtlCredit.DataBindings.Clear();
                gridCtlCredit.DataSource = RebindCredit().Select(p => new
                {
                    Id = p.id,
                    Code = p.credit_code,
                    Name = p.name,
                    CreditLimit = p.credit_limit,
                    Used = p.credit_used,
                    Balance = p.balance,

                }); ;
            }
            catch (Exception ex)
            {
                gridCtlCredit.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableCredit);
            }
        }
        private IEnumerable<ViewCustomers> RebindCustomer()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewCustomers>(unWork);
                    return repository.SelectAll(Query.AllCustomers).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleCustomer);
                    throw;
                }
            }
        }
        private IEnumerable<CustomerType> RebindType()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<CustomerType>(unWork);
                    return repository.SelectAll(Query.AllCustomerType).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleCustomer);
                    throw;
                }
            }
        }
        private IEnumerable<ViewCredit> RebindCredit()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewCredit>(unWork);
                    return repository.SelectAll(Query.AllCustomerCredit).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleCustomer);
                    return null;
                }
            }
        }
        private void gridCustomers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridCustomers.RowCount > 0)
            {
                try
                {
                    txtCustomerId.Text = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    txtCOD.Text = ((GridView)sender).GetFocusedRowCellValue("Code").ToString();
                    txtNAM.Text = ((GridView)sender).GetFocusedRowCellValue("Name").ToString();
                    cmbGEN.Text = ((GridView)sender).GetFocusedRowCellValue("Gender").ToString();
                    txtEML.Text = ((GridView)sender).GetFocusedRowCellValue("EmailAddress").ToString();
                    txtPON.Text = ((GridView)sender).GetFocusedRowCellValue("TelephoneNo").ToString();
                    txtMOB.Text = ((GridView)sender).GetFocusedRowCellValue("MobileNo").ToString();
                    txtFAX.Text = ((GridView)sender).GetFocusedRowCellValue("FaxNo").ToString();
                    txtStreet.Text = ((GridView)sender).GetFocusedRowCellValue("Street").ToString();
                    txtBarangay.Text = ((GridView)sender).GetFocusedRowCellValue("Barangay").ToString();
                    cmbPRV.Text = ((GridView)sender).GetFocusedRowCellValue("Province").ToString();
                    txtCity.Text = ((GridView)sender).GetFocusedRowCellValue("City").ToString();
                    txtZIP.Text = ((GridView)sender).GetFocusedRowCellValue("ZipCode").ToString();
                    cmbCustomerType.Text = ((GridView)sender).GetFocusedRowCellValue("ClientType").ToString();
                    dkpREG.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Reg");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }
        private void gridCustomers_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
        }
        private void gridCustomers_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        private void gridTYP_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhity();
        }
        private void gridTYP_LostFocus(object sender, EventArgs e)
        {
            InputDimGy();
        }
        private void gridCredit_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhitc();
        }
        private void gridCredit_LostFocus(object sender, EventArgs e)
        {
            InputDimGc();
        }
        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    /* address */
                    var repoAddress = new Repository<Address>(unWork);
                    var address = new Address()
                    {
                        street = txtStreet.Text.Trim(' '),
                        barangay = txtBarangay.Text.Trim(' '),
                        city = txtCity.Text.Trim(' '),
                        province = cmbPRV.Text.Trim(' '),
                        zip_code = txtZIP.Text.Trim(' '),
                        country = "Philippines"
                    };
                    var addressId = repoAddress.Add(address);

                    /* contact */
                    var repoContact = new Repository<Contact>(unWork);
                    var contact = new Contact() { 
                        contact_name = txtNAM.Text.Trim(' '),
                        position = "na",
                        telephone_number = txtPON.Text.Trim(' '),
                        mobile_number = txtMOB.Text.Trim(' '),
                        mobile_secondary = txtMOB.Text.Trim(' '),
                        email_address = txtEML.Text.Trim(' '),
                        web_url =   "na",
                        fax_number = txtFAX.Text.Trim(' ')
                    };
                    var contactId = repoContact.Add(contact);

                    /* customer */
                    var repoCustomer = new Repository<Customers>(unWork);
                    var customer = new Customers()
                    {
                        customer_code    = txtCOD.Text.Trim(' '),
                        customer_name    = txtNAM.Text.Trim(' '),
                        gender  = cmbGEN.Text.Trim(' '),
                        contact_id = (int)contactId,
                        address_id = (int)addressId,
                        type_id = customerType_Id,
                        date_register = dkpREG.Value.Date
                    };
                    var result = repoCustomer.Add(customer);
                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1, "Customer Name: " + txtNAM.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }
        private void DataUpdate() {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    /* Customer */
                    var custId = Convert.ToInt32(txtCustomerId.Text);
                    var repoCustomer = new Repository<Customers>(unWork);
                    var repoContact = new Repository<Contact>(unWork);
                    var repoAddress = new Repository<Address>(unWork);
                    var queryCustomer = repoCustomer.Id(custId);
                    var queryContact = repoContact.Id(contact_Id);
                    var queryAddress = repoAddress.Id(address_id);
                    queryCustomer.customer_code    = txtCOD.Text.Trim(' ');
                    queryCustomer.customer_name    = txtNAM.Text.Trim(' ');
                    queryCustomer.gender  = cmbGEN.Text.Trim(' ');
                    queryCustomer.type_id = customerType_Id;
                    queryCustomer.date_register = dkpREG.Value.Date;
                    var result = repoCustomer.Update(queryCustomer);
                    /* Contact */
                    queryContact.email_address = txtEML.Text.Trim(' ');
                    queryContact.telephone_number = txtPON.Text.Trim(' ');
                    queryContact.mobile_number = txtMOB.Text.Trim(' ');
                    queryContact.fax_number = txtFAX.Text.Trim(' ');
                    queryContact.email_address = txtEML.Text.Trim();
                    var resultContact = repoContact.Update(queryContact);
                    /* address */
                    queryAddress.barangay  = txtBarangay.Text.Trim(' ');
                    queryAddress.street  = txtStreet.Text.Trim(' ');
                    queryAddress.province  = cmbPRV.Text.Trim(' ');
                    queryAddress.zip_code  = txtZIP.Text.Trim(' ');
                    queryAddress.city = txtCity.Text.Trim(' ');
                    var resultAddress = repoAddress.Update(queryAddress);

                    if (result && resultContact && resultAddress)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableCustomer + Messages.CodeName +
                                         txtNAM.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                                        Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableCustomer + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
                }
            }
        }
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var custId = Convert.ToInt32(txtCustomerId.Text);
                    var repository = new Repository<Customers>(unWork);
                    var que = repository.Id(custId);
                   
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableCustomer + Messages.CodeName +
                                         txtNAM.Text.Trim(' ') + " " + Messages.SuccessDelete,
                                        Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableCustomer + Messages.ErrorOccurred, Messages.TitleFialedDelete);
                }
            }
        }
        private void DataInserty()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<CustomerType>(unWork);
                    var typ = new CustomerType()
                    {
                        client_type = txtDET.Text.Trim(' ')
                    };
                    var result = repository.Add(typ);
                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1, "Customer Type: " + txtDET.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }
        private void DataUpdatey()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var custId = Convert.ToInt32(txtCTR.Text);
                    var repository = new Repository<CustomerType>(unWork);
                    var que = repository.Id(custId);
                    que.client_type = txtDET.Text.Trim(' ');
                    var result = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableType + Messages.CodeName +
                                         txtDET.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                                        Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableType + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
                }
            }
        }
        private void DataDeletey()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var custId = Convert.ToInt32(txtCTR.Text);
                    var repository = new Repository<CustomerType>(unWork);
                    var que = repository.Id(custId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableType + Messages.CodeName +
                                         txtNAM.Text.Trim(' ') + " " + Messages.SuccessDelete,
                                        Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableType + Messages.ErrorOccurred, Messages.TitleFialedDelete);
                }
            }
        }
        private void DataInsertc()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repoCustomer = new Repository<CustomerCredit>(unWork);
                    var typ = new CustomerCredit()
                    {
                        credit_code  = txtROD.Text.Trim(' '),
                        customer_id  = GetCustomerId(txtCUS.Text),
                        credit_limit = Convert.ToDecimal(txtLIM.Text), 
                        credit_used  = Convert.ToDecimal(txtUSE.Text), 
                        balance     = Convert.ToDecimal(txtBAL.Text) 
                    };
                    var result = repoCustomer.Add(typ);
                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1, "Customer Credit: " + txtCUS.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }
        private void DataUpdatec()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    /* Customer */
                    var custId = Convert.ToInt32(txtRID.Text);
                    var repoCustomer = new Repository<CustomerCredit>(unWork);
                    var queCustomer         = repoCustomer.Id(custId);
                    queCustomer.credit_code  = txtROD.Text.Trim(' ');
                    queCustomer.customer_id  = GetCustomerId(txtCUS.Properties.NullText);
                    queCustomer.credit_limit = decimal.Parse(txtLIM.Text);
                    queCustomer.credit_used  = decimal.Parse(txtUSE.Text);
                    queCustomer.balance     = Convert.ToDecimal(txtBAL.Text);
                    var resultCustomer = repoCustomer.Update(queCustomer);
                    if (resultCustomer)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableCredit + Messages.CodeName +
                                         txtCUS.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                                        Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableCredit + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
                }
            }
        }
        private void DataDeletec()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var custId = Convert.ToInt32(txtRID.Text);
                    var repository = new Repository<CustomerCredit>(unWork);
                    var que = repository.Id(custId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableCredit + Messages.CodeName +
                                         txtCUS.Text.Trim(' ') + " " + Messages.SuccessDelete,
                                        Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableCredit + Messages.ErrorOccurred, Messages.TitleFialedDelete);
                }
            }
        }
        private void BindCustomerType()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<CustomerType>(unWork);
                var query = repository.SelectAll(Query.AllCustomerType).Select(x => x.client_type).Distinct().ToList();
                cmbCustomerType.DataBindings.Clear();
                cmbCustomerType.DataSource = query;
            }
        }
        private void BindCustomerName()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ViewCustomers>(unWork);
                var query = repository.SelectAll(Query.AllCustomers).Select(x => x.customer_name).Distinct().ToList();
                txtCUS.Properties.DataSource = query;
            }
        }
        private static int getCustomerTypeId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                        var repository = new Repository<CustomerType>(unWork);
                        var query = repository.FindBy(x => x.client_type == input);
                        return query.type_Id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Customer Type Id Error", "Customer Details");
                    throw;
                }
            }
        }

        private static int getContactId(int customerId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Customers>(unWork);
                    var query = repository.FindBy(x => x.customer_id == customerId);
                    return query.contact_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Contact Id Error", "Update Customer");
                    return 0;
                }
            }
        }

        private static int getAddressId(int customerId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Customers>(unWork);
                    var query = repository.FindBy(x => x.customer_id == customerId);
                    return query.address_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Address Id Error", "Update Customer");
                    return 0;
                }
            }
        }

        private static int GetCustomerId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Customers>(unWork);
                    var query = repository.FindBy(x => x.customer_name == input);
                    return query.customer_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Customer Type Id Error", "Customer Details");
                    throw;
                }
            }
        }
        private void TabCustomer_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (TabCustomer.SelectedTabPage == xDET)
            {
                ButtonCan();
                _cus = true;
                _typ = false;
                _crd = false;
                gridCtlCustomer.Enabled = true;
                gridCtlType.Enabled = false;
                gridCtlCredit.Enabled = false;
                BindCustomerList();

            }
            if (TabCustomer.SelectedTabPage == xTYP)
            {
                ButtonCan();
                _cus = false;
                _typ = true;
                _crd = false;
                gridCtlType.Enabled = true;
                gridCtlCustomer.Enabled = false;
                gridCtlCredit.Enabled = false;
                BindTypeList();
            }
            if (TabCustomer.SelectedTabPage == xLIM)
            {
                ButtonCan();
                _cus = false;
                _typ = false;
                _crd = true;
                gridCtlType.Enabled = false;
                gridCtlCustomer.Enabled = false;
                gridCtlCredit.Enabled = true;
                BindCreditList();
            }
        }
        private void txtUSE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var useNum = decimal.Parse(txtUSE.Text);
                var limNum = decimal.Parse(txtLIM.Text);
                if (useNum > limNum)
                {
                    txtUSE.Focus();
                    txtUSE.BackColor = Color.Yellow;
                    PopupNotification.PopUpMessages(0, "Credit Use must not exceed to credit limit!", "Credit Details");
                }
                else
                {
                    txtUSE.BackColor = Color.White;
                    txtBAL.Focus();
                    txtBAL.BackColor = Color.Yellow;
                    var credit = limNum - useNum;
                    txtBAL.Text = Convert.ToString(credit, CultureInfo.CurrentCulture);
                    lblUSE.Text = $"{useNum:n}";
                    lblBAL.Text = $"{credit:n}";
                }
            }
        }
        private void txtCUS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var input = txtCUS;
                if (input.Text.Length > 0)
                {
                    input.BackColor = Color.White;
                    txtLIM.BackColor = Color.Yellow;
                    txtLIM.Focus();
                }
                else
                {
                    input.BackColor = Color.Yellow;
                    input.Focus();
                    PopupNotification.PopUpMessages(0, "Customer name must not be empty!", "Credit Details");
                }
            }
        }
        private void txtLIM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtLIM.Text.Length > 0)
                {
                    txtLIM.BackColor = Color.White;
                    txtUSE.BackColor = Color.Yellow;
                    txtUSE.Focus();
                }
                else
                {
                    txtLIM.BackColor = Color.Yellow;
                    txtLIM.Focus();
                    PopupNotification.PopUpMessages(0, "Credit Limit must not be empty!", "Credit Details");
                }
            }
        }

        private void cmbCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                customerType_Id = getCustomerTypeId(cmbCustomerType.Text.Trim(' '));
                InputManipulation.InputBoxLeave(cmbCustomerType, dkpREG,
                "Customer Company",
                Messages.TitleCustomer);
            }
            if (e.KeyCode == Keys.Tab)
            {
                customerType_Id = getCustomerTypeId(cmbCustomerType.Text.Trim(' '));
                InputManipulation.InputBoxLeave(cmbCustomerType, dkpREG,
                "Customer Company",
                Messages.TitleCustomer);
            }

            if (e.KeyCode == Keys.F1)
            {
                BindCustomerType();
            }
        }

        private void txtBAL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBAL.Text.Length > 0)
                {
                    txtBAL.BackColor = Color.White;
                    bntSAV.Focus();
                }
                else
                {
                    txtBAL.BackColor = Color.Yellow;
                    txtBAL.Focus();
                    PopupNotification.PopUpMessages(0, "Credit Balanced must not be empty!", "Credit Details");
                }
            }
        }
        private void txtUSE_Leave(object sender, EventArgs e)
        {
            var useNum = decimal.Parse(txtUSE.Text);
            var limNum = decimal.Parse(txtLIM.Text);
            if (useNum > limNum)
            {
                txtUSE.Focus();
                txtUSE.BackColor = Color.Yellow;
                PopupNotification.PopUpMessages(0, "Credit Use must not exceed to credit limit!", "Credit Details");
            }
            else
            {
                txtUSE.BackColor = Color.White;
                var credit = limNum - useNum;
                txtBAL.Text = Convert.ToString(credit, CultureInfo.CurrentCulture);
                lblUSE.Text = $"{useNum:n}";
                lblBAL.Text = $"{credit:n}";
            }
        }
        private void txtBAL_Leave(object sender, EventArgs e)
        {
            lblBAL.Text = txtBAL.Text;
        }
        #endregion
        private void gridTYP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridTYP.RowCount <= 0) return;
                txtCTR.Text = ((GridView)sender).GetFocusedRowCellValue("TypeId").ToString();
                txtDET.Text = ((GridView)sender).GetFocusedRowCellValue("ClientType").ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
         }
        private void gridCredit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridCredit.RowCount<= 0) return;
            try
            {
                txtRID.Text = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                txtROD.Text = ((GridView)sender).GetFocusedRowCellValue("CreditCode").ToString();
                txtCUS.Properties.NullText = ((GridView)sender).GetFocusedRowCellValue("Name").ToString();
                txtLIM.Text = ((GridView)sender).GetFocusedRowCellValue("CreditLimit").ToString();
                txtUSE.Text = ((GridView)sender).GetFocusedRowCellValue("CreditUsed").ToString();
                txtBAL.Text = ((GridView)sender).GetFocusedRowCellValue("Balance").ToString();
                var use = ((GridView)sender).GetFocusedRowCellValue("CreditUsed");
                var bal = ((GridView)sender).GetFocusedRowCellValue("Balance");
                lblBAL.Text = $"{bal:n}";
                lblUSE.Text = $"{use:n}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}

