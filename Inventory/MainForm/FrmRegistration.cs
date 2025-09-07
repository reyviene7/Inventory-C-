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
        private readonly int _userTyp;
        private ViewProfile _profile;
        private IEnumerable<ViewProfile> _profileList;
        private IEnumerable<ProfileImages> _image_list;
        public FirmMain Main
        {
            get { return _main; }

            set { _main = value; }
        }
        public FrmRegistration(int userId, int userTy)
        {
            _userId = userId;
            _userTyp = userTy;
            if (_userTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
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
            bindRefreshed();
            xtraControl_SelectedPageChanged(xtraProfile, null);
            splashManager.CloseWaitForm();
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
            var code = txtProfileImgBarcode.Text.Trim();
            var title = txtProfileImgTitle.Text.Trim();
            var imgType = cmbProfileImgType.Text.Trim();
            var imgLocation = txtProfileImgFileName.Text.Trim();

            if (code.Length > 0 && title.Length > 0 && imgType.Length > 0 && imgLocation.Length > 0)
            {
                var result = saveProfileImage();
                if (result > 0)
                {
                    if (imgProfile.Image != null)
                    {
                        imgProfile.Image.Dispose();
                        imgProfile.Image = null;
                    }

                    bntBrowseImage.Enabled = true;
                    txtProfileImgFileName.Text = "";
                    txtProfileImgTitle.Text = "";
                }
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Please fill all the entries!", Messages.TitleFailedInsert);
            }
        }


        private void buttonInsert()
        {
            ButtonAdd();
            enabledProfile();
            enableContact();
            enabledAddress();
            whiteProfile();
            whiteContact();
            whiteAddress();
            clearProfile();
            clearAddress();
            clearContact();
            BindDepartment();
            generateProfileCode();
            generateAddressCode();
            generateContactCode();
            txtFirstName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridCtlProfile.Enabled = false;
            gridControlAddress.Enabled = false;
            gridControlContact.Enabled = false;
        }
        private void buttonUpdate()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            enabledProfile();
            enabledAddress();
            enableContact();
            whiteProfile();
            whiteAddress();
            whiteContact();
            gridCtlProfile.Enabled = false;
            gridControlAddress.Enabled = false;
            gridControlContact.Enabled = false;
        }
        private void ButDel()
        {
            ButtonDel();
            disabledProfile();
            disabledAddress();
            disabledContact();
            whiteProfile();
            whiteAddress();
            whiteContact();
            _add = false;
            _edt = false;
            _del = true;
            gridCtlProfile.Enabled = false;
            gridControlAddress.Enabled = false;
            gridControlContact.Enabled = false;
        }
        private void buttonSave()
        {
            splashManager.ShowWaitForm();
            if (_add && _edt == false && _del == false)
            {
                addProfile();
                ButtonSav();
                disabledProfile();
                disabledAddress();
                disabledContact();
                grayProfile();
                grayContact();
                grayAddress();
                clearAddress();
                clearContact();
                clearProfile();
                bindRefreshed();
            }
            if (_add == false && _edt && _del == false)
            {
                updateProfile();
                ButtonSav();
                disabledProfile();
                disabledAddress();
                disabledContact();
                grayProfile();
                grayContact();
                grayAddress();
                clearAddress();
                clearContact();
                clearProfile();
                bindRefreshed();
            }
            if (_add == false && _edt == false && _del)
            {
                deleteProfile();
                ButtonSav();
                disabledProfile();
                disabledAddress();
                disabledContact();
                grayProfile();
                grayContact();
                grayAddress();
                clearAddress();
                clearContact();
                clearProfile();
                bindRefreshed();
            }
            _add = false;
            _edt = false;
            _del = false;
            xtraControl.SelectedTabPage = xtraProfile;
            gridCtlProfile.Enabled = true;
            cmbgender.DataBindings.Clear();
            cmbCivilStatus.DataBindings.Clear();
            cmbProvince.DataBindings.Clear();
            cmbDepartment.DataBindings.Clear();
            cmbPosition.DataBindings.Clear();
            imgProfile.DataBindings.Clear();
            imgProfile.Image = null;
            imgProfileImages.DataBindings.Clear();
            imgProfileImages.Image = null;
            bindRefreshed();
        }

        private void buttonClear()
        {
            ButtonClr();
            disabledProfile();
            disabledContact();
            disabledAddress();
            whiteProfile();
            whiteContact();
            whiteAddress();
            clearProfile();
            clearAddress();
            clearContact();
            gridCtlProfile.Enabled = true;
            gridControlAddress.Enabled = true;
            gridControlContact.Enabled = true;
            int focusedRowHandle = gridProfile.FocusedRowHandle;
            if (focusedRowHandle >= 0)
            {
                gridEmployee_FocusedRowChanged(
                    gridProfile,
                    new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                        focusedRowHandle,
                        focusedRowHandle
                    )
                );
            }
        }

        private void buttonCancel()
        {
            _add = false;
            _edt = false;
            _del = false;
            ButtonCan();
            disabledProfile();
            disabledAddress();
            disabledContact();
            grayAddress();
            grayContact();
            grayProfile();
            clearProfile();
            clearAddress();
            clearContact();
            gridCtlProfile.Enabled = true;
            gridControlAddress.Enabled = true;
            gridControlContact.Enabled = true;
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
                department_id = FetchUtils.getDepartment(cmbDepartment.Text),
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
                bindRefreshed();
            }
            else {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "Profile barcode:" + profileCode + " was not added to profile!", "INSERT FAILED");
            }
        }

        private void updateProfile()
        {
            int profileId, contactId, addressId;
            bool validProfile = int.TryParse(txtProfileID.Text.Trim(), out profileId);
            bool validContact = int.TryParse(txtContactId.Text.Trim(), out contactId);
            bool validAddress = int.TryParse(txtAddressID.Text.Trim(), out addressId);

            if (!validProfile)
            {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "Invalid Profile ID.", "UPDATE FAILED");
                return;
            }

            try
            {
                int deptId = FetchUtils.getDepartment(cmbDepartment.Text.Trim());

                // Update Address (if address ID is valid)
                int addressResult = 1;
                if (validAddress)
                {
                    addressResult = RepositoryEntity.UpdateEntity<Address>(addressId, entity =>
                    {
                        entity.barangay = txtBarangay.Text.Trim();
                        entity.street = txtStreet.Text.Trim();
                        entity.city = txtCity.Text.Trim();
                        entity.province = cmbProvince.Text.Trim();
                        entity.zip_code = txtZipCode.Text.Trim();
                        entity.country = "Philippines";
                    });
                }

                // Update Contact (if contact ID is valid)
                int contactResult = 1;
                if (validContact)
                {
                    contactResult = RepositoryEntity.UpdateEntity<Contact>(contactId, entity =>
                    {
                        entity.contact_name = $"{txtLastName.Text.Trim()}, {txtFirstName.Text.Trim()} {txtMiddleInitial.Text.Trim()}";
                        entity.contact_code = txtContactBarcode.Text.Trim();
                        entity.position = cmbPosition.Text.Trim();
                        entity.telephone_number = txtPhone.Text.Trim();
                        entity.mobile_number = txtMobile.Text.Trim();
                        entity.mobile_secondary = txtSecondMobile.Text.Trim();
                        entity.email_address = txtEmail.Text.Trim();
                        entity.web_url = txtWebUrl.Text.Trim();
                        entity.fax_number = txtFaxNumber.Text.Trim();
                        entity.date_register = dkpContactDateReg.Value.Date;
                    });
                }

                // Update Profile (always done)
                int profileResult = RepositoryEntity.UpdateEntity<Profile>(profileId, entity =>
                {
                    entity.profile_code = txtBarcode.Text.Trim();
                    entity.first_name = txtFirstName.Text.Trim();
                    entity.last_name = txtLastName.Text.Trim();
                    entity.middle_initial = txtMiddleInitial.Text.Trim();
                    entity.gender = cmbgender.Text.Trim();
                    entity.birthdate = dkpBirthdate.Value.Date;
                    entity.civil_status = cmbCivilStatus.Text.Trim();
                    entity.contact_id = validContact ? contactId : 0;
                    entity.address_id = validAddress ? addressId : 0;
                    entity.sss_number = txtSSSNumber.Text.Trim();
                    entity.phil_health = txtPhilhealthNumber.Text.Trim();
                    entity.position = cmbPosition.Text.Trim();
                    entity.department_id = deptId;
                    entity.hire_date = dkpDateHired.Value.Date;
                    entity.date_register = dkpDateRegistered.Value.Date;
                    entity.user_id = _userId;
                });

                splashManager.CloseWaitForm(); // ✅ Close BEFORE showing notification

                if (profileResult > 0 && addressResult > 0 && contactResult > 0)
                {
                    PopupNotification.PopUpMessages(1, $"Profile barcode: {txtBarcode.Text.Trim()} successfully updated!", "UPDATE PROFILE");
                    _profileList = EnumerableUtils.getProfileList();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, $"Profile barcode: {txtBarcode.Text.Trim()} was not fully updated!", "UPDATE WARNING");
                }
            }
            catch (Exception ex)
            {
                splashManager.CloseWaitForm(); // ✅ Ensure it's closed even on error
                PopupNotification.PopUpMessages(0, $"Error: {ex.Message}", "UPDATE FAILED");
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

                    if (imgProfileImages.Image != null)
                    {
                        imgProfileImages.Image.Dispose();
                        imgProfileImages.Image = null;
                    }

                    try
                    {
                        using (FileStream fs = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                        {
                            using (Image temp = Image.FromStream(fs))
                            {
                                imgProfileImages.Image?.Dispose();
                                imgProfileImages.Image = new Bitmap(temp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        PopupNotification.PopUpMessages(0, "Image Load Failed: " + ex.Message, "Load Error");
                        imgProfileImages.Image = null;
                        return;
                    }
                    bntSaveImages.Enabled = true;
                }
            }
        }

        private int saveProfileImage()
        {
            var returnValue = 0;

            using (var session = new DalSession())
            {
                var unitWorks = session.UnitofWrk;
                unitWorks.Begin();

                try
                {
                    var filePathLocation = txtProfileImgFileName.Text.Trim();
                    var filePath = ExtractFileName(filePathLocation);
                    var imageCode = txtProfileImgBarcode.Text.Trim();

                    var repository = new Repository<ProfileImages>(unitWorks);
                    var existingImg = repository.FindBy(x => x.image_code == imageCode);

                    if (existingImg != null)
                    {
                        existingImg.title = txtProfileImgTitle.Text.Trim();
                        existingImg.img_type = cmbProfileImgType.Text.Trim();
                        existingImg.img_location = filePath;
                        existingImg.updated_on = DateTime.Now;

                        var updated = repository.Update(existingImg);
                        if (updated)
                        {
                            unitWorks.Commit();
                            PopupNotification.PopUpMessages(1, "Profile image updated: " + existingImg.title + " " + Messages.SuccessUpdate,
                                Messages.TitleSuccessUpdate);
                            returnValue = 1;
                        }
                    }
                    else
                    {
                        var newImg = new ProfileImages()
                        {
                            image_code = imageCode,
                            title = txtProfileImgTitle.Text.Trim(),
                            img_type = cmbProfileImgType.Text.Trim(),
                            img_location = filePath,
                            created_on = dkpImgCreadOn.Value.Date,
                            updated_on = DateTime.Now
                        };

                        var result = repository.Add(newImg);
                        if (result > 0)
                        {
                            unitWorks.Commit();
                            PopupNotification.PopUpMessages(1, "Profile image added: " + newImg.title + " " + Messages.SuccessInsert,
                                Messages.TitleSuccessInsert);
                            returnValue = 1;
                        }
                    }

                    _image_list = EnumerableUtils.getProfileImgList();
                    bindRefreshed();
                }
                catch (Exception ex)
                {
                    unitWorks.Rollback();
                    PopupNotification.PopUpMessages(0, "Error saving image: " + ex.Message, Messages.TitleFailedInsert);
                }
            }

            return returnValue;
        }


        private string ExtractFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void deleteProfile()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();

                try
                {
                    if (!int.TryParse(txtProfileID.Text.Trim(), out var profileId) || profileId <= 0)
                    {
                        PopupNotification.PopUpMessages(0, "Invalid Profile ID.", Messages.TitleFialedDelete);
                        return;
                    }

                    var profileRepo = new Repository<Profile>(unWork);
                    var profile = profileRepo.Id(profileId);

                    if (profile == null)
                    {
                        PopupNotification.PopUpMessages(0, "Profile not found.", Messages.TitleFialedDelete);
                        unWork.Rollback();
                        return;
                    }

                    // Initialize repositories
                    var addressRepo = new Repository<Address>(unWork);
                    var contactRepo = new Repository<Contact>(unWork);
                    var imageRepo = new Repository<ProfileImages>(unWork);

                    // Load related entities
                    var address = profile.address_id > 0 ? addressRepo.Id(profile.address_id) : null;
                    var contact = profile.contact_id > 0 ? contactRepo.Id(profile.contact_id) : null;

                    // Use profile_code to find related profile image
                    var imageCode = profile.profile_code;
                    var profileImage = imageRepo.All("SELECT * FROM profile_image")
                                                .FirstOrDefault(img => img.image_code == imageCode);

                    // Delete profile image if exists
                    bool imageDeleted = true;
                    if (profileImage != null)
                        imageDeleted = imageRepo.Delete(profileImage);

                    // Delete profile
                    bool profileDeleted = profileRepo.Delete(profile);

                    // Delete related address and contact
                    if (address != null)
                        addressRepo.Delete(address);

                    if (contact != null)
                        contactRepo.Delete(contact);

                    // Final check
                    if (profileDeleted && imageDeleted)
                    {
                        splashManager.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            $"Profile: {profile.profile_code} and related data deleted successfully.",
                            Messages.TitleSuccessDelete);

                        _profileList = EnumerableUtils.getProfileList();
                    }
                    else
                    {
                        splashManager.CloseWaitForm();
                        unWork.Rollback();
                        PopupNotification.PopUpMessages(0,
                            $"Failed to delete profile or its related data.",
                            Messages.TitleFialedDelete);
                    }
                }
                catch (Exception ex)
                {
                    splashManager.CloseWaitForm();
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, $"Deletion failed: {ex.Message}", Messages.TitleFialedDelete);
                }
            }
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

        private void gridEmployee_RowClick(object sender, RowClickEventArgs e)
        {
            whiteProfile();
            bntCancel.Enabled = true;
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
            if (e.KeyCode == Keys.F1)
            {
                BindDepartment();
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
                txtBarangay.Focus();
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
            ButDel();
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
            if (e == null || e.Page == null) return;

            if (e.Page == xtraContact)
            {
                bindContact();
                whiteContact();

                if (_add || _edt)
                {
                    enableContact();
                    enabledAddress();
                    enabledProfile();
                    txtContactName.Focus();
                }
                else
                {
                    disabledAddress();
                    disabledProfile();
                }

                grayAddress();
                grayProfile();
                txtContactName.Text = txtFirstName.Text + " " + txtMiddleInitial.Text + " " + txtLastName.Text;
                txtPositionName.Text = cmbPosition.Text;
                gridContact.Focus();
            }

            if (e.Page == xtraProfile)
            {
                whiteProfile();
                grayContact();
                grayAddress();

                if (_add || _edt)
                {
                    enabledProfile();
                    enabledAddress();
                    enableContact();
                    txtFirstName.Focus();
                }
                else
                {
                    disabledProfile();
                    disabledContact();
                    disabledAddress();
                }

                gridProfile.Focus();
            }

            if (e.Page == xtraAddress)
            {
                bindAddress();
                whiteAddress();
                grayProfile();
                grayContact();

                if (_add || _edt)
                {
                    enabledAddress();
                    enabledProfile();
                    enableContact();
                    txtBarangay.Focus();
                }
                else
                {
                    disabledContact();
                }

                gridAddress.Focus();
            }

            if (e.Page == xtraImage)
            {
                var firstName = txtFirstName.Text.Trim(' ');
                var middleName = txtMiddleInitial.Text.Trim(' ');
                var lastName = txtLastName.Text.Trim(' ');
                txtProfileImgTitle.Text = firstName + " " + middleName + " " + lastName;
                txtProfileImgBarcode.Text = txtBarcode.Text.Trim(' ');
            }
        }


        private void bindRefreshed()
        {
            bindAddress();
            bindContact();
            BindDepartment();
            bindProfileList();
        }

        private void BindDepartment()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Department>(unWork);
                var query = repository.SelectAll(ServeAll.Core.Queries.Query.AllDepartment).Select(x => x.department_name).Distinct().ToList();
                cmbDepartment.DataBindings.Clear();
                cmbDepartment.DataSource = query;
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
                    ID = p.profile_id,
                    CODE = p.profile_code,
                    NAME = p.first_name + " " + p.middle_initial + " " + p.last_name,
                    SEX = p.gender,
                    STATUS = p.civil_status,
                    TEL = p.telephone_number,
                    MOBILE = p.mobile_number,
                    EMAIL = p.email_address,
                    ADDRESS = $"{p.street}, {p.barangay}, {p.province}",
                    POSITION = p.position,
                    HIREDATE = p.hire_date.ToString("MM/dd/yyyy"),
                    REGISTERED = p.date_register.ToString("MM/dd/yyyy"),
                    DEPARTMENT = p.department_name
                }).ToList();
                gridCtlProfile.DataSource = list;
               if (gridProfile.RowCount > 0)
                {
                    gridProfile.Columns[0].Width = 40;
                    gridProfile.Columns[1].Width = 40;
                    gridProfile.Columns[2].Width = 150;
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
                        ID = p.contact_id,
                        CODE = p.contact_code,
                        NAME = p.contact_name,
                        POSITION = p.position,
                        TELEPHONE = p.telephone_number,
                        MOBILE = p.mobile_number,
                        SECONDARY = p.mobile_secondary,
                        EMAIL = p.email_address,
                        WEB = p.web_url,
                        FAX = p.fax_number,
                        DATE = p.date_register.ToString("MM/dd/yyyy")
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
                        ID = p.address_id,
                        STREET = p.street,
                        BARANGAY = p.barangay,
                        CITY = p.city,
                        PROVINCE = p.province,
                        ZIPCODE = p.zip_code,
                        COUNTRY = p.country
                    }).ToList();
                    gridControlAddress.Update();
                }
            }
        }

        private void gridViewAddress(object sender)
        {
            if(gridAddress.RowCount > 0)
            {
                var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                txtAddressID.Text = id;
                txtBarcodeAddress.Text = "AS001";
                txtBarangay.Text = ((GridView)sender).GetFocusedRowCellValue("BARANGAY").ToString();
                txtStreet.Text = ((GridView)sender).GetFocusedRowCellValue("STREET").ToString();
                txtCity.Text = ((GridView)sender).GetFocusedRowCellValue("CITY").ToString();
                txtZipCode.Text = ((GridView)sender).GetFocusedRowCellValue("ZIPCODE").ToString();
                txtProvince.Text = ((GridView)sender).GetFocusedRowCellValue("PROVINCE").ToString();
                cmbCountry.Text = ((GridView)sender).GetFocusedRowCellValue("COUNTRY").ToString();
            }
        }

        private string getfileExntesion(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void txtStreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtStreet, txtBarangay, "Street Address", Messages.TitleEmployees);
            }
        }

        private void txtBarangay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtBarangay, txtCity, "Barangay", Messages.TitleEmployees);
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtCity, txtZipCode, "City", Messages.TitleEmployees);
            }
        }

        private void txtZipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtZipCode, txtProvince, "Zip Code", Messages.TitleEmployees);
            }
        }

        private void txtProvince_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtProvince, cmbCountry, "Province", Messages.TitleEmployees);
            }
        }

        private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbCountry, dkpDateRegister, "Country", Messages.TitleEmployees);
            }
        }

        private void dkpDateRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                xtraControl.SelectedTabPage = xtraContact;
                txtContactName.Focus();
            }
        }

        private void txtContactName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtContactName, txtPositionName, "Contact Person", Messages.TitleEmployees);
            }
        }

        private void txtPositionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtPositionName, txtPhoneNumber, "Postion Name", Messages.TitleEmployees);
            }
        }

        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtPhoneNumber, txtFirstMobile, "Telephone Number", Messages.TitleEmployees);
            }
        }

        private void txtFirstMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtFirstMobile, txtSecondMobile, "First Mobile Number", Messages.TitleEmployees);
            }
        }

        private void txtSecondMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSecondMobile, txtEmailAddress, "Second Mobile Number", Messages.TitleEmployees);
            }
        }

        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtEmailAddress, txtWebUrl, "Email Address", Messages.TitleEmployees);
            }
        }

        private void txtWebUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtWebUrl, txtFaxNumber, "Web URL", Messages.TitleEmployees);
            }
        }

        private void txtFaxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtFaxNumber, dkpContactDateReg, "Fax Number", Messages.TitleEmployees);
            }
        }

        private void dkpContactDateReg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpContactDateReg, bntSave, "Contact Date", Messages.TitleEmployees);
            }
        }

        private void gridViewContact(object sender)
        {
            if (gridContact.RowCount > 0) {
                var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                txtContactId.Text = id;
                txtContactBarcode.Text = ((GridView)sender).GetFocusedRowCellValue("CODE").ToString();
                txtContactName.Text = ((GridView)sender).GetFocusedRowCellValue("NAME").ToString();
                txtPositionName.Text = ((GridView)sender).GetFocusedRowCellValue("POSITION").ToString();
                txtPhoneNumber.Text = ((GridView)sender).GetFocusedRowCellValue("TELEPHONE").ToString();
                txtFirstMobile.Text = ((GridView)sender).GetFocusedRowCellValue("MOBILE").ToString();
                txtSecondMobile.Text = ((GridView)sender).GetFocusedRowCellValue("SECONDARY").ToString();
                txtEmailAddress.Text = ((GridView)sender).GetFocusedRowCellValue("EMAIL").ToString();
                txtWebUrl.Text = ((GridView)sender).GetFocusedRowCellValue("WEB").ToString();
                txtFaxNumber.Text = ((GridView)sender).GetFocusedRowCellValue("FAX").ToString();
                dkpContactDateReg.Format = DateTimePickerFormat.Custom;
                dkpContactDateReg.CustomFormat = "MM/dd/yyyy";
                dkpContactDateReg.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("DATE");
            }
        }

        private void gridViewProfile(object sender)
        {
            if (gridProfile.RowCount <= 0) return;

            try
            {
                var view = sender as GridView;
                if (view == null) return;

                var idObj = view.GetFocusedRowCellValue("ID");
                if (idObj == null) return;

                var idText = idObj.ToString().Trim();
                if (string.IsNullOrEmpty(idText)) return;

                int profileId = int.Parse(idText);
                var profile = _profileList.FirstOrDefault(p => p.profile_id == profileId);
                if (profile == null)
                {
                    PopupNotification.PopUpMessages(0, "Profile Details", "No profile found for this ID.");
                    return;
                }

                // Fill fields
                txtProfileID.Text = profile.profile_id.ToString();
                txtBarcode.Text = profile.profile_code ?? "";
                txtFirstName.Text = profile.first_name ?? "";
                txtLastName.Text = profile.last_name ?? "";
                txtMiddleInitial.Text = profile.middle_initial ?? "";
                cmbDepartment.Text = profile.department_name ?? "";
                cmbgender.Text = profile.gender ?? "";
                dkpBirthdate.Format = DateTimePickerFormat.Custom;
                dkpBirthdate.CustomFormat = "MM/dd/yyyy";
                dkpBirthdate.Value = profile.birthdate;
                cmbCivilStatus.Text = profile.civil_status ?? "";
                txtPhone.Text = profile.telephone_number ?? "";
                txtMobile.Text = profile.mobile_number ?? "";
                txtEmail.Text = profile.email_address ?? "";
                txtAddress.Text = profile.barangay ?? "";
                cmbProvince.Text = profile.province ?? "";
                txtSSSNumber.Text = profile.sss_number ?? "";
                txtPhilhealthNumber.Text = profile.phil_health ?? "";
                cmbPosition.Text = profile.position ?? "";
                dkpDateHired.Format = DateTimePickerFormat.Custom;
                dkpDateHired.CustomFormat = "MM/dd/yyyy";
                dkpDateHired.Value = profile.hire_date;
                dkpDateRegistered.Format = DateTimePickerFormat.Custom;
                dkpDateRegistered.CustomFormat = "MM/dd/yyyy";
                dkpDateRegistered.Value = profile.date_register;

                // Load Image
                var img = searchProfileImg(profile.profile_code);
                var imgLocation = img?.img_location;
                if (string.IsNullOrEmpty(imgLocation))
                {
                    if (imgProfile != null) imgProfile.ImageLocation = ConstantUtils.defaultUserImgEmpty;
                    if (imgProfileImages != null) imgProfileImages.ImageLocation = ConstantUtils.defaultUserImgEmpty;
                }
                else
                {
                    var location = ConstantUtils.defaultUserImgLocation + imgLocation;
                    if (imgProfile != null) imgProfile.ImageLocation = location;
                    if (imgProfileImages != null) imgProfileImages.ImageLocation = location;
                }
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.Message, "Profile Details");
            }
        }
    }
}
