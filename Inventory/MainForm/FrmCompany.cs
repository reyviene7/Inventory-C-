using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ServeAll.Configuration;
using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;

namespace ServeAll.MainForm
{
    public partial class FrmCompany : Form
    {
        private FrmMain _main;
        private bool _add, _edt, _del;
        public FrmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmCompany()
        {
            InitializeComponent();
        }

        private void FrmCompany_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            BindCompanyList();
        }

        private void FrmCompany_MouseMove(object sender, MouseEventArgs e)
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
            buttomAdd();
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
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Company Name: " + txtCompanyName.Text.Trim(' ') + " " + "?", "Company Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
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
            PopupNotification.PopUpMessageExit();
        }

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

        private void InputWhit()
        {
            txtCompanyId.BackColor = Color.White;
            txtCompanyCode.BackColor = Color.White;
            txtCompanyName.BackColor = Color.White;
            txtCompanyAddress.BackColor = Color.White;
            cmbProvincial.BackColor = Color.White;
            txtZipcode.BackColor = Color.White;
            txtPhoneNumber.BackColor = Color.White;
            txtMobileNumber.BackColor = Color.White;
            txtFaxNumber.BackColor = Color.White;
            txtEmailAddress.BackColor = Color.White;
            cmbBusinessType.BackColor = Color.White;
            dkpDateRegister.BackColor = Color.White;
        }
        private void InputDisd()
        {
            txtCompanyId.Enabled = false;
            txtCompanyCode.Enabled = false;
            txtCompanyName.Enabled = false;
            txtCompanyAddress.Enabled = false;
            cmbProvincial.Enabled = false;
            txtZipcode.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtMobileNumber.Enabled = false;
            txtFaxNumber.Enabled = false;
            txtEmailAddress.Enabled = false;
            cmbBusinessType.Enabled = false;
            dkpDateRegister.Enabled = false;
        }
        private void InputEnad()
        {
            txtCompanyId.Enabled = true;
            txtCompanyCode.Enabled = true;
            txtCompanyName.Enabled = true;
            txtCompanyAddress.Enabled = true;
            cmbProvincial.Enabled = true;
            txtZipcode.Enabled = true;
            txtPhoneNumber.Enabled = true;
            txtMobileNumber.Enabled = true;
            txtFaxNumber.Enabled = true;
            txtEmailAddress.Enabled = true;
            cmbBusinessType.Enabled = true;
            dkpDateRegister.Enabled = true;
        }
        private void InputDimG()
        {
            txtCompanyId.BackColor = Color.DimGray;
            txtCompanyCode.BackColor = Color.DimGray;
            txtCompanyName.BackColor = Color.DimGray;
            txtCompanyAddress.BackColor = Color.DimGray;
            cmbProvincial.BackColor = Color.DimGray;
            txtZipcode.BackColor = Color.DimGray;
            txtPhoneNumber.BackColor = Color.DimGray;
            txtMobileNumber.BackColor = Color.DimGray;
            txtFaxNumber.BackColor = Color.DimGray;
            txtEmailAddress.BackColor = Color.DimGray;
            cmbBusinessType.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
        }
        private void InputClea()
        {
            txtCompanyId.Clear();
            txtCompanyCode.Clear();
            txtCompanyName.Clear();
            txtCompanyAddress.Clear();
            cmbProvincial.Text = "";
            txtZipcode.Clear();
            txtPhoneNumber.Clear();
            txtMobileNumber.Clear();
            txtFaxNumber.Clear();
            txtEmailAddress.Clear();
            cmbBusinessType.Text = "";
        }

        private void GenerateCode()
        {
            var lastCode = GetLastId();
            var lastId = ConfigSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "EN");
            alphaNumeric.Increment();
            txtCompanyCode.Text = alphaNumeric.ToString();
        }

        private string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<Company>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllEmployees)
                              orderby b.company_id descending
                              select b.company_code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }

        //CRUD
        private void buttomAdd()
        {
            ButtonAdd();
            InputEnad();
            InputWhit();
            InputClea();
            GenerateCode();
            txtCompanyName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
        }
        private void ButUpd()
        {
            ButtonUpd();
            InputEnad();
            InputWhit();
            _add = false;
            _edt = true;
            _del = false;
            gCON.Enabled = false;
        }

        private void ButSav()
        {
            if (_add && _edt == false && _del == false)
            {
                DataInsert();
                ButtonSav();
                InputDisd();
                InputDimG();
                InputClea();

                BindCompanyList();
            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisd();
                InputDimG();
                InputClea();

                BindCompanyList();
            }
            if (_add == false && _edt == false && _del)
            {
                DataDelete();
                ButtonSav();
                InputDisd();
                InputDimG();
                InputClea();
                BindCompanyList();
            }
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
        }
        private void ButClr()
        {
            ButtonClr();
            InputEnad();
            InputWhit();
            InputClea();
            gCON.Enabled = true;
        }

        private void ButCan()
        {
            ButtonCan();
            InputDisd();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
        }
        private void ButDel()
        {
            ButtonDel();
            InputEnad();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gCON.Enabled = false;
        }

        private void BindCompanyList()
        {
            gCON.Update();
            try
            {
                gCON.DataBindings.Clear();
                gCON.DataSource = RebindCompany();
            }
            catch (Exception)
            {
                gCON.EndUpdate();
                throw;
            }
        }

        private IEnumerable<Company> RebindCompany()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Company>(unWork);
                    return repository.SelectAll(Query.AllCompany).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleEmployees);
                    throw;
                }
            }
        }

        private void gridCompany_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }

        private void gridCompany_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = gridCompany;
            if (grid.RowCount > 0)
                try
                {
                    txtCompanyId.Text = ((GridView)sender).GetFocusedRowCellValue("CompanyId").ToString();
                    txtCompanyCode.Text = ((GridView)sender).GetFocusedRowCellValue("Code").ToString();
                    txtCompanyName.Text = ((GridView)sender).GetFocusedRowCellValue("Name").ToString();
                    txtCompanyAddress.Text = ((GridView)sender).GetFocusedRowCellValue("Address").ToString();
                    cmbProvincial.Text = ((GridView)sender).GetFocusedRowCellValue("Province").ToString();
                    txtZipcode.Text = ((GridView)sender).GetFocusedRowCellValue("ZipCode").ToString();
                    txtPhoneNumber.Text = ((GridView)sender).GetFocusedRowCellValue("Phone").ToString();
                    txtMobileNumber.Text = ((GridView)sender).GetFocusedRowCellValue("Mobile").ToString();
                    txtFaxNumber.Text = ((GridView)sender).GetFocusedRowCellValue("Fax").ToString();
                    txtEmailAddress.Text = ((GridView)sender).GetFocusedRowCellValue("Email").ToString();
                    cmbBusinessType.Text = ((GridView)sender).GetFocusedRowCellValue("Type").ToString();
                    dkpDateRegister.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Register");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }

        }

        private void gridCompany_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            InputWhit();
        }
        //DAL 
        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Company>(unWork);
                    var info = new Company()
                    {
                        company_code = txtCompanyCode.Text.Trim(' '),
                        company_name = txtCompanyName.Text.Trim(' '),
                        barangay = txtCompanyAddress.Text.Trim(' '),
                        province = cmbProvincial.Text.Trim(' '),
                        zip_code = txtZipcode.Text.Trim(' '),
                        telephone_number = txtPhoneNumber.Text.Trim(' '),
                        mobile_number = txtMobileNumber.Text.Trim(' '),
                        fax_number = txtFaxNumber.Text.Trim(' '),
                        email_address = txtEmailAddress.Text.Trim(' '),
                        company_type = cmbBusinessType.Text.Trim(' '),
                        date_register = dkpDateRegister.Value.Date
                    };
                    var result = repository.Add(info);
                    if (result > 0)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Company Code: " +
                                                           txtCompanyCode.Text.Trim(' ')
                                                           + " " + Messages.SuccessInsert,
                            Messages.TitleSuccessInsert);
                    }

                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtCompanyName, txtCompanyAddress, "Company Name", Messages.TitleCompany);
            }
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtCompanyName, txtCompanyAddress, "Company Name", Messages.TitleCompany);
        }

        private void txtCompanyAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtCompanyAddress, cmbProvincial, "Company Address", Messages.TitleCompany);
            }
        }

        private void txtCompanyAddress_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtCompanyAddress, cmbProvincial, "Company Address", Messages.TitleCompany);
        }

        private void cmbProvincial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbProvincial, txtZipcode, "Company Provincial Address", Messages.TitleCompany);
            }
        }

        private void cmbProvincial_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbProvincial, txtZipcode, "Company Provincial Address", Messages.TitleCompany);
        }

        private void txtZipcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtZipcode, txtPhoneNumber, "Company ZipCode", Messages.TitleCompany);
            }
        }

        private void txtZipcode_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtZipcode, txtPhoneNumber, "Company ZipCode", Messages.TitleCompany);
        }

        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtPhoneNumber, txtMobileNumber, "Company Phone Number", Messages.TitleCompany);
            }
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtPhoneNumber, txtMobileNumber, "Company Phone Number", Messages.TitleCompany);
        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtMobileNumber, txtFaxNumber, "Company Mobile Number", Messages.TitleCompany);

            }
        }

        private void txtMobileNumber_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtMobileNumber, txtFaxNumber, "Company Mobile Number", Messages.TitleCompany);
        }

        private void txtFaxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtFaxNumber, txtEmailAddress, "Company Fax Number", Messages.TitleCompany);
            }
        }

        private void txtFaxNumber_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtFaxNumber, txtEmailAddress, "Company Fax Number", Messages.TitleCompany);
        }

        private void txtEmailAddress_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtEmailAddress, cmbBusinessType, "Company Email Address", Messages.TitleCompany);
        }

        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtEmailAddress, cmbBusinessType, "Company Email Address", Messages.TitleCompany);

            }
        }

        private void cmbBusinessType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbBusinessType, dkpDateRegister, "Business Type", Messages.TitleCompany);

            }
        }

        private void cmbBusinessType_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbBusinessType, dkpDateRegister, "Business Type", Messages.TitleCompany);
        }

        private void dkpDateRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateRegister, bntSAV, "Date Register", Messages.TitleCompany);

            }
        }

        private void dkpDateRegister_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpDateRegister, bntSAV, "Date Register", Messages.TitleCompany);
        }

        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var empId = Convert.ToInt32(txtCompanyId.Text);
                try
                {
                    var repository = new Repository<Company>(unWork);
                    var que = repository.Id(empId);
                    que.company_code = txtCompanyCode.Text.Trim(' ');
                    que.company_name = txtCompanyName.Text.Trim(' ');
                    que.barangay = txtCompanyAddress.Text.Trim(' ');
                    que.province = cmbProvincial.Text.Trim(' ');
                    que.zip_code = txtZipcode.Text.Trim(' ');
                    que.telephone_number = txtPhoneNumber.Text.Trim(' ');
                    que.mobile_number = txtMobileNumber.Text.Trim(' ');
                    que.fax_number = txtFaxNumber.Text.Trim(' ');
                    que.email_address = txtEmailAddress.Text.Trim(' ');
                    que.company_type = cmbBusinessType.Text.Trim(' ');
                    que.date_register = dkpDateRegister.Value.Date;
                    var result = repository.Update(que);
                    if (!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableCompany + Messages.CodeName +
                                                     txtCompanyName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                                                    Messages.TitleSuccessUpdate);

                    unWork.Commit();
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableCompany + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
                }
            }
        }
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var empId = Convert.ToInt32(txtCompanyId.Text);
                try
                {
                    var repository = new Repository<Company>(unWork);
                    var que = repository.Id(empId);

                    var result = repository.Delete(que);
                    if (!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableCompany + Messages.CodeName +
                                                    txtCompanyName.Text.Trim(' ') + " " + Messages.SuccessDelete,
                                                    Messages.TitleSuccessDelete);
                    unWork.Commit();
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableEmployees + Messages.ErrorOccurred, Messages.TitleFialedDelete);
                }
            }
        }
    }
}
