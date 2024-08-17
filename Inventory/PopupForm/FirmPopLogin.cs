using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.MainForm;
using ServeAll.Core.Helper;
using ServeAll.Core.Repository;
using Constant = Inventory.Config.Constant;
using Inventory.Config;
using ServeAll.Core.Entities;

namespace Inventory.PopupForm
{
    public partial class FirmPopLogin : Form
    {
        public FirmLogin Login { get; set; }
        private readonly int _uTyp;
        public FirmPopLogin(int uTyp)
        {
            _uTyp = uTyp;
            InitializeComponent();
        }

        private void bntSVA_Click(object sender, EventArgs e)
        {
            var lenPass = txtPASS.Text.Length;
            var lenUser = txtUSR.Text.Length;
            if (lenUser > 0 && lenPass > 0)
            {
                LoginUser();
            }
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FirmPopLogin_Load(object sender, EventArgs e)
        {
            if (_uTyp == 1)
            {
                lblLOG.Text = Constant.AdminAccount;
            }
            if (_uTyp == 2)
            {
                lblLOG.Text = Constant.UserAccount;
            }
            if (_uTyp == 3)
            {
                lblLOG.Text = Constant.GuessAccount;
            }
        }
        private void txtUSR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtUSR.Text.Length;
                if (len > 0)
                {
                    txtPASS.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Admin Username must not be empty!", Messages.InventorySystem);
                    txtUSR.Focus();
                }
            }
        }
        private async void LoginUser()
        {
            var userName = txtUSR.Text.Trim(' ');
            var userPass = txtPASS.Text.Trim(' ');
            var userType = _uTyp;
             
            using (var session = new DalSession())
            {
                try
                {

                    await Task.Delay((int)TimeSpan.FromMilliseconds(1).TotalMilliseconds);
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<users>(unWork);
                    var query = repository.ExecLoginUser(StoredProcedure.UspGetPasswordLogin, SqlVariables.UserName, userName, SqlVariables.UserType, userType);
                    if (query.Length <= 0) return;
                    const string salt = PasswordCipter.EncryptionPass;
                    var que = StringCipher.Decrypt(query.Trim(' '), salt);
                    if (string.Equals(userPass, que))
                    {
                        Login.UserId = GetUserId(userName);
                        Login.UserTy = _uTyp;
                        Login._userName = userName;
                        Login.LoginSuccess = 1;
                        Close();
                    }
                    else
                    {

                        PopupNotification.PopUpMessages(0, "Username or Password Incorrect!", "POS Authentication");
                        txtPASS.Text = "";
                        txtUSR.Text = "";
                        txtUSR.Focus();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private int GetUserId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<users>(unWork);
                    var query = repository.FindBy(x => x.username == input);
                    return query.user_id;
                }
                catch (Exception ex)
                {
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableUsers);
                    return 0;
                }
            }
        }
        private void txtPASS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
                var lenPass = txtPASS.Text.Length;
                var lenUser = txtUSR.Text.Length;
            if (lenUser <= 0 || lenPass <= 0) return;
            LoginUser();
        }
    }
}
