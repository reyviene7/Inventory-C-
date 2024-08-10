using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ServeAll.Configuration;
using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;

namespace ServeAll.MainForm
{
    public partial class FrmManufacturer : Form
    {
        private FrmMain _main;
        private bool _add, _edt, _del;
        public FrmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmManufacturer()
        {
            InitializeComponent();
        }

        private void FrmManufacturer_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            BindManufacturerList();
        }

        private void FrmManufacturer_MouseMove(object sender, MouseEventArgs e)
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
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Manufacturer Name: " + txtManufacturerName.Text.Trim(' ') + " " + "?", "Manufacturer Details");
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

        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var man = PopupNotification.PopUpMassageLogOff();
            if (man <= 0) return;
            var log = new FrmLogin();
            log.Show();
            Hide();
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
        #region ButtonCRUD
        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            InputClea();
            GenerateCode();
            BindCompany();
            txtManufacturerName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
        }
        private void ButUpd()
        {
            ButtonUpd();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = true;
            _del = false;
            gCON.Enabled = false;
        }
        private void ButDel()
        {
            ButtonDel();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gCON.Enabled = false;
        }
        private void ButClr()
        {
            ButtonClr();
            InputEnab();
            InputWhit();
            InputClea();
            gCON.Enabled = true;
            cmbCompany.DataBindings.Clear();
        }
        private void ButSav()
        {
            if (_add && _edt == false && _del == false)
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindManufacturerList();
            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindManufacturerList();
            }
            if (_add == false && _edt == false && _del)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindManufacturerList();
            }
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
            cmbCompany.DataBindings.Clear();
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbCompany.DataBindings.Clear();
        }
        #endregion
        private void InputWhit()
        {
            txtManufacturerId.BackColor = Color.White;
            txtManufacturerCode.BackColor = Color.White;
            txtManufacturerName.BackColor = Color.White;
            cmbGender.BackColor = Color.White;
            txtManufacturerEmail.BackColor = Color.White;
            txtManufacturerPhone.BackColor = Color.White;
            txtManufacturerMobile.BackColor = Color.White;
            txtFaxNumber.BackColor = Color.White;
            txtSupplierAddress.BackColor = Color.White;
            cmbProvincialAddress.BackColor = Color.White;
            txtZipcode.BackColor = Color.White;
            cmbCompany.BackColor = Color.White;
            dkpDateRegister.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtManufacturerId.Enabled = true;
            txtManufacturerCode.Enabled = true;
            txtManufacturerName.Enabled = true;
            cmbGender.Enabled = true;
            txtManufacturerEmail.Enabled = true;
            txtManufacturerPhone.Enabled = true;
            txtManufacturerMobile.Enabled = true;
            txtFaxNumber.Enabled = true;
            txtSupplierAddress.Enabled = true;
            cmbProvincialAddress.Enabled = true;
            txtZipcode.Enabled = true;
            cmbCompany.Enabled = true;
            dkpDateRegister.Enabled = true;
        }
        private void InputDisb()
        {
            txtManufacturerId.Enabled = false;
            txtManufacturerCode.Enabled = false;
            txtManufacturerName.Enabled = false;
            cmbGender.Enabled = false;
            txtManufacturerEmail.Enabled = false;
            txtManufacturerPhone.Enabled = false;
            txtManufacturerMobile.Enabled = false;
            txtFaxNumber.Enabled = false;
            txtSupplierAddress.Enabled = false;
            cmbProvincialAddress.Enabled = false;
            txtZipcode.Enabled = false;
            cmbCompany.Enabled = false;
            dkpDateRegister.Enabled = false;
        }
        private void InputClea()
        {
            txtManufacturerId.Clear();
            txtManufacturerCode.Clear();
            txtManufacturerName.Clear();
            cmbGender.Text = "";
            txtManufacturerEmail.Clear();
            txtManufacturerPhone.Clear();
            txtManufacturerMobile.Clear();
            txtFaxNumber.Clear();
            txtSupplierAddress.Clear();
            cmbProvincialAddress.Text = "";
            txtZipcode.Clear();
            cmbCompany.Text = "";
            dkpDateRegister.Value = DateTime.Now.Date;
        }
        private void InputDimG()
        {
            txtManufacturerId.BackColor = Color.DimGray;
            txtManufacturerCode.BackColor = Color.DimGray;
            txtManufacturerName.BackColor = Color.DimGray;
            cmbGender.BackColor = Color.DimGray;
            txtManufacturerEmail.BackColor = Color.DimGray;
            txtManufacturerPhone.BackColor = Color.DimGray;
            txtManufacturerMobile.BackColor = Color.DimGray;
            txtFaxNumber.BackColor = Color.DimGray;
            txtSupplierAddress.BackColor = Color.DimGray;
            cmbProvincialAddress.BackColor = Color.DimGray;
            txtZipcode.BackColor = Color.DimGray;
            cmbCompany.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
        }

        private void BindCompany()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Company>(unWork);
                var query = repository.SelectAll(Query.AllCompany).Select(x => x.company_name).Distinct().ToList();
                cmbCompany.DataBindings.Clear();
                cmbCompany.DataSource = query;
            }
        }
        private int CompanyId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Company>(unWork);
                    var query = repository.FindBy(x => x.company_name == input);
                    return query.company_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "CompanyId Error", "Supplier Details");
                    throw;
                }
            }
        }

        //BINDING
        private void BindManufacturerList()
        {
            gCON.Update();
            try
            {
                gCON.DataBindings.Clear();
                gCON.DataSource = RebindManufacturer();
            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private IEnumerable<ViewManufacturer> RebindManufacturer()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewManufacturer>(unWork);
                    return repository.SelectAll(Query.AllManufacture).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleManufacturer);
                    throw;
                }
            }
        }

        //GENERATE ID 
        private string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewManufacturer>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllManufacture)
                              orderby b.manufacture_id descending
                              select b.profile_code).Take(1).SingleOrDefault();
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
            var lastCode = GetLastId();
            var lastId = ConfigSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "MN");
            alphaNumeric.Increment();
            txtManufacturerCode.Text = alphaNumeric.ToString();
        }

        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewManufacturer>(unWork);
                    var supplier = new ViewManufacturer()
                    {
                        profile_code = txtManufacturerCode.Text.Trim(' '),
                        name = txtManufacturerName.Text.Trim(' '),
                        gender = cmbGender.Text.Trim(' '),
                        email_address = txtManufacturerEmail.Text.Trim(' '),
                        telephone_number = txtManufacturerPhone.Text.Trim(' '),
                        mobile_number = txtManufacturerMobile.Text.Trim(' '),
                        fax_number = txtFaxNumber.Text.Trim(' '),
                        barangay = txtSupplierAddress.Text.Trim(' '),
                        province = cmbProvincialAddress.Text.Trim(' '),
                        zip_code = txtZipcode.Text.Trim(' '),
                        company_id = CompanyId(cmbCompany.Text.Trim(' ')),
                        date_register = dkpDateRegister.Value.Date
                    };
                    var result = repository.Add(supplier);
                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1, "Manufacturer Name: " + txtManufacturerName.Text.Trim(' ') + " " + Messages.SuccessInsert,
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
        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var custId = Convert.ToInt32(txtManufacturerId.Text);
                    var repository = new Repository<ViewManufacturer>(unWork);
                    var que = repository.Id(custId);
                    que.profile_code = txtManufacturerCode.Text.Trim(' ');
                    que.name = txtManufacturerName.Text.Trim(' ');
                    que.gender = cmbGender.Text.Trim(' ');
                    que.email_address = txtManufacturerEmail.Text.Trim(' ');
                    que.telephone_number = txtManufacturerPhone.Text.Trim(' ');
                    que.mobile_number = txtManufacturerMobile.Text.Trim(' ');
                    que.fax_number = txtFaxNumber.Text.Trim(' ');
                    que.barangay = txtSupplierAddress.Text.Trim(' ');
                    que.province = cmbProvincialAddress.Text.Trim(' ');
                    que.zip_code = txtZipcode.Text.Trim(' ');
                    que.company_id = CompanyId(cmbCompany.Text.Trim(' '));
                    que.date_register = dkpDateRegister.Value.Date;
                    var result = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableManufacturer + Messages.CodeName +
                                         txtManufacturerName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                                        Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableManufacturer + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
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
                    var custId = Convert.ToInt32(txtManufacturerId.Text);
                    var repository = new Repository<Manufacturer>(unWork);
                    var que = repository.Id(custId);

                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, Messages.TableManufacturer + Messages.CodeName +
                                         txtManufacturerName.Text.Trim(' ') + " " + Messages.SuccessDelete,
                                        Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableManufacturer + Messages.ErrorOccurred, Messages.TitleFialedDelete);
                }
            }
        }

        private void gridManufacturer_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            InputWhit();
        }
        private void gridManufacturer_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        private void gridManufacturer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridManufacturer.RowCount > 0)
            {
                try
                {
                    txtManufacturerId.Text = ((GridView)sender).GetFocusedRowCellValue("ManufacturerId").ToString();
                    txtManufacturerCode.Text = ((GridView)sender).GetFocusedRowCellValue("Code").ToString();
                    txtManufacturerName.Text = ((GridView)sender).GetFocusedRowCellValue("Name").ToString();
                    cmbGender.Text = ((GridView)sender).GetFocusedRowCellValue("Gender").ToString();
                    txtManufacturerEmail.Text = ((GridView)sender).GetFocusedRowCellValue("Email").ToString();
                    txtManufacturerPhone.Text = ((GridView)sender).GetFocusedRowCellValue("Phone").ToString();
                    txtManufacturerMobile.Text = ((GridView)sender).GetFocusedRowCellValue("Mobile").ToString();
                    txtFaxNumber.Text = ((GridView)sender).GetFocusedRowCellValue("Fax").ToString();
                    txtSupplierAddress.Text = ((GridView)sender).GetFocusedRowCellValue("Address").ToString();
                    cmbProvincialAddress.Text = ((GridView)sender).GetFocusedRowCellValue("Province").ToString();
                    txtZipcode.Text = ((GridView)sender).GetFocusedRowCellValue("ZipCode").ToString();
                    cmbCompany.Text = ((GridView)sender).GetFocusedRowCellValue("Company").ToString();
                    dkpDateRegister.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Register");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        #region LeaveKeyDownInput  
        //STRING MANIPULATION
        private void txtManufacturerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtManufacturerCode, txtManufacturerName,
                "Manufacturer Code",
                Messages.TitleManufacturer);
            }
        }

        private void txtManufacturerCode_Leave(object sender, EventArgs e)
        {
            if (_add || _edt)
            {
                InputManipulation.InputBoxLeave(txtManufacturerCode, txtManufacturerName,
                "Manufacturer Code",
                Messages.TitleManufacturer);
            }
        }

        private void txtManufacturerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtManufacturerName, cmbGender,
                "Manufacturer Name",
                Messages.TitleManufacturer);
            }
        }

        private void txtManufacturerName_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtManufacturerName, cmbGender,
               "Manufacturer Name",
               Messages.TitleManufacturer);
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbGender, txtManufacturerEmail,
                "Manufacturer Gender",
                Messages.TitleManufacturer);
            }
        }

        private void cmbGender_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbGender, txtManufacturerEmail,
                "Manufacturer Gender",
                Messages.TitleManufacturer);
        }

        private void txtManufacturerEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtManufacturerEmail, txtManufacturerPhone,
                "Manufacturer Email",
                Messages.TitleManufacturer);
            }
        }

        private void txtManufacturerEmail_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(txtManufacturerEmail, txtManufacturerPhone,
               "Manufacturer Email",
               Messages.TitleManufacturer);
        }

        private void txtManufacturerPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtManufacturerPhone, txtManufacturerMobile,
                "Manufacturer Phone",
                Messages.TitleManufacturer);
            }
        }

        private void txtManufacturerPhone_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtManufacturerPhone, txtManufacturerMobile,
               "Manufacturer Phone",
               Messages.TitleManufacturer);
        }

        private void txtManufacturerMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtManufacturerMobile, txtFaxNumber,
                "Manufacturer Mobile",
                Messages.TitleManufacturer);
            }
        }

        private void txtManufacturerMobile_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtManufacturerMobile, txtFaxNumber,
                "Manufacturer Mobile",
                Messages.TitleManufacturer);
        }

        private void txtFaxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtFaxNumber, txtSupplierAddress,
                "Manufacturer Fax Number",
                Messages.TitleManufacturer);
            }
        }

        private void txtFaxNumber_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtFaxNumber, txtSupplierAddress,
                "Manufacturer Fax Number",
                Messages.TitleManufacturer);
        }

        private void txtSupplierAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSupplierAddress, cmbProvincialAddress,
                "Manufacturer Address",
                Messages.TitleManufacturer);
            }
        }

        private void txtSupplierAddress_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtSupplierAddress, cmbProvincialAddress,
                "Manufacturer Address",
                Messages.TitleManufacturer);
        }

        private void cmbProvincialAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbProvincialAddress, txtZipcode,
                "Manufacturer Provincial Address",
                Messages.TitleManufacturer);
            }
        }

        private void cmbProvincialAddress_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbProvincialAddress, txtZipcode,
                "Manufacturer Provincial Address",
                Messages.TitleManufacturer);
        }

        private void txtZipcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtZipcode, cmbCompany,
                "Manufacturer Zip Code",
                Messages.TitleManufacturer);
            }
        }

        private void txtZipcode_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtZipcode, cmbCompany,
                "Manufacturer Zip Code",
                Messages.TitleManufacturer);
        }

        private void cmbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbCompany, dkpDateRegister,
                "Manufacturer Company",
                Messages.TitleManufacturer);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindCompany();
            }
        }

        private void cmbCompany_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbCompany, dkpDateRegister,
                "Manufacturer Company",
                Messages.TitleManufacturer);
        }

        private void dkpDateRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateRegister, bntSAV,
                "Date Register",
                Messages.TitleManufacturer);
            }
        }

        private void dkpDateRegister_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpDateRegister, bntSAV,
                "Date Register",
                Messages.TitleManufacturer);
        }
        #endregion
    }
}
