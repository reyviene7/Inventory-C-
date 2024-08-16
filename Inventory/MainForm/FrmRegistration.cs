using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;

namespace Inventory.MainForm
{
    public partial class FrmRegistration : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del;
        private string profileIdz = "";
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
            BindEmployeeList();
            //test method using popupnotification
            //var address_id = getLastAddressId();
            //PopupNotification.PopUpMessages(0, address_id.ToString(), Messages.TitleEmployees);
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
            EnabledText();
            InputWhiteC();
            InputClearTxt();
            GenerateCode();
            txtFirstName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridCtlProfile.Enabled = false;
        }
        private void buttonUpdate()
        {
            ButtonUpd();
            EnabledText();
            InputWhiteC();
            _add = false;
            _edt = true;
            _del = false;
            gridCtlProfile.Enabled = false;
        }
        private void ButDel()
        {
            ButtonDel();
            EnabledText();
            InputWhiteC();
            _add = false;
            _edt = false;
            _del = true;
            gridCtlProfile.Enabled = false;
        }
        private void buttonSave()
        {
            if (_add && _edt == false && _del == false)
            {
                DataInsert();
                ButtonSav();
                DisabledTxt();
                InputDimGry();
                InputClearTxt();
                
                BindEmployeeList();
            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdate();
                ButtonSav();
                DisabledTxt();
                InputDimGry();
                InputClearTxt();

                BindEmployeeList();
            }
            if (_add == false && _edt == false && _del)
            {
                DataDelete();
                ButtonSav();
                DisabledTxt();
                InputDimGry();
                InputClearTxt();
                BindEmployeeList();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridCtlProfile.Enabled = true;
        }

        private void buttonClear()
        {
            ButtonClr();
            EnabledText();
            InputWhiteC();
            InputClearTxt();
            gridCtlProfile.Enabled = true;
        }

        private void buttonCancel()
        {
            ButtonCan();
            DisabledTxt();
            InputDimGry();
            InputClearTxt();
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

        private void EnabledText()
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

        }
        private void DisabledTxt()
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
        }
        private void InputDimGry()
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
         
        }
        private void InputWhiteC()
        {
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
        private void InputClearTxt()
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

        }

        private void BindEmployeeList()
        {
            gridCtlProfile.Update();
            try
            {
                gridCtlProfile.DataBindings.Clear();
                
                var data = EnumerableUtils.getProfileList().Select(p => new
                {
                  Id = p.profile_id,
                  Code = p.profile_code,
                  LName = p.last_name,
                  FName = p.first_name,
                  Mid = p.middle_initial,
                  Sex = p.gender,
                  DOB = p.birthdate,
                  Status =  p.civil_status,
                  TelNo = p.telephone_number,
                  Mobile = p.mobile_number,
                  Email = p.email_address,
                  Brgy = p.barangay,
                  PRV = p.province,
                  SSS = p.sss_number,
                  PH  = p.phil_health,
                  Pos = p.position,
                  Dept = p.department_name,
                  Hire = p.hire_date,
                  Reg = p.date_register
                });
                gridCtlProfile.DataSource = data;
            }
            catch (Exception)
            {
                gridCtlProfile.EndUpdate();
                throw;
            }
        }


        //DAL INSERT 
        /*private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Profile>(unWork);
                    var info = new Profile()
                    {
                        profile_code = lblEmpCode.Text.Trim(' '),
                        first_name = txtFirstName.Text.Trim(' '),
                        last_name = txtLastName.Text.Trim(' '),
                        middle_initial = txtMiddleInitial.Text.Trim(' '),
                        gender = cmbgender.Text.Trim(' '),
                        birthdate = dkpBirthdate.Value.Date,
                        civil_status = cmbCivilStatus.Text.Trim(' '),
                        contact_id = 1, //
                        address_id = 1, //
                        sss_number = txtSSSNumber.Text.Trim(' '),
                        phil_health = txtPhilhealthNumber.Text.Trim(' '),
                        position = cmbPosition.Text.Trim(' '),
                        department_id = 1, //
                        hire_date = dkpDateHired.Value.Date,
                        date_register = dkpDateRegistered.Value.Date
                    };
                    var result = repository.Add(info);
                    if (result > 0)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Profile Code: " +
                                                           lblEmpCode.Text.Trim(' ')
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
        */

        private void DataInsert()
        {
            var address = new Address()
            {
                barangay = "Tambacan",
                street = "Purok 6A",
                city = txtAddress.Text.Trim(' '),
                province = cmbProvince.Text.Trim(' '),
                zip_code = "9200",
                country = "Philippines",
            };
            var addressResult = RepositoryEntity.AddEntity<Address>(address);
            var contact = new Contact()
            {
                contact_name = txtLastName.Text.Trim(' ') + ", " + txtFirstName.Text.Trim(' ') + " " + txtMiddleInitial.Text.Trim(' ') + ".",
                position = "n/a",
                telephone_number = txtPhone.Text.Trim(' '),
                mobile_number = txtMobile.Text.Trim(' '),
                mobile_secondary = "0",
                email_address = txtEmail.Text.Trim(' '),
                web_url = "n/a",
                fax_number = "0"
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
                department_id = 1, // FK from Department table
                hire_date = dkpDateHired.Value.Date,
                date_register = dkpDateRegistered.Value.Date,
                user_id = 1
            };
            var profileResult = RepositoryEntity.AddEntity<Profile>(profile);
        }

        //DAL UPDATE 
        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var empId = Convert.ToInt32(txtProfileID.Text);
                try
                {
                    var repository = new Repository<Profile>(unWork);
                    var que = repository.Id(empId);
                        que.profile_code = lblEmpCode.Text.Trim(' ');
                        que.first_name = txtFirstName.Text.Trim(' ');
                        que.last_name = txtLastName.Text.Trim(' ');
                        que.middle_initial = txtMiddleInitial.Text.Trim(' ');
                        que.gender = cmbgender.Text.Trim(' ');
                        que.birthdate = dkpBirthdate.Value.Date;
                        que.civil_status = cmbCivilStatus.Text.Trim(' ');
                        //que.phone = txtPhone.Text.Trim(' ');
                        //que.mobile = txtMobile.Text.Trim(' ');
                        //que.email = txtEmail.Text.Trim(' ');
                        //que.address = txtAddress.Text.Trim(' ');
                        //que.EmployeeAddress = txtADD.Text.Trim(' ');
                        //que.ProventialAddress = cmbPRV.Text.Trim(' ');
                        que.sss_number = txtSSSNumber.Text.Trim(' ');
                        que.phil_health = txtPhilhealthNumber.Text.Trim(' ');
                        que.position = cmbPosition.Text.Trim(' ');
                        //que.department = cmbDepartment.Text.Trim(' ');
                        que.hire_date = dkpDateHired.Value.Date;
                        que.date_register = dkpDateRegistered.Value.Date;
                    var result = repository.Update(que);
                    if (!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableEmployees + Messages.CodeName +
                                                    txtFirstName.Text.Trim(' ')+ " " + txtMiddleInitial.Text.Trim(' ') + " " + txtLastName.Text.Trim(' ')
                                                    + " " + Messages.SuccessUpdate,
                                                    Messages.TitleSuccessUpdate);


                    unWork.Commit();
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableEmployees + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
                }
            }
        }

        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var empId = Convert.ToInt32(txtProfileID.Text);
                try
                {
                    var repository = new Repository<Employees>(unWork);
                    var que = repository.Id(empId);
                   
                    var result = repository.Delete(que);
                    if (!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableEmployees + Messages.CodeName +
                                                    txtFirstName.Text.Trim(' ') + " " + txtMiddleInitial.Text.Trim(' ') + " " + txtLastName.Text.Trim(' ')
                                                    + " " + Messages.SuccessDelete,
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

        private void gridEmployee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView(sender);
        }

        private void gridView(object sender) {
            var grid = gridProfile;
            if (grid.RowCount > 0)
                try
                {
                    profileIdz = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    lblEmpCode.Text = ((GridView)sender).GetFocusedRowCellValue("Code").ToString();
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

        private void gridEmployee_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhiteC();
            gridView(sender);
        }

        private void gridEmployee_LostFocus(object sender, EventArgs e)
        {
            InputDimGry();
        }

      

        private string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewProfile>(unitWork);
                var result = (from b in repository.SelectAll(ServeAll.Core.Queries.Query.viewProfile)
                              orderby b.profile_id descending
                              select b.profile_code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = ServeAll.Core.Queries.Query.DefaultCode;
                return result;
            }
        }

        private int getLastContactId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<Contact>(unitWork);
                var result = (from b in repository.SelectAll(ServeAll.Core.Queries.Query.getContactId)
                              orderby b.contact_id descending
                              select b.contact_id).Take(1).SingleOrDefault();
                if (result > 0)
                {
                    return result;
                }
                 
                return 0;
            }
        }

        private int getLastAddressId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<Address>(unitWork);
                var result = (from b in repository.SelectAll(ServeAll.Core.Queries.Query.getAddressId)
                              orderby b.address_id descending
                              select b.address_id).Take(1).SingleOrDefault();
                if (result > 0)
                {
                    return result;
                }

                return 0;
            }
        }
        private void GenerateCode()
        {
            var lastCode = GetLastId();
            int lastWarehouseDeliveryNumber;

            if (string.IsNullOrEmpty(lastCode) || !int.TryParse(lastCode.Replace("DC", ""), out lastWarehouseDeliveryNumber))
            {
                lastWarehouseDeliveryNumber = 0;
            }
            var alphaNumeric = new GenerateAlpaDev("DC", 3, lastWarehouseDeliveryNumber);
            alphaNumeric.Increment();
            lblEmpCode.Text = alphaNumeric.ToString();
            lblEmpCode.Focus();
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
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtPhone, txtMobile, "Phone Number", Messages.TitleEmployees);
            }
        }
        private void txtMON_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtMobile, txtEmail, "Mobile Number", Messages.TitleEmployees);
        }
        private void txtMON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtMobile, txtEmail, "Mobile Number", Messages.TitleEmployees);
            }
        }
        private void txtEML_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtEmail, txtAddress, "Email Address", Messages.TitleEmployees);
        }
        private void txtEML_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtEmail, txtAddress, "Email Address", Messages.TitleEmployees);
            }
        }
        private void txtADD_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtAddress, cmbProvince, "Address", Messages.TitleEmployees);
        }
        private void txtADD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtAddress, cmbProvince, "Address", Messages.TitleEmployees);
            }
        }
        private void cmbPRV_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbProvince, txtSSSNumber, "Provencial Address", Messages.TitleEmployees);
        }
        private void cmbPRV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbProvince, txtSSSNumber, "Provencial Address", Messages.TitleEmployees);

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

    }
}
