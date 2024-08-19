using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Inventory.MainForm
{
    public partial class FrmRegistration : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del;
        private readonly int _userId;
        private ViewProfile _profile;
        private IEnumerable<ViewProfile> _profileList;
        private IEnumerable<ProfileImages> _image_list;
        public FirmMain Main
        {
            get { return _main; }

            set { _main = value; }
        }
        public FrmRegistration(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            splashManager.ShowWaitForm();
            _profileList = EnumerableUtils.getProfileList();
            _image_list = EnumerableUtils.getProfileImgList();
            splashManager.CloseWaitForm();
            bindProfileList();
            _add = false;
            _edt = false;
            _del = false;
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

        private void bntBrowseImage_Click(object sender, EventArgs e)
        {
            browseProfileImage();
        }
        private void bntSaveImages_Click(object sender, EventArgs e)
        {
            saveProfileImage();
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
            if (_add && !_edt && !_del)
            {
                splashManager.ShowWaitForm();
                addProfile();
                ButtonSav();
                disabledProfile();
                grayProfile();
                grayContact();
                grayAddress();
                clearAddress();
                clearContact();
                clearProfile();
            }
            if (!_add && _edt && !_del)
            {
                splashManager.ShowWaitForm();
                updateProfile();
                ButtonSav();
                disabledProfile();
                grayProfile();
                grayContact();
                grayAddress();
                clearAddress();
                clearContact();
                clearProfile();
            }
            if (!_add && !_edt && _del)
            {
                deleteProfile();
                ButtonSav();
                disabledProfile();
                grayProfile();
                clearProfile();
            }
            xtraControl.SelectedTabPage = xtraProfile;
            gridCtlProfile.Enabled = true;
            bindProfileList();
            _add = false;
            _edt = false;
            _del = false;
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
            _add = false;
            _edt = false;
            _del = false;
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
                contact_name = txtLastName.Text.Trim(' ') + ", " + txtFirstName.Text.Trim(' ') + " " + txtMiddleInitial.Text.Trim(' ') + " " + txtLastName.Text,
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
            Thread.Sleep(50);
            var profile = new Profile()
            {
                profile_code = txtBarcode.Text.Trim(' '),
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
                user_id = _userId
            };
            var profileResult = RepositoryEntity.AddEntity<Profile>(profile);
            var profileCode = txtBarcode.Text.Trim(' ');
            if (profileResult > 0 && profileCode.Length > 0)
            {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(1, "Profile barcode:" + profileCode + " successfully added!", "ADD PROFILE");
                _profileList = EnumerableUtils.getProfileList();
            }
            else {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "Profile barcode:" + profileCode + " was not added to profile!", "INSERT FAILED");
            }
        }

        private void updateProfile()
        {
            var profile = txtProfileID.Text.Trim();
            var contactId = txtContactId.Text.Trim();
            var addressId = txtAddressID.Text.Trim();
            
            if (profile.Length > 0 && contactId.Length > 0 && addressId.Length > 0)
            {
                var profileId = int.Parse(profile);

                    int addressResult = RepositoryEntity.UpdateEntity<Address>(int.Parse(addressId), entity => {
                        entity.barangay = txtBarangay.Text.Trim(' ');
                        entity.street = txtStreet.Text.Trim(' ');
                        entity.city = txtCity.Text.Trim(' ');
                        entity.province = cmbProvince.Text.Trim(' ');
                        entity.zip_code = txtZipCode.Text.Trim(' ');
                        entity.country = "Philippines";
                    });

                    int contactResult = RepositoryEntity.UpdateEntity<Contact>(int.Parse(contactId), entity => {
                    entity.contact_name = txtLastName.Text.Trim(' ') + ", " + txtFirstName.Text.Trim(' ') + " " + txtMiddleInitial.Text.Trim(' ') + " " + txtLastName.Text;
                    entity.contact_code = txtContactBarcode.Text;
                    entity.position = cmbPosition.Text.Trim(' ');
                    entity.telephone_number = txtPhone.Text.Trim(' ');
                    entity.mobile_number = txtMobile.Text.Trim(' ');
                    entity.mobile_secondary = txtSecondMobile.Text.Trim(' ');
                    entity.email_address = txtEmail.Text.Trim(' ');
                    entity.web_url = txtWebUrl.Text.Trim(' ');
                    entity.fax_number = txtFaxNumber.Text.Trim(' ');
                    entity.date_register = dkpContactDateReg.Value.Date;
                });
                
                int profileResult = RepositoryEntity.UpdateEntity<Profile>(profileId, entity => {
                    entity.profile_code = txtBarcode.Text.Trim(' ');
                    entity.first_name = txtFirstName.Text.Trim();
                    entity.last_name = txtLastName.Text.Trim();
                    entity.middle_initial = txtMiddleInitial.Text.Trim();
                    entity.gender = cmbgender.Text.Trim();
                    entity.birthdate = dkpBirthdate.Value.Date;
                    entity.civil_status = cmbCivilStatus.Text.Trim();
                    entity.contact_id = int.Parse(contactId);
                    entity.address_id = int.Parse(addressId);
                    entity.sss_number = txtSSSNumber.Text.Trim();
                    entity.phil_health = txtPhilhealthNumber.Text.Trim();
                    entity.position = cmbPosition.Text.Trim();
                    entity.department_id = 1;
                    entity.hire_date = dkpDateHired.Value.Date;
                    entity.date_register = dkpDateRegistered.Value.Date;
                    entity.user_id = _userId;
                });

                if (addressResult > 0 && contactResult > 0 && profileResult > 0)
                {
                    splashManager.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Profile barcode:" + txtBarcode.Text.Trim(' ') + " successfully updated!", "UPDATE PROFILE");
                    _profileList = EnumerableUtils.getProfileList();
                } else
                {
                    splashManager.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Profile barcode:" + txtBarcode.Text.Trim(' ') + " was not updated to profile!", "UPDATE FAILED");
                }
            }
        }

        private void browseProfileImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string fileNameAndExtension = getfileExntesion(selectedFilePath);
                    txtProfileImgFileName.Text = fileNameAndExtension;
                    bntSaveImages.Enabled = true;
                    bntBrowseImage.Enabled = false;
                }
            }
        }

        private void saveProfileImage()
        {
            splashManager.ShowWaitForm();
            var filePathLocation = txtProfileImgFileName.Text.Trim(' ');
            var filePath = ExtractFileName(filePathLocation);
            var img = new ProfileImages()
            {
                image_code = txtProfileImgBarcode.Text.Trim(' '),
                title = txtProfileImgTitle.Text.Trim(' '),
                img_type = cmbProfileImgType.Text.Trim(' '),
                img_location = filePath,
                created_on = dkpImgCreadOn.Value.Date,
                updated_on = dkpImgUpdatedOn.Value.Date
            };
            var result = RepositoryEntity.AddEntity<ProfileImages>(img);
            if (result > 0)
            {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(1, "Profile image: " + txtProfileImgTitle.Text.Trim(' ') + " " + Messages.SuccessInsert,
                 Messages.TitleSuccessInsert);
                _image_list = EnumerableUtils.getProfileImgList();
                bindProfileImgList();
            }
            else
            {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "Profile image: " + txtProfileImgTitle.Text.Trim(' ') + " " + Messages.ErrorInsert,
                 Messages.TitleFailedInsert);
            }
        }

        private string ExtractFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void deleteProfile()
        {
            // use RepositoryEntity.Delete
        }

        private void gridEmployee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewProfile(sender);
        }

        private void gridAddress_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewAddress(sender);
        }
        private void gridContact_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewContact(sender);
        }
        private void gridImage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewImages(sender);
        }

        private void gridEmployee_RowClick(object sender, RowClickEventArgs e)
        {
            whiteProfile();
            gridViewProfile(sender);
        }

        private void gridEmployee_LostFocus(object sender, EventArgs e)
        {
            grayProfile();
        }

        private void generateImageCode()
        {
            var profileId = FetchUtils.getLastProfileImageId();
            var alphaNumeric = new GenerateAlpaNum("P", 3, profileId);
            alphaNumeric.Increment();
            txtProfileImgBarcode.Text = alphaNumeric.ToString();
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
        private void txtFNM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtFirstName, txtLastName, "First Name", Messages.TitleEmployees);
            }
        }
        private void txtLSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtLastName, txtMiddleInitial, "Last Name", Messages.TitleEmployees);
            }
        }
        private void txtMID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtMiddleInitial, cmbgender, "Middle Initial", Messages.TitleEmployees);
            }
        }
        private void cmbGEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbgender, dkpBirthdate, "Gender", Messages.TitleEmployees); 
                
            }
        }
        private void dkpDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpBirthdate, cmbCivilStatus, "Date of Birth", Messages.TitleEmployees);
            }
        }
        private void cmbCIV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbCivilStatus, txtPhone, "Civil Status", Messages.TitleEmployees);
            }
        }

        private void txtPON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtPhone, txtMobile, "Phone Number", Messages.TitleEmployees);
                txtFirstMobile.Text = txtPhone.Text.Trim(' ');
            }
        }
        private void txtMON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtMobile, txtEmail, "Mobile Number", Messages.TitleEmployees);
                txtFirstMobile.Text = txtMobile.Text.Trim(' ');
            }
        }
        private void txtEML_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtEmail, txtAddress, "Email Address", Messages.TitleEmployees);
                txtEmailAddress.Text = txtEmail.Text.Trim(' ');
            }
        }
        private void txtADD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtAddress, cmbProvince, "Address", Messages.TitleEmployees);
                txtStreet.Text = txtAddress.Text.Trim(' ');
            }
        }
        private void cmbPRV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbProvince, txtSSSNumber, "Provencial Address", Messages.TitleEmployees);
                txtProvince.Text = cmbProvince.Text;
            }
        }
        private void txtSSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSSSNumber, txtPhilhealthNumber, "SSS Number", Messages.TitleEmployees);
            }
        }
        private void txtPHH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtPhilhealthNumber, cmbPosition, "PhilHealth Number", Messages.TitleEmployees);
            }
        }
        private void cmbPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbPosition, cmbDepartment, "Position", Messages.TitleEmployees);
            }
        }
        private void cmbDEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbDepartment, dkpDateHired, "Department", Messages.TitleEmployees);
            }
        }

        private void dkpHIR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateHired, dkpDateRegistered, "Hire Date", Messages.TitleEmployees);
            }
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                xtraControl.SelectedTabPage = xtraAddress;
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




        private ProfileImages searchProfileImg(string param)
        {
            return _image_list.FirstOrDefault(img => img.image_code == param);
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
            if(e.Page == xtraImage)
            {
                var firstName = txtFirstName.Text.Trim(' ');
                var middleName = txtMiddleInitial.Text.Trim(' ');
                var lastName = txtLastName.Text.Trim(' ');
                txtProfileImgTitle.Text = firstName + " " + middleName + " " + lastName;
                txtProfileImgBarcode.Text = txtBarcode.Text.Trim(' ');
            }
        }

        private void bindProfileImgList()
        {
            gridImageControl.DataSource = null;
            gridImageControl.DataSource = "";
            gridImage.Columns.Clear();
            var list = _image_list.Select(p => new {
                Id = p.image_id,
                Barcode = p.image_code,
                Title = p.title,
                ImageType = p.img_type,
                Location = p.img_location,
                Created = p.created_on,
                Updated = p.updated_on
            }).ToList();
            gridImageControl.DataSource = list;
            gridImageControl.Update();
            if (gridImage.RowCount > 0)
                gridImage.Columns[0].Width = 50;
            gridImage.Columns[1].Width = 120;
            gridImage.Columns[2].Width = 200;
            gridImage.Columns[3].Width = 140;
            gridImage.Columns[4].Width = 180;
            gridImage.Columns[5].Width = 100;
            gridImage.Columns[6].Width = 100;
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
                    Name = p.first_name + " " + p.middle_initial + " " + p.last_name,
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
                    Hire = p.hire_date,
                    Reg = p.date_register,
                    Dept = p.department_name
                }).ToList();
                gridCtlProfile.DataSource = list;
               if (gridProfile.RowCount > 0)
                {
                    gridProfile.Columns[0].Width = 40;
                    gridProfile.Columns[1].Width = 50;
                    gridProfile.Columns[2].Width = 150;
                    gridProfile.Columns[16].Width = 40;
                }
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
            if (profileId.Length > 0)
            {
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
        }

        private void bindAddress()
        {
            var profileId = txtProfileID.Text.Trim(' ');
            if (profileId.Length > 0) {
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

        private string getfileExntesion(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void gridViewImages(object sender)
        {
            if (gridImage.RowCount > 0)
            {
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                        var img = searchProfileImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgProfileImages.ImageLocation = location;
                        }
                        else
                            imgProfileImages.ImageLocation = ConstantUtils.defaultImgLocation + "empty-image.jpg";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
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

        private void gridViewProfile(object sender)
        {
            var grid = gridProfile;
            if (grid.RowCount > 0)
                try
                {
                    txtProfileID.Text = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("Code").ToString();
                    var profileId = txtProfileID.Text.Trim(' ');
                    if (!_add && !_edt && !_del) {
                        _profile = _profileList.FirstOrDefault(p => p.profile_id == int.Parse(profileId));
                        txtFirstName.Text = _profile.first_name;
                        txtLastName.Text = _profile.last_name;
                        txtMiddleInitial.Text = _profile.middle_initial;
                        cmbDepartment.Text = _profile.department_name;
                    }
                    txtBarcode.Text = barcode;
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
                    dkpDateHired.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Hire");
                    dkpDateRegistered.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Reg");
                    var img = searchProfileImg(barcode);
                    var imgLocation = img.img_location;
                    if (imgLocation.Length > 0)
                    {
                        var location = ConstantUtils.defaultImgLocation + imgLocation;
                        imgProfile.ImageLocation = location;
                    }
                    else
                        imgProfile.ImageLocation = ConstantUtils.defaultImgLocation + "empty-image.jpg";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
    }
}
