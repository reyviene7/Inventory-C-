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
        public FirmMain Main
        {
            get { return _main;}
            set { _main = value; }
        }

        public FrmUsers()
        {
            InitializeComponent();
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            bindingUserList();
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
            var log = new FirmLogin();
            var que = PopupNotification.PopUpMassageLogOff();
            if (que > 0)
            {
                log.Show();
                Close();
            }
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
            txtUserId.Enabled = true;
            txtUserCode.Enabled = true;
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

        private void InputWhitimg() { }
        private void InputEnabimg() { }
        private void InputDisbimg() { }
        private void InputCleaimg() { }
        private void InputDimGimg() { }
        private void BntEnabled()
        {
            bntLOD.Enabled = true;
        }
        private void buttonAdd()
        {
            ButtonAdd();
            BntEnabled();
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
                bindProfileNames();
                bindRoleUser();
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
            gridUserList.Enabled = true;
             
        }
        private void buttonCancel()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gridUserList.Enabled = true;
            cmbName.DataBindings.Clear();
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
                gridUserList.DataBindings.Clear();
                gridUserList.DataSource = userList().Select(p => new
                {
                    Id = p.user_id,
                    UserCode = p.user_code,
                    Name = p.name,
                    UserName = p.username,
                    UserRole = p.role_type
                });
            }
            catch (Exception ex)
            {
                gridUserList.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableUsers);
            }
        }
        private void bindProfileNames()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ViewProfile>(unWork);
                var query = repository
                        .SelectAll(Query.getProfileName)
                        .Select(x => x.last_name + ", " + x.first_name + " " + x.middle_initial)
                        .Distinct()
                        .ToList();
                cmbName.DataBindings.Clear();
                cmbName.DataSource = query;
            }
        }

        private void bindRoleUser()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Roles>(unWork);
                var query = repository.SelectAll(Query.AllRoleTypes).Select(x => x.role_type).Distinct().ToList();
                cmbRoleType.DataBindings.Clear();
                cmbRoleType.DataSource = query;
            }
        }

        private IEnumerable<ViewUser> userList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewUser>(unWork);
                    return repository.SelectAll(Query.getViewUser).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleProductImage);
                    throw;
                }
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
                role_id    = getUserRole(userType),
                profile_id  = getProfileId(profileName)
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

                    var rawPassword = txtPassword.Text.Trim(' ');
                    var rawRetryPassword = txtRewrite.Text.Trim(' ');
                    var userType = cmbRoleType.Text.Trim(' ');
                    const string encryptionKey = PasswordCipter.EncryptionPass;
                    var roleId = getUserRole(userType);
                    var encodedPassword = StringCipher.Encrypt(rawPassword, encryptionKey);

                    if (rawPassword == rawRetryPassword)
                    {
                        var repository = new Repository<users>(unWork);
                        var query = repository.Id(userId);
                        query.username = txtUsername.Text.Trim(' ');
                        query.password = encodedPassword;
                        query.role_id = roleId;
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


        //BINDING 
        #region GetBinding
        private int getProfileId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProfileEntities>(unWork);
                    var query = repository.FindBy(x => x.name == input);
                    return query.profile_id;
                }
                catch (Exception ex)
                {
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleUsers);
                    return 0;
                }
            }
        }

        private int getUserRole(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Roles>(unWork);
                    var query = repository.FindBy(x => x.role_type == input);
                    return query.role_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Usertype Id Error", Messages.TitleUsers);
                    return 0;
                }
            }
        }
        #endregion


        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            
                
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
            gridView(sender);
        }

        private void gridView(object sender)
        {
            var grid = gridUsers;
            if (grid.RowCount > 0)
                try
                {
                    txtUserId.Text = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    txtUserCode.Text = ((GridView)sender).GetFocusedRowCellValue("UserCode").ToString();
                    cmbName.Text = ((GridView)sender).GetFocusedRowCellValue("Name").ToString();
                    txtUsername.Text = ((GridView)sender).GetFocusedRowCellValue("UserName").ToString();
                    cmbRoleType.Text = ((GridView)sender).GetFocusedRowCellValue("UserRole").ToString();
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.ToString());
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
