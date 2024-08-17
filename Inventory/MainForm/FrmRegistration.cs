using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Inventory.MainForm
{
    public partial class FrmRegistration : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del;
        private ViewProfile _profile;
        private IEnumerable<ViewProfile> _profileList;
        public FirmMain Main
        {
            get { return _main; }

            set { _main = value; }
        }
        public FrmRegistration()
        {
            InitializeComponent();
        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            _profileList = EnumerableUtils.getProfileList();
            bindProfileList();
        }
        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void FrmRegistration_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }

        private void HomePage()
        {
            Main.Show();
            Close();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if (que <= 0) return;
            var log = new FirmLogin();
            log.Show();
            Close();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void buttonInsert()
        {
            ButtonAdd();
            enabledProfile();
            whiteProfile();
            clearProfile();
            generateProfileCode();
            generateAddressCode();
            generateContactCode();
            txtFirstName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridCtlProfile.Enabled = false;
        }
        private void buttonUpdate()
        {
            ButtonUpd();
            enabledProfile();
            whiteProfile();
            _add = false;
            _edt = true;
            _del = false;
            gridCtlProfile.Enabled = false;
        }
        private void ButDel()
        {
            ButtonDel();
            enabledProfile();
            whiteProfile();
            _add = false;
            _edt = false;
            _del = true;
            gridCtlProfile.Enabled = false;
        }
        private void buttonSave()
        {
            addProfile();
            if (_add && _edt == false && _del == false)
            {
                ButtonSav();
                disabledProfile();
                grayProfile();
                clearProfile();
            }
            if (_add == false && _edt && _del == false)
            {
                updateProfile();
                ButtonSav();
                disabledProfile();
                grayProfile();
                clearProfile();
            }
            if (_add == false && _edt == false && _del)
            {
                deleteProfile();
                ButtonSav();
                disabledProfile();
                grayProfile();
                clearProfile();
            }
            _add = false;
            _edt = false;
            _del = false;
            xtraControl.SelectedTabPage = xtraProfile;
            bindProfileList();
            gridCtlProfile.Enabled = true;
        }

        private void buttonClear()
        {
            ButtonClr();
            enabledProfile();
            whiteProfile();
            clearProfile();
            gridCtlProfile.Enabled = true;
        }

        private void buttonCancel()
        {
            ButtonCan();
            disabledProfile();
            grayProfile();
            clearProfile();
            gridCtlProfile.Enabled = true;
        }

        private void ButtonAdd()
        {
            bntInsert.Enabled = true;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }

        private void ButtonUpd()
        {
            bntInsert.Enabled = false;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }

        private void ButtonDel()
        {
            bntInsert.Enabled = false;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = true;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }

        private void ButtonSav()
        {
            bntInsert.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }

        private void ButtonClr()
        {
            bntInsert.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = false;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }

        private void ButtonCan()
        {
            bntInsert.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }

        private void enabledProfile()
        {
            txtProfileID.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtMiddleInitial.Enabled = true;
            cmbgender.Enabled = true;
            dkpBirthdate.Enabled = true;
            cmbCivilStatus.Enabled = true;
            txtPhone.Enabled = true;
            txtMobile.Enabled = true;
            txtEmail.Enabled = true;
            txtAddress.Enabled = true;
            cmbProvince.Enabled = true;
            txtSSSNumber.Enabled = true;
            txtPhilhealthNumber.Enabled = true;
            cmbPosition.Enabled = true;
            cmbDepartment.Enabled = true;
            dkpDateHired.Enabled = true;
            dkpDateRegistered.Enabled = true;
            txtBarcode.Enabled = true;
        }
        private void disabledProfile()
        {
            txtProfileID.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtMiddleInitial.Enabled = false;
            cmbgender.Enabled = false;
            dkpBirthdate.Enabled = false;
            cmbCivilStatus.Enabled = false;
            txtPhone.Enabled = false;
            txtMobile.Enabled = false;
            txtEmail.Enabled = false;
            txtAddress.Enabled = false;
            cmbProvince.Enabled = false;
            txtSSSNumber.Enabled = false;
            txtPhilhealthNumber.Enabled = false;
            cmbPosition.Enabled = false;
            cmbDepartment.Enabled = false;
            dkpDateHired.Enabled = false;
            dkpDateRegistered.Enabled = false;
            txtBarcode.Enabled = false;
        }
        private void grayProfile()
        {
            txtProfileID.BackColor = Color.DimGray;
            txtFirstName.BackColor = Color.DimGray;
            txtLastName.BackColor = Color.DimGray;
            txtMiddleInitial.BackColor = Color.DimGray;
            cmbgender.BackColor = Color.DimGray;
            cmbCivilStatus.BackColor = Color.DimGray;
            txtPhone.BackColor = Color.DimGray;
            txtMobile.BackColor = Color.DimGray;
            txtEmail.BackColor = Color.DimGray;
            txtAddress.BackColor = Color.DimGray;
            cmbProvince.BackColor = Color.DimGray;
            txtSSSNumber.BackColor = Color.DimGray;
            txtPhilhealthNumber.BackColor = Color.DimGray;
            cmbPosition.BackColor = Color.DimGray;
            cmbDepartment.BackColor = Color.DimGray;
            txtBarcode.BackColor = Color.DimGray;
        }
        private void whiteProfile()
        {
            txtBarcode.BackColor = Color.White;
            txtProfileID.BackColor = Color.White;
            txtFirstName.BackColor = Color.White;
            txtLastName.BackColor = Color.White;
            txtMiddleInitial.BackColor = Color.White;
            cmbgender.BackColor = Color.White;
            cmbCivilStatus.BackColor = Color.White;
            txtPhone.BackColor = Color.White;
            txtMobile.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtAddress.BackColor = Color.White;
            cmbProvince.BackColor = Color.White;
            txtSSSNumber.BackColor = Color.White;
            txtPhilhealthNumber.BackColor = Color.White;
            cmbPosition.BackColor = Color.White;
            cmbDepartment.BackColor = Color.White;
        }
        private void clearProfile()
        {
            txtProfileID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleInitial.Clear();
            cmbgender.Text = "";
            cmbCivilStatus.Text = "";
            txtPhone.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbProvince.Text = "";
            txtSSSNumber.Clear();
            txtPhilhealthNumber.Clear();
            cmbPosition.Text = "";
            cmbDepartment.Text = "";
            txtBarcode.Clear();
        }

        private void enableContact()
        {
            txtContactName.Enabled = true;
            txtPositionName.Enabled = true;
            txtPhoneNumber.Enabled = true;
            txtFirstMobile.Enabled = true;
            txtSecondMobile.Enabled = true;
            txtEmailAddress.Enabled = true;
            txtWebUrl.Enabled = true;
            txtFaxNumber.Enabled = true;
            dkpContactDateReg.Enabled = true;
        }

        private void disabledContact()
        {
            txtContactName.Enabled = false;
            txtPositionName.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtFirstMobile.Enabled = false;
            txtSecondMobile.Enabled = false;
            txtEmailAddress.Enabled = false;
            txtWebUrl.Enabled = false;
            txtFaxNumber.Enabled = false;
            dkpContactDateReg.Enabled = false;
        }

        private void whiteContact()
        {
            txtContactBarcode.BackColor = Color.White;
            txtContactId.BackColor = Color.White;
            txtContactName.BackColor = Color.White;
            txtPositionName.BackColor = Color.White;
            txtPhoneNumber.BackColor = Color.White;
            txtFirstMobile.BackColor = Color.White;
            txtSecondMobile.BackColor = Color.White;
            txtEmailAddress.BackColor = Color.White;
            txtWebUrl.BackColor = Color.White;
            txtFaxNumber.BackColor = Color.White;
        }

        private void clearContact()
        {
            txtContactBarcode.Clear();
            txtContactId.Clear();
            txtContactName.Clear();
            txtPositionName.Clear();
            txtPhoneNumber.Clear();
            txtFirstMobile.Clear();
            txtSecondMobile.Clear();
            txtEmailAddress.Clear();
            txtWebUrl.Clear();
            txtFaxNumber.Clear();
        }

        private void grayContact()
        {
            txtContactBarcode.BackColor = Color.Gray;
            txtContactId.BackColor = Color.Gray;
            txtContactName.BackColor = Color.Gray;
            txtPositionName.BackColor = Color.Gray;
            txtPhoneNumber.BackColor = Color.Gray;
            txtFirstMobile.BackColor = Color.Gray;
            txtSecondMobile.BackColor = Color.Gray;
            txtEmailAddress.BackColor = Color.Gray;
            txtWebUrl.BackColor = Color.Gray;
            txtFaxNumber.BackColor = Color.Gray;
        }

        private void whiteAddress()
        {
            txtBarcodeAddress.BackColor = Color.White;
            txtAddressID.BackColor = Color.White;
            txtBarangay.BackColor = Color.White;
            txtStreet.BackColor = Color.White;
            txtCity.BackColor = Color.White;
            txtZipCode.BackColor = Color.White;
            txtProvince.BackColor = Color.White;
            cmbCountry.BackColor = Color.White;
        }

        private void grayAddress()
        {
            txtBarcodeAddress.BackColor = Color.Gray;
            txtAddressID.BackColor = Color.Gray;
            txtBarangay.BackColor = Color.Gray;
            txtStreet.BackColor = Color.Gray;
            txtCity.BackColor = Color.Gray;
            txtZipCode.BackColor = Color.Gray;
            txtProvince.BackColor = Color.Gray;
            cmbCountry.BackColor = Color.Gray;
        }

        private void enabledAddress()
        {
            txtBarangay.Enabled = true;
            txtStreet.Enabled = true;
            txtCity.Enabled = true;
            txtZipCode.Enabled = true;
            txtProvince.Enabled = true;
            cmbCountry.Enabled = true;
            dkpDateRegister.Enabled = true;
        }

        private void disabledAddress()
        {
           
            txtBarangay.Enabled = false;
            txtStreet.Enabled = false;
            txtCity.Enabled = false;
            txtZipCode.Enabled = false;
            txtProvince.Enabled = false;
            cmbCountry.Enabled = false;
            dkpDateRegister.Enabled = false;
        }

        private void clearAddress()
        {
            txtBarcodeAddress.Clear();
            txtAddressID.Clear();
            txtBarangay.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtZipCode.Clear();
            txtProvince.Text = "";
            dkpDateRegister.Value = DateTime.Now;
        }

        private void addProfile()
        {
            var address = new Address()
            {
                barangay = txtBarangay.Text.Trim(' '),
                street = txtStreet.Text.Trim(' '),
                city = txtCity.Text.Trim(' '),
                province = cmbProvince.Text.Trim(' '),
                zip_code = txtZipCode.Text.Trim(' '),
                country = "Philippines",
            };
            var addressResult = RepositoryEntity.AddEntity<Address>(address);
            var contact = new Contact()
            {
                contact_name = txtLastName.Text.Trim(' ') + ", " + txtFirstName.Text.Trim(' ') + " " + txtMiddleInitial.Text.Trim(' ') + ".",
                contact_code = txtContactBarcode.Text,
                position = cmbPosition.Text.Trim(' '),
                telephone_number = txtPhone.Text.Trim(' '),
                mobile_number = txtMobile.Text.Trim(' '),
                mobile_secondary = txtSecondMobile.Text.Trim(' '),
                email_address = txtEmail.Text.Trim(' '),
                web_url = txtWebUrl.Text.Trim(' '),
                fax_number = txtFaxNumber.Text.Trim(' '),
                date_register = dkpContactDateReg.Value.Date
            };
            var contactResult = RepositoryEntity.AddEntity<Contact>(contact);
            Thread.Sleep(1000);
            var profile = new Profile()
            {
                profile_code = lblEmpCode.Text.Trim(),
                first_name = txtFirstName.Text.Trim(),
                last_name = txtLastName.Text.Trim(),
                middle_initial = txtMiddleInitial.Text.Trim(),
                gender = cmbgender.Text.Trim(),
                birthdate = dkpBirthdate.Value.Date,
                civil_status = cmbCivilStatus.Text.Trim(),
                contact_id = (int)contactResult,
                address_id = (int)addressResult,
                sss_number = txtSSSNumber.Text.Trim(),
                phil_health = txtPhilhealthNumber.Text.Trim(),
                position = cmbPosition.Text.Trim(),
                department_id = 1,
                hire_date = dkpDateHired.Value.Date,
                date_register = dkpDateRegistered.Value.Date,
                user_id = 1
            };
            var profileResult = RepositoryEntity.AddEntity<Profile>(profile);
        }

        private void updateProfile()
        {
            // use RepositoryEntity.Update
        }

        private void deleteProfile()
        {
            // use RepositoryEntity.Delete
        }

        private void gridEmployee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView(sender);
        }

        private void gridAddress_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewAddress(sender);
        }
        private void gridContact_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewContact(sender);
        }

        private void gridEmployee_RowClick(object sender, RowClickEventArgs e)
        {
            whiteProfile();
            gridView(sender);
        }

        private void gridEmployee_LostFocus(object sender, EventArgs e)
        {
            grayProfile();
        }

        private void generateProfileCode()
        {
            var profileId = FetchUtils.getLastProfileId();
            var alphaNumeric = new GenerateAlpaNum("P", 3, profileId);
            alphaNumeric.Increment();
            txtBarcode.Text = alphaNumeric.ToString();
        }

        private void generateAddressCode()
        {
            var addressId = FetchUtils.getLastAddressId();
            var alphaNumeric = new GenerateAlpaNum("A", 3, addressId);
            alphaNumeric.Increment();
            txtBarcodeAddress.Text = alphaNumeric.ToString();
        }

        private void generateContactCode()
        {
            var contactId = FetchUtils.getLastContactId();
            var alphaNumeric = new GenerateAlpaNum("P", 3, contactId);
            alphaNumeric.Increment();
            txtContactBarcode.Text = alphaNumeric.ToString();
        }

        //STRING MANIPULATION
        private void txtFNM_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtFirstName, txtLastName, "First Name", Messages.TitleEmployees);
        }
        private void txtFNM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtFirstName, txtLastName, "First Name", Messages.TitleEmployees);
            }
        }
        
        private void txtLSN_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtLastName, txtMiddleInitial, "Last Name", Messages.TitleEmployees);
        }
        private void txtLSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtLastName, txtMiddleInitial, "Last Name", Messages.TitleEmployees);
            }
        }
        private void txtMID_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtMiddleInitial, cmbgender, "Middle Initial", Messages.TitleEmployees);
        }

        private void txtMID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtMiddleInitial, cmbgender, "Middle Initial", Messages.TitleEmployees);
            }
        }
        private void cmbGEN_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbgender, dkpBirthdate, "Gender", Messages.TitleEmployees);
        }
        private void cmbGEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbgender, dkpBirthdate, "Gender", Messages.TitleEmployees); 
                
            }
        }
        private void dkpDOB_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpBirthdate, cmbCivilStatus, "Date of Birth", Messages.TitleEmployees);
        }
        private void dkpDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpBirthdate, cmbCivilStatus, "Date of Birth", Messages.TitleEmployees);
            }
        }
        private void cmbCIV_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbCivilStatus, txtPhone, "Civil Status", Messages.TitleEmployees);
        }
        private void cmbCIV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbCivilStatus, txtPhone, "Civil Status", Messages.TitleEmployees);
            }
        }
        private void txtPON_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtPhone, txtMobile, "Phone Number", Messages.TitleEmployees);
        }

        private void txtPON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtPhone, txtMobile, "Phone Number", Messages.TitleEmployees);
                txtFirstMobile.Text = txtPhone.Text.Trim(' ');
            }
        }
        private void txtMON_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtMobile, txtEmail, "Mobile Number", Messages.TitleEmployees);
        }
        private void txtMON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtMobile, txtEmail, "Mobile Number", Messages.TitleEmployees);
                txtFirstMobile.Text = txtMobile.Text.Trim(' ');
            }
        }
        private void txtEML_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtEmail, txtAddress, "Email Address", Messages.TitleEmployees);
        }
        private void txtEML_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtEmail, txtAddress, "Email Address", Messages.TitleEmployees);
                txtEmailAddress.Text = txtEmail.Text.Trim(' ');
            }
        }
        private void txtADD_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtAddress, cmbProvince, "Address", Messages.TitleEmployees);
        }
        private void txtADD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtAddress, cmbProvince, "Address", Messages.TitleEmployees);
                txtStreet.Text = txtAddress.Text.Trim(' ');
            }
        }
        private void cmbPRV_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbProvince, txtSSSNumber, "Provencial Address", Messages.TitleEmployees);
        }
        private void cmbPRV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbProvince, txtSSSNumber, "Provencial Address", Messages.TitleEmployees);
                txtProvince.Text = cmbProvince.Text;
            }
        }
        private void txtSSS_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtSSSNumber, txtPhilhealthNumber, "SSS Number", Messages.TitleEmployees);
        }
        private void txtSSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSSSNumber, txtPhilhealthNumber, "SSS Number", Messages.TitleEmployees);
            }
        }
        private void txtPHH_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtPhilhealthNumber, cmbPosition, "PhilHealth Number", Messages.TitleEmployees);
        }
        private void txtPHH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtPhilhealthNumber, cmbPosition, "PhilHealth Number", Messages.TitleEmployees);
            }
        }
        private void cmbPOS_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbPosition, cmbDepartment, "Position", Messages.TitleEmployees);
        }

        private void cmbPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbPosition, cmbDepartment, "Position", Messages.TitleEmployees);
            }
        }
        private void cmbDEP_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbDepartment, dkpDateHired, "Department", Messages.TitleEmployees);
        }
        private void cmbDEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbDepartment, dkpDateHired, "Department", Messages.TitleEmployees);
            }
        }
        private void dkpHIR_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpDateHired, dkpDateRegistered, "Hire Date", Messages.TitleEmployees);
        }

        private void dkpHIR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateHired, dkpDateRegistered, "Hire Date", Messages.TitleEmployees);
            }
        }
        private void bntUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate();
        }
        private void bntInsert_Click(object sender, EventArgs e)
        {
            buttonInsert();
        }
        private void bntSave_Click(object sender, EventArgs e)
        {
            buttonSave();
        }
        private void bntCancel_Click(object sender, EventArgs e)
        {
            buttonCancel();
        }
        private void bntClear_Click(object sender, EventArgs e)
        {
            buttonClear();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {

        }
        private void bntHome_Click(object sender, EventArgs e)
        {
           HomePage();
        }

        private void dkpREG_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpDateRegistered, bntSave, "Date Register", Messages.TitleEmployees);
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateRegistered, bntSave, "Date Register", Messages.TitleEmployees);
            }
        }

        private void xtraControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraContact) {
               
                bindContact();
                enableContact();
                whiteContact();
                disabledAddress();
                disabledProfile();
                grayAddress();
                grayProfile();
                txtContactName.Text = txtFirstName.Text + " " + txtMiddleInitial.Text + " " + txtLastName.Text;
                txtPositionName.Text = cmbPosition.Text;
                gridContact.Focus();
            }
            if(e.Page == xtraProfile)
            {
              
                enabledProfile();
                disabledContact();
                disabledAddress();
                whiteProfile();
                grayContact();
                grayAddress();
                gridProfile.Focus();
            }
            if(e.Page == xtraAddress)
            {
                enabledAddress();
                bindAddress();
                whiteAddress();
                grayProfile();
                grayContact();
                disabledContact();
                gridAddress.Focus();
            }
        }

        private void bindProfileList()
        {
            gridCtlProfile.Update();
            try
            {
                gridCtlProfile.DataBindings.Clear();

                var list = _profileList.Select(p => new
                {
                    Id = p.profile_id,
                    Code = p.profile_code,
                    LName = p.last_name,
                    FName = p.first_name,
                    Mid = p.middle_initial,
                    Sex = p.gender,
                    DOB = p.birthdate,
                    Status = p.civil_status,
                    TelNo = p.telephone_number,
                    Mobile = p.mobile_number,
                    Email = p.email_address,
                    Brgy = p.barangay,
                    PRV = p.province,
                    SSS = p.sss_number,
                    PH = p.phil_health,
                    Pos = p.position,
                    Dept = p.department_name,
                    Hire = p.hire_date,
                    Reg = p.date_register
                }).ToList();
                gridCtlProfile.DataSource = list;
            }
            catch (Exception)
            {
                gridCtlProfile.EndUpdate();
                throw;
            }
        }

        private void bindContact()
        {
            var profileId = txtProfileID.Text.Trim(' ');
            _profile = _profileList.FirstOrDefault(p => p.profile_id == int.Parse(profileId));
            if (_profile != null)
            {
                gridControlContact.DataSource = null;
                gridControlContact.DataSource = "";
                gridContact.Columns.Clear();
                var list = EnumerableUtils.getContactList(_profile.contact_id).ToList();
                gridControlContact.DataSource = list.Select(p => new {
                    Id = p.contact_id,
                    Barcode = p.contact_code,
                    Name = p.contact_name,
                    Position = p.position,
                    Telephone = p.telephone_number,
                    MobileNo1 = p.mobile_number,
                    MobileNo2 = p.mobile_secondary,
                    EmailAdd = p.email_address,
                    WebSite = p.web_url,
                    FaxNo = p.fax_number,
                    Registered = p.date_register
                });
                gridControlContact.Update();
            }
        }

        private void bindAddress()
        {
            var profileId = txtProfileID.Text.Trim(' ');
            _profile = _profileList.FirstOrDefault(p => p.profile_id == int.Parse(profileId));
            if (_profile != null)
            {
                gridControlAddress.DataSource = null;
                gridControlAddress.DataSource = "";
                gridAddress.Columns.Clear();
                var list = EnumerableUtils.getAddressList(_profile.address_id).ToList();
                gridControlAddress.DataSource = list.Select(p => new {
                    Id = p.address_id,
                    Barangay = p.barangay,
                    Street = p.street,
                    City = p.city,
                    Province = p.province,
                    ZipCode = p.zip_code,
                    Country = p.country
                }).ToList();
                gridControlAddress.Update();
            }
        }

        private void gridViewAddress(object sender)
        {
            if(gridAddress.RowCount > 0)
            {
                var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                txtAddressID.Text = id;
                txtBarcodeAddress.Text = "AS001";
                txtBarangay.Text = ((GridView)sender).GetFocusedRowCellValue("Barangay").ToString();
                txtStreet.Text = ((GridView)sender).GetFocusedRowCellValue("Street").ToString();
                txtCity.Text = ((GridView)sender).GetFocusedRowCellValue("City").ToString();
                txtZipCode.Text = ((GridView)sender).GetFocusedRowCellValue("ZipCode").ToString();
                txtProvince.Text = ((GridView)sender).GetFocusedRowCellValue("Province").ToString();
                cmbCountry.Text = ((GridView)sender).GetFocusedRowCellValue("Country").ToString();
            }
        }

        private void gridViewContact(object sender)
        {
            if (gridContact.RowCount > 0) {
                var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                txtContactId.Text = id;
                txtContactBarcode.Text = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                txtContactName.Text = ((GridView)sender).GetFocusedRowCellValue("Name").ToString();
                txtPositionName.Text = ((GridView)sender).GetFocusedRowCellValue("Position").ToString();
                txtPhoneNumber.Text = ((GridView)sender).GetFocusedRowCellValue("Telephone").ToString();
                txtFirstMobile.Text = ((GridView)sender).GetFocusedRowCellValue("MobileNo1").ToString();
                txtSecondMobile.Text = ((GridView)sender).GetFocusedRowCellValue("MobileNo2").ToString();
                txtEmailAddress.Text = ((GridView)sender).GetFocusedRowCellValue("EmailAdd").ToString();
                txtWebUrl.Text = ((GridView)sender).GetFocusedRowCellValue("WebSite").ToString();
                txtFaxNumber.Text = ((GridView)sender).GetFocusedRowCellValue("FaxNo").ToString();
                dkpContactDateReg.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Registered");
            }
        }

        private void gridView(object sender)
        {
            var grid = gridProfile;
            if (grid.RowCount > 0)
                try
                {
                    var profileIdz = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    txtProfileID.Text = profileIdz;
                    txtBarcode.Text = ((GridView)sender).GetFocusedRowCellValue("Code").ToString();
                    txtFirstName.Text = ((GridView)sender).GetFocusedRowCellValue("FName").ToString();
                    txtLastName.Text = ((GridView)sender).GetFocusedRowCellValue("LName").ToString();
                    txtMiddleInitial.Text = ((GridView)sender).GetFocusedRowCellValue("Mid").ToString();
                    cmbgender.Text = ((GridView)sender).GetFocusedRowCellValue("Sex").ToString();
                    dkpBirthdate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("DOB");
                    cmbCivilStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status").ToString();
                    txtPhone.Text = ((GridView)sender).GetFocusedRowCellValue("TelNo").ToString();
                    txtMobile.Text = ((GridView)sender).GetFocusedRowCellValue("Mobile").ToString();
                    txtEmail.Text = ((GridView)sender).GetFocusedRowCellValue("Email").ToString();
                    txtAddress.Text = ((GridView)sender).GetFocusedRowCellValue("Brgy").ToString();
                    cmbProvince.Text = ((GridView)sender).GetFocusedRowCellValue("PRV").ToString();
                    txtSSSNumber.Text = ((GridView)sender).GetFocusedRowCellValue("SSS").ToString();
                    txtPhilhealthNumber.Text = ((GridView)sender).GetFocusedRowCellValue("PH").ToString();
                    cmbPosition.Text = ((GridView)sender).GetFocusedRowCellValue("Pos").ToString();
                    cmbDepartment.Text = ((GridView)sender).GetFocusedRowCellValue("Dept").ToString();
                    dkpDateHired.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Hire");
                    dkpDateRegistered.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Reg");
                    txtProfileID.Text = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

    }
}
