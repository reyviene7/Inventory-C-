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
            _users = EnumerableUtils.getUserNameList();
            bindRefreshed();
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

        private void buttonAdd()
        {
            ButtonAdd();
            _add = true;
            _edt = false;
            _del = false;
            gridUserList.Enabled = false;
            cmbName.Focus();
            InputEnab();
            InputWhit();
            InputClea();
            generateUserCode();
        }
        private void buttonUpdate()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            InputEnab();
            InputWhit();
            gridUserList.Enabled = false;
            txtPassword.Focus();
        }
        private void buttonDelete()
        {
            ButtonDel();
            InputDisb();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gridUserList.Enabled = false;
        }
        private void buttonClear()
        {
            bindRefreshed();
            ButtonClr();
            InputWhit();
            InputWhitimg();
            InputCleaimg();
            InputClea();
            gridUserList.Enabled = true;
            bntBrowseImage.Enabled = true;
            gridUserList.DataBindings.Clear();
            int focusedRowHandle = gridUsers.FocusedRowHandle;
            if (focusedRowHandle >= 0)
            {
                gridUsers_FocusedRowChanged(
                    gridUsers,
                    new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                        focusedRowHandle,
                        focusedRowHandle
                    )
                );
            }
        }
        private void buttonCancel()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            InputDisbimg();
            InputCleaimg();
            gridUserList.Enabled = true;
            cmbName.DataBindings.Clear();
            bntBrowseImage.Enabled = true;
        }
        private void buttonSave()
        {
            SavUser();
        }

        #region SaveUSers
        private void SavUser()
        {
            if (_add && _edt == false && _del == false )
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt && _del == false )
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt == false && _del )
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            _add = false;
            _edt = false;
            _del = false;
            _usr = true;
            gridUserList.Enabled = true;
            bindRefreshed();
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
            var alphaNumeric = new GenerateAlpaNum("C", 3, lastId); // Use "C" for the middle part
            alphaNumeric.Increment();

            // Construct final code format: S24-C###-CA
            var yearPrefix = "S24";
            var suffix = "CA";
            txtUserCode.Text = $"{yearPrefix}-{alphaNumeric}-{suffix}";
        }

        private void bindRefreshed()
        {
            _user_image = EnumerableUtils.getUserImage();
            _user_list = EnumerableUtils.getUserList();
            bindingUserList();
            BindUserImg();
        }
        private void bindingUserList()
        {
            gridUserList.Update();
            try
            {
                var list = _user_list.Select(u => new
                {
                    ID = u.user_id,
                    CODE = u.user_code,
                    NAME = u.name,
                    USERNAME = u.username,
                    ROLE = u.role_type
                }).ToList();
                gridUserList.DataBindings.Clear();
                gridUserList.DataSource = list;
                gridUserList.Update();
                if (gridUsers.RowCount > 0)
                {
                    gridUsers.Columns[0].Width = 40;
                    gridUsers.Columns[1].Width = 100;
                    gridUsers.Columns[2].Width = 300;
                    gridUsers.Columns[3].Width = 200;
                    gridUsers.Columns[4].Width = 80;
                }
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
                ID = i.image_id,
                CODE = i.image_code,
                TITLE = i.title,
                TYPE = i.img_type,
                LOCATION = i.img_location,
                CREATED = i.created_on,
                UPDATED = i.updated_on
            }).ToList();
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
            }
            if (tabUsers.SelectedTabPage == xIMG)
            {
                _img = true;
                _usr = false;
                gridUserList.Enabled = false;
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
                    var catId = Convert.ToInt32(txtUserId.Text);
                    var repository = new Repository<users>(unWork);
                    var que = repository.Id(catId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Username: " +
                                                           txtUsername.Text.Trim(' ')
                                                           + " " + Messages.SuccessDelete,
                            Messages.TitleSuccessDelete);
                        bindRefreshed();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);
                }
            }
        }

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
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete this User: " + txtUsername.Text.Trim(' ') + " " + "?", "User Details");
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
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
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
                            imgPro.ImageLocation = ConstantUtils.defaultUserImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultUserImgLocation + imgLocation;
                            imgUser.BackColor = Color.White;
                            imgPro.BackColor = Color.White;
                            imgUser.ImageLocation = location;
                            imgPro.ImageLocation = location;
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

                    // Set filename text field
                    string fileNameAndExtension = getfileExntesion(selectedFilePath);
                    txtImageLocation.Text = fileNameAndExtension;

                    // Clear previous image preview
                    if (imgPro.Image != null)
                    {
                        imgPro.Image.Dispose();
                        imgPro.Image = null;
                    }

                    try
                    {
                        using (var stream = new MemoryStream(File.ReadAllBytes(selectedFilePath)))
                        {
                            imgPro.Image = Image.FromStream(stream);
                            imgPro.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Update button states
                    bntSaveImages.Enabled = true;
                    bntBrowseImage.Enabled = false;
                }
            }
        }


        private void bntSaveImages_Click(object sender, EventArgs e)
        {
            var code = txtImageCode.Text.Trim(' ');
            var title = txtImageName.Text.Trim(' ');
            var imgtype = txtImageType.Text.Trim(' ');
            var imgLocation = txtImageLocation.Text.Trim(' ');

            if (code.Length > 0 && title.Length > 0 && imgtype.Length > 0 && imgLocation.Length > 0)
            {
                var result = saveUserImage();
                if (result > 0)
                {
                    bntSaveImages.Enabled = false;
                    bntBrowseImage.Enabled = true;
                }
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Please fill all the entries!", Messages.TitleFailedInsert);
            }
        }


        private string ExtractFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private int saveUserImage()
        {
            var returnValue = 0;

            using (var session = new DalSession())
            {
                var unitWorks = session.UnitofWrk;
                unitWorks.Begin();

                try
                {
                    var filePathLocation = txtImageLocation.Text.Trim(' ');
                    var filePath = ExtractFileName(filePathLocation);
                    var repository = new Repository<UserImage>(unitWorks);
                    var imageCode = txtImageCode.Text.Trim(' ');

                    var existingImg = repository.FindBy(x => x.image_code == imageCode);

                    if (existingImg != null)
                    {
                        existingImg.title = txtImageName.Text.Trim(' ');
                        existingImg.img_type = txtImageType.Text.Trim(' ');
                        existingImg.img_location = filePath;
                        existingImg.updated_on = DateTime.Now;

                        var updated = repository.Update(existingImg);
                        if (updated)
                        {
                            PopupNotification.PopUpMessages(1, "User image updated: " + txtImageName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                                Messages.TitleSuccessUpdate);
                            unitWorks.Commit();
                            returnValue = 1;
                        }
                    }
                    else
                    {
                        var img = new UserImage()
                        {
                            image_code = imageCode,
                            title = txtImageName.Text.Trim(' '),
                            img_type = txtImageType.Text.Trim(' '),
                            img_location = filePath,
                            created_on = DateTime.Now,
                            updated_on = DateTime.Now
                        };

                        var result = repository.Add(img);
                        if (result > 0)
                        {
                            PopupNotification.PopUpMessages(1, "User image added: " + txtImageName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                                Messages.TitleSuccessInsert);
                            unitWorks.Commit();
                            returnValue = 1;
                        }
                    }

                    _user_image = EnumerableUtils.getUserImage();
                    BindUserImg();
                }
                catch (Exception ex)
                {
                    unitWorks.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                    returnValue = 0;
                }
            }

            return returnValue;
        }


        private void GridUsers_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }

        private void cmbRoleType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbRoleType, bntSave, "Role Type",
                Messages.TitleUsers);
            }
        }

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
