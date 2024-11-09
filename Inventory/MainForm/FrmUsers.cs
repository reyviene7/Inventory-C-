using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Helper;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FrmUsers : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del, _img, _usr;
        private readonly int _userId;
        private readonly int _userTy;
        private IEnumerable<ViewUserImage> user_image;
        private IEnumerable<users> _users;
        private IEnumerable<UserImage> _user_image;
        private IEnumerable<ViewUser> _user_list;
        private int userId;

        public FirmMain Main
        {
            get { return _main;}
            set { _main = value; }
        }

        public FrmUsers(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            if (_userTy != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            splashManager.ShowWaitForm();
            var roles = EnumerableUtils.getRoleType();
            var profile = EnumerableUtils.getProfileNames();
            var roleType = roles.Select(type => type.role_type).ToList();
            var profileName = profile
                .Select(name => name.last_name + ", " + name.first_name + " " + name.middle_initial).ToList();
            cmbRoleType.Items.AddRange(roleType.ToArray());
            cmbName.Items.AddRange(profileName.ToArray());
            if (roleType.Any())
            {
                cmbRoleType.Text = roleType.First();
            }
            if (profileName.Any())
            {
                cmbName.Text = profileName.First();
            }
            user_image = EnumerableUtils.getViewUserImage();
            _user_image = EnumerableUtils.getUserImage();
            _users = EnumerableUtils.getUserNameList();
            _user_list = EnumerableUtils.getUserList();
            bindingUserList();
            BindUserImg();
            splashManager.CloseWaitForm();
        }

        private void FrmUsers_MouseMove(object sender, MouseEventArgs e)
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
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
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

        //BUTTON 
        private void ButtonAdd()
        {
            bntAdd.Enabled = true;
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
            bntAdd.Enabled = false;
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
            bntAdd.Enabled = false;
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
            bntAdd.Enabled = true;
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
            bntAdd.Enabled = true;
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
            bntAdd.Enabled = true;
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

        //TextBox Color Enable
        private void InputWhit()
        {
            txtUserId.BackColor = Color.White;
            txtUserCode.BackColor = Color.White;
            cmbName.BackColor = Color.White;
            txtUsername.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            txtRewrite.BackColor = Color.White;
            cmbRoleType.BackColor = Color.White;
        }

        private void InputEnab()
        {
            cmbName.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtRewrite.Enabled = true;
            cmbRoleType.Enabled = true;

        }
        private void InputDisb()
        {
            txtUserId.Enabled = false;
            txtUserCode.Enabled = false;
            cmbName.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtRewrite.Enabled = false;
            cmbRoleType.Enabled = false;
        }
        private void InputClea()
        {
            txtUserId.Clear();
            txtUserCode.Clear();
            cmbName.Text = "";
            txtUsername.Clear(); 
            txtPassword.Clear();
            txtRewrite.Clear();
            cmbRoleType.Text = "";
        }
        private void InputDimG()
        {
            txtUserId.BackColor = Color.DimGray;
            cmbName.BackColor = Color.DimGray;
            txtUserCode.BackColor = Color.DimGray;
            txtUsername.BackColor = Color.DimGray;
            txtPassword.BackColor = Color.DimGray;
            txtRewrite.BackColor = Color.DimGray;
            cmbRoleType.BackColor = Color.DimGray;
        }

        private void InputWhitimg()
        {
            txtImageId.BackColor = Color.White;
            txtImageCode.BackColor = Color.White;
            txtImageName.BackColor = Color.White;
            txtImageType.BackColor = Color.White;
            txtImageLocation.BackColor = Color.White;
        }

        private void InputEnabimg()
        {
            txtImageId.Enabled = true;
            txtImageCode.Enabled = true;
            txtImageName.Enabled = true;
            txtImageType.Enabled = true;
            txtImageLocation.Enabled = true;
        }

        private void InputDisbimg()
        {
            txtImageId.Enabled = false;
            txtImageCode.Enabled = false;
            txtImageName.Enabled = false;
            txtImageType.Enabled = false;
            txtImageLocation.Enabled = false;
        }

        private void InputCleaimg()
        {
            txtImageId.Clear();
            txtImageCode.Clear();
            txtImageName.Clear();
            txtImageType.Text = "";
            txtImageLocation.Clear();
        }

        private void InputDimGimg()
        {
            txtImageId.BackColor = Color.DimGray;
            txtImageCode.BackColor = Color.DimGray;
            txtImageName.BackColor = Color.DimGray;
            txtImageType.BackColor = Color.DimGray;
            txtImageLocation.BackColor = Color.DimGray;
        }
        private void buttonAdd()
        {
            ButtonAdd();
            _add = true;
            _edt = false;
            _del = false;
            gridUserList.Enabled = false;
            if (_usr && _img == false)
            {
                cmbName.Focus();
                InputEnab();
                InputWhit();
                InputClea();
                generateUserCode();
            }
            if (_usr == false && _img)
            {
              //  GenerateImgCode();
                InputEnabimg();
                InputWhitimg();
                InputCleaimg();
                txtImageName.Focus();
            }

        }
        private void buttonUpdate()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            if (_usr && _img == false)
            {
                InputEnab();
                InputWhit();
                gridUserList.Enabled = false;
                txtPassword.Focus();
            }
            if (_usr == false && _img)
            {
                InputEnabimg();
                InputWhitimg();
                gIMG.Enabled = false;
            }
        }
        private void buttonDelete()
        {
            ButtonDel();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gridUserList.Enabled = false;
        }
        private void buttonClear()
        {
            ButtonClr();
            InputEnabimg();
            InputWhitimg();
            InputCleaimg();
            InputClea();
            gridUserList.Enabled = true;
            bntBrowseImage.Enabled = true;
        }
        private void buttonCancel()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            InputDisbimg();
            InputCleaimg();
            InputDimGimg();
            gridUserList.Enabled = true;
            cmbName.DataBindings.Clear();
            bntBrowseImage.Enabled = true;
        }
        private void buttonSave()
        {
            if (_usr && _img == false)
            {
                SavUser();
            }
            if (_usr == false && _img)
            {
                SavImg();
            }
        }

        #region SaveUSers
        #region SaveImages

        private void SavImg()
        {
            if (_add && _img && _edt == false && _del == false && _usr == false)
            {
                DataImgInsert();
                ButtonSav();
                InputDisbimg();
                InputDimGimg();
                InputCleaimg();
              //  BindImageList();
            }
            if (_add == false && _edt && _img && _del == false && _usr == false)
            {
                DataImgUpdate();
                ButtonSav();
                InputDisbimg();
                InputDimG();
                InputCleaimg();
              //  BindImageList();
            }
            if (_add == false && _edt == false && _del && _img && _usr == false)
            {
                DataImgDelete();
                ButtonSav();
                InputDisbimg();
                InputDimGimg();
                InputCleaimg();
             //   BindImageList();
            }
            _add = false;
            _edt = false;
            _del = false;
            _img = true;
            _usr = false;
            gIMG.Enabled = true;
        }
        #endregion
        private void SavUser()
        {
            if (_add && _edt == false && _del == false && _img == false)
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindingUserList();
            }
            if (_add == false && _edt && _del == false && _img == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindingUserList();
            }
            if (_add == false && _edt == false && _del && _img == false)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindingUserList();
            }
            _add = false;
            _edt = false;
            _del = false;
            _usr = true;
            _img = false;
            gridUserList.Enabled = true;
            _user_list = EnumerableUtils.getUserList();
            bindingUserList();
        }
        #endregion

        private int getLastUserId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<users>(unitWork);
                var result = (from b in repository.SelectAll(Query.getUserId)
                              orderby b.user_id descending
                              select b.user_id).Take(1).SingleOrDefault();
                if (result > 0)
                {
                    return result;
                }
                return 0;
            }
        }
        private void generateUserCode()
        {
            var lastId = getLastUserId();
            var alphaNumeric = new GenerateAlpaNum("CA", 3, lastId);
            alphaNumeric.Increment();
            txtUserCode.Text = alphaNumeric.ToString();
        }
        private void bindingUserList()
        {
            gridUserList.Update();
            try
            {
                var list = _user_list.Select(u => new
                {
                    Id = u.user_id,
                    UserCode = u.user_code,
                    Name = u.name,
                    UserName = u.username,
                    UserRole = u.role_type
                }).ToList();
                gridUserList.DataBindings.Clear();
                gridUserList.DataSource = list;
            }
            catch (Exception ex)
            {
                gridUserList.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableUsers);
            }
        }

        private void BindUserImg()
        {
            var list = _user_image.Select(i => new
            {
                Id = i.image_id,
                Code = i.image_code,
                Title = i.title,
                Type = i.img_type,
                Location = i.img_location,
                Created = i.created_on,
                Updated = i.updated_on
            }).ToList();
            gIMG.DataSource = list;
            gIMG.Update();
            if (gridImg.RowCount > 0)
            {
                gridImg.Columns[0].Width = 40;
                gridImg.Columns[1].Width = 60;
                gridImg.Columns[2].Width = 200;
                gridImg.Columns[3].Width = 50;
                gridImg.Columns[4].Width = 150;
                gridImg.Columns[5].Width = 100;
                gridImg.Columns[6].Width = 100;
            }
        }

        private void DataInsert()
        {
            var rawPassword = txtPassword.Text.Trim(' ');
            var profileName = cmbName.Text.Trim(' ');
            var userType = cmbRoleType.Text.Trim(' ');
            const string encryptionKey = PasswordCipter.EncryptionPass;
            var encodedPassword = StringCipher.Encrypt(rawPassword, encryptionKey);
            var user = new users
            {
                user_code    = txtUserCode.Text.Trim(' '),
                username    = txtUsername.Text.Trim(' '),
                password    = encodedPassword,
                role_id    = FetchUtils.getUserRole(userType),
                profile_id  = FetchUtils.getProfileId(profileName)
            };
            using (var session = new DalSession())
            {
                var unit = session.UnitofWrk;
                unit.Begin();
                try
                {
                    var repository = new Repository<users>(unit);
                    var que = repository.Add(user);
                    if (que <= 0) return;
                    PopupNotification.PopUpMessages(1, Messages.TableUsers + Messages.CodeName +
                                                    txtUserCode.Text.Trim(' ')
                                                    + " " + Messages.SuccessInsert,
                                                    Messages.TitleSuccessInsert);
                    unit.Commit();
                }
                catch (Exception)
                {
                    unit.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorInsert + Messages.TableUsers + Messages.ErrorOccurred, Messages.TitleFailedInsert);
                }
            }

        }

        private void DataUpdate() {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var userId = Convert.ToInt32(txtUserId.Text);
                try
                {
                    var profileName = cmbName.Text.Trim(' ');
                    var rawPassword = txtPassword.Text.Trim(' ');
                    var rawRetryPassword = txtRewrite.Text.Trim(' ');
                    var userType = cmbRoleType.Text.Trim(' ');
                    const string encryptionKey = PasswordCipter.EncryptionPass;
                    var roleId = FetchUtils.getUserRole(userType);
                    var profileId = FetchUtils.getProfileId(profileName);
                    var encodedPassword = StringCipher.Encrypt(rawPassword, encryptionKey);

                    if (rawPassword == rawRetryPassword)
                    {
                        var repository = new Repository<users>(unWork);
                        var query = repository.Id(userId);
                        query.username = txtUsername.Text.Trim(' ');
                        query.password = encodedPassword;
                        query.role_id = roleId;
                        query.profile_id = profileId;
                        var result = repository.Update(query);
                        if (!result) return;
                        PopupNotification.PopUpMessages(1, "Credential Successfully Updated! ", Messages.SuccessUpdate);
                        unWork.Commit();

                    }
                    else {
                        PopupNotification.PopUpMessages(0, "Password and rewrite mismatched", Messages.TitleFialedUpdate);

                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableEmployees + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
                }
            }

        }
        
        private void tabUsers_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabUsers.SelectedTabPage == xAUT)
            {
                _usr = true;
                _img = false;
                gridUserList.Enabled = true;
                gIMG.Enabled = false;
            }
            if (tabUsers.SelectedTabPage == xIMG)
            {
                _img = true;
                _usr = false;
                gridUserList.Enabled = false;
                gIMG.Enabled = true;
            }
        }
        private void DataDelete() { }
        private void DataImgInsert() { }
        private void DataImgUpdate() { }
        private void DataImgDelete() { }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            buttonAdd();
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            buttonSave();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            buttonCancel();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (_usr && _img == false)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete USer: " + txtUsername.Text.Trim(' ') + " " + "?", "Category Details");
                if (que)
                {
                    buttonDelete();
                    gridUserList.Enabled = false;
                }
                else
                {
                    buttonCancel();
                    gridUserList.Enabled = true;
                }
            }
            if (_usr == false && _img)
            {
                InputWhitimg();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Image Name: " + txtImageName.Text.Trim(' ') + " " + "?", "Image Details");
                if (que)
                {
                    buttonDelete();
                    gIMG.Enabled = false;
                }
                else
                {
                    buttonCancel();
                    gIMG.Enabled = true;
                }
            }
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            buttonClear();
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbName.SelectedText))
            {

            }
        }

        private void cmbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var name = cmbName.Text.Trim(' ');
                var result = FetchUtils.getVerifiyUserId(name);
                if (result > 0) {
                    PopupNotification.PopUpMessages(0, name + " account already exist!",
                        Messages.TitleUsers);
                    cmbName.Focus();
                } else {
                    InputManipulation.InputBoxLeave(cmbName, txtUsername, "Profile Name", Messages.TitleUsers);
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                var name = cmbName.Text.Trim(' ');
                var result = FetchUtils.getVerifiyUserId(name);
                if (result > 0)
                {
                    PopupNotification.PopUpMessages(0, name + " account already exist!",
                        Messages.TitleUsers);
                    cmbName.Focus();
                }
                else
                {
                    InputManipulation.InputBoxLeave(cmbName, txtUsername, "Profile Name", Messages.TitleUsers);
                }
            }
        }

        private void gridUsers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView(sender);
        }

        private void gridUsers_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
            InputWhitimg();
            gridView(sender);
        }

        private void gridView(object sender)
        {
            if (gridUsers.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        userId = int.Parse(id);
                        var user = searchUserId(userId);
                        var code = user.user_code;
                        var fullname = user.name;
                        txtUserId.Text = id;
                        txtUserCode.Text = code;
                        txtImageId.Text = id;
                        txtImageCode.Text = code;
                        cmbName.Text = fullname;
                        txtImageName.Text = fullname;
                        txtUsername.Text = user.username;
                        cmbRoleType.Text = user.role_type;

                        var img = searchUserImage(code);
                        var imgLocation = img?.img_location;  // Use null conditional operator

                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgUser.ImageLocation = ConstantUtils.defaultUserImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultUserImgLocation + imgLocation;
                            imgUser.ImageLocation = location;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        private ViewUser searchUserId(int id)
        {
            return _user_list.FirstOrDefault(user => user.user_id == id);
        }

        private ViewUserImage searchUserImage(string param)
        {
            return user_image.FirstOrDefault(img => img.image_code == param);
        }

        private void gridImg_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridImage(sender);
        }

        private void gridImage(object sender)
        {
            var grid = gridImg;
            if (grid.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    var code = ((GridView)sender).GetFocusedRowCellValue("Code").ToString();
                    if (code.Length > 0)
                    {
                        var user = searchUserImage(code);
                        txtImageId.Text = id;
                        txtImageCode.Text = code;
                        txtImageName.Text = user.title;
                        txtImageType.Text = user.img_type;
                        txtImageLocation.Text = user.img_location;

                        var img = searchUserImage(code);
                        var imgLocation = img?.img_location;  // Use null conditional operator

                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgPro.ImageLocation = ConstantUtils.defaultUserImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultUserImgLocation + imgLocation;
                            imgPro.ImageLocation = location;
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
        }
        private string getfileExntesion(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void bntBrowseImage_Click(object sender, EventArgs e)
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
                    txtImageLocation.Text = fileNameAndExtension;
                    bntSaveImages.Enabled = true;
                    bntBrowseImage.Enabled = false;
                }
            }
        }

        private void bntSaveImages_Click(object sender, EventArgs e)
        {
            saveUserImage();
            ButtonSav();
        }

        private string ExtractFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void saveUserImage()
        {
            splashManager.ShowWaitForm();
            var filePathLocation = txtImageLocation.Text.Trim(' ');
            var filePath = ExtractFileName(filePathLocation);
            var img = new UserImage()
            {
                image_code = txtImageCode.Text.Trim(' '),
                title = txtImageName.Text.Trim(' '),
                img_type = txtImageType.Text.Trim(' '),
                img_location = filePath,
                created_on = DateTime.Now,
                updated_on = DateTime.Now
            };
            var result = RepositoryEntity.AddEntity<UserImage>(img);
            if (result > 0)
            {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(1, "User image: " + txtImageName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                    Messages.TitleSuccessInsert);
                _user_image = EnumerableUtils.getUserImage();
                BindUserImg();
            }
            else
            {
                splashManager.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "User image: " + txtImageName.Text.Trim(' ') + " " + Messages.ErrorInsert,
                    Messages.TitleFailedInsert);
            }
        }

        /*
        private void txtImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedImageType = txtImageType.SelectedItem?.ToString();

            if (selectedImageType != null)
            {
                // For demonstration, show a message box with the selected image type
                MessageBox.Show("Selected Image Type: " + selectedImageType);
            }
        }
        */

        private void txtRewrite_Leave(object sender, EventArgs e)
        {
            if (_usr && _add)
            {
                var pss = txtPassword.Text.Trim(' ');
                var wrt = txtRewrite.Text.Trim(' ');
                if (pss.Length <= 7)
                {
                    PopupNotification.PopUpMessages(0, "Password does not meet minimum characters length!",
                        Messages.TitleUsers);
                    txtPassword.Focus();
                    txtPassword.BackColor = Color.Yellow;
                }
                else
                {
                    if (!string.Equals(pss, wrt))
                    {
                        PopupNotification.PopUpMessages(0, "Password and rewrite password mismatched!",
                        Messages.TitleUsers);
                        txtPassword.Focus();
                        txtPassword.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void txtRewrite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(txtRewrite, cmbRoleType, "Re-Write Password", Messages.TitleUsers);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(txtPassword, txtRewrite, "User Password", Messages.TitleUsers);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(txtUsername, txtPassword, "Username", Messages.TitleUsers);
            }
        }
    }
}
