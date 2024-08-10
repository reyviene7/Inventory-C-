using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using ServeAll.Core.Entities;
using Query = ServeAll.Core.Queries.Query;
using ServeAll.Core.Repository;
using Inventory.Config;
using ServeAll.Core.Utilities;
using DevExpress.XtraReports.UI;
using System.Globalization;


namespace Inventory.MainForm
{
    public partial class FrmBranch : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del;
        private readonly int _userId;
        private readonly int _usrTyp;
        private IEnumerable<ViewBranch> listbranch;
        private int BranchId = 0;

        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmBranch(int userId, int usrTyp)
        {
            _userId = userId;
            _usrTyp = usrTyp;
            InitializeComponent();
        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {
         
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            listbranch = EnumerableUtils.GetBranchList();
            BindBranche();
        }

        private void BindBranche()
        {
            gCON.Update();
            try
            {
                var list = listbranch.Select(x => new
                {
                    Id = x.branch_id,
                    Code = x.branch_code,
                    Branch = x.branch_details,
                    Barangay = x.barangay,
                    Street = x.street,
                    City = x.city,
                    Province = x.province,
                    ZipCode = x.zip_code,
                    Telephone = x.telephone_number,
                    Mobile = x.mobile_number,
                    Email = x.email_address,
                    Fax = x.fax_number,
                    Date = x.date_register
                });

                gCON.DataBindings.Clear();
                gCON.DataSource = list;


                gridBranch.Columns[0].Width = 30;
                gridBranch.Columns[1].Width = 50;
                gridBranch.Columns[2].Width = 100;
                gridBranch.Columns[3].Width = 120;
                gridBranch.Columns[4].Width = 100;
                gridBranch.Columns[5].Width = 100;
                gridBranch.Columns[6].Width = 120;
                gridBranch.Columns[8].Width = 100;
                gridBranch.Columns[9].Width = 100;
                gridBranch.Columns[10].Width = 100;
                gridBranch.Columns[11].Width = 100;
                gridBranch.Columns[12].Width = 100;

            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void FrmBranch_MouseMove(object sender, MouseEventArgs e)
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
            WhtInput();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Branch Name: " + txtBranchName.Text.Trim(' ')+"?", "Branch Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan();}
        }

        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if(que <= 0)return;
            var log = new FirmLogin();
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
            bntADD.Enabled = false;
            bntUPD.Enabled = false;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
            gCON.Enabled = false;
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
            gCON.Enabled = false;
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
            gCON.Enabled = false;
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
            gCON.Enabled = true;
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
            gCON.Enabled = false;
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
            gCON.Enabled = true;
        }

        private void CleInput()
        {
            txtBranchId.Clear();
            txtBranchCode.Clear();
            txtBranchName.Clear();
            txtBranchBarangay.Clear();
            cmbProvincialAddress.Text = "";
            txtBranchTel.Clear();
            txtBranchMobile.Clear();
            txtBranchFax.Clear();
            //cmbHED.Text = "";
        }
        private void CleArInput()
        {
            txtBranchId.Clear();
            txtBranchName.Clear();
            txtBranchBarangay.Clear();
            cmbProvincialAddress.Text = "";
            txtBranchTel.Clear();
            txtBranchMobile.Clear();
            txtBranchFax.Clear();
            //cmbHED.Text = "";
        }

        private void DimInput()
        {
            txtBranchId.BackColor = Color.DimGray;
            txtBranchCode.BackColor = Color.DimGray;
            txtBranchName.BackColor = Color.DimGray;
            txtBranchBarangay.BackColor = Color.DimGray;
            cmbProvincialAddress.BackColor = Color.DimGray;
            txtBranchTel.BackColor = Color.DimGray;
            txtBranchMobile.BackColor = Color.DimGray;
            txtBranchFax.BackColor = Color.DimGray;
            //cmbHED.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
        }

        private void WhtInput()
        {
            txtBranchId.BackColor = Color.White;
            txtBranchCode.BackColor = Color.White;
            txtBranchName.BackColor = Color.White;
            txtBranchBarangay.BackColor = Color.White;
            txtBranchStreet.BackColor = Color.White;
            txtBranchCity.BackColor = Color.White;
            cmbProvincialAddress.BackColor = Color.White;
            txtBranchZip.BackColor = Color.White;
            txtBranchCountry.BackColor = Color.White;
            txtBranchTel.BackColor = Color.White;
            txtBranchMobile.BackColor = Color.White;
            txtBranchEmail.BackColor = Color.White;
            txtBranchFax.BackColor = Color.White;
            //cmbHED.BackColor = Color.White;

        }

        private void EnbInput()
        {
            txtBranchId.Enabled = false;
            txtBranchCode.Enabled = true;
            txtBranchName.Enabled = true;
            txtBranchBarangay.Enabled = true;
            cmbProvincialAddress.Enabled = true;
            txtBranchTel.Enabled = true;
            txtBranchMobile.Enabled = true;
            txtBranchFax.Enabled = true;
            //cmbHED.Enabled = true;
            dkpDateRegister.Enabled = true;
        }

        private void DisInput()
        {
            txtBranchId.Enabled = false;
            txtBranchCode.Enabled = false;
            txtBranchName.Enabled = false;
            txtBranchBarangay.Enabled = false;
            cmbProvincialAddress.Enabled = false;
            txtBranchTel.Enabled = false;
            txtBranchMobile.Enabled = false;
            txtBranchFax.Enabled = false;
            //cmbHED.Enabled = false;
            dkpDateRegister.Enabled = false;
        }

        private void ButAdd()
        {
            gCON.Enabled = false;
            ButtonAdd();
            WhtInput();
            EnbInput();
            CleArInput();
            GenerateCode();
            txtBranchName.Focus();
            _add = true;
            _edt = false;
            _del = false;
        }

        private void ButUpd()
        {
            ButtonUpd();
            EnbInput();
            WhtInput();
            _add = false;
            _edt = true;
            _del = false;
        }

        private void ButDel()
        {
            ButtonDel();
            WhtInput();
            EnbInput();
            _add = false;
            _edt = false;
            _del = true;
        }

        private void ButSav()
        {
            if (_add && _edt == false && _del == false)
            {
                DataAdd();
                ButtonSav();
                DimInput();
                CleInput();
                DisInput();
                BindBranche();
            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdate();
                ButtonSav();
                DimInput();
                CleInput();
                DisInput();
                BindBranche();
            }
            if (_add == false && _edt==false && _del)
            {
                DataDelete();
                ButtonSav();
                DimInput();
                CleInput();
                DisInput();
                BindBranche();
            }
            _add = false;
            _edt = false;
            _del = false;
        }

        private void ButClr()
        {
            ButtonClr();
            WhtInput();
            CleInput();
            EnbInput();
           
        }

        private void ButCan()
        {
            ButtonCan();
            DimInput();
            CleInput();
            DisInput();
           
        }

        private void pcAdd_Click(object sender, EventArgs e)
        {
            ButAdd();
        }

        private void pcUser_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ButDel();
        }

        private void pcChangePassword_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void pcBL_Click(object sender, EventArgs e)
        {
            ButSav();
        }

        //PROCEDURE DAPPER
        private string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<Branch>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllBranch)
                    orderby b.branch_id descending
                              select b.branch_code).Take(1).SingleOrDefault();
                if (result!= null)
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
            var lastId = FetchUtils.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum("EN", 3,lastId);
            alphaNumeric.Increment();
            txtBranchCode.Text = alphaNumeric.ToString();
        }

        private void DataAdd()
        {
            var branch = new Branch()
            {
                branch_code = txtBranchCode.Text.Trim(' '),
                branch_details = txtBranchName.Text.Trim(' '),
                //BranchAddress = txtBAA.Text.Trim(' '),
                //ProvincialAddress = cmbPRV.Text.Trim(' '),
                //BranchNumber = txtBAT.Text.Trim(' '),
                //BranchMobile = txtBAM.Text.Trim(' '),
                //BranchFax = txtFAX.Text.Trim(' '),
                //EmployeeId = 1, 
                date_register = dkpDateRegister.Value.Date
            };
            using (var session = new DalSession())
            {
                var unit = session.UnitofWrk;
                unit.Begin();
                try
                {
                    var repository = new Repository<Branch>(unit);
                    var que = repository.Add(branch);
                    if(que<=0)return;
                    PopupNotification.PopUpMessages(1, Messages.TableBranch+Messages.CodeName+ 
                                                    txtBranchName.Text.Trim(' ') 
                                                    + " " + Messages.SuccessInsert, 
                                                    Messages.TitleSuccessInsert);
                    unit.Commit();
                }
                catch (Exception)
                {
                    unit.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorInsert+Messages.TableBranch+Messages.ErrorOccurred, Messages.TitleFailedInsert);
                }
            }
        }

        private void DataUpdate()
        {
            var ctrlId = Convert.ToInt32(txtBranchId.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var que = repository.Id(ctrlId);
                    que.branch_code = txtBranchCode.Text.Trim(' ');
                    que.branch_details = txtBranchName.Text.Trim(' ');
                    //que.BranchAddress = txtBAA.Text.Trim(' ');
                    //que.ProvincialAddress = cmbPRV.Text.Trim(' ');
                    //que.BranchNumber = txtBAT.Text.Trim(' ');
                    //que.BranchMobile = txtBAM.Text.Trim(' ');
                    //que.BranchFax = txtFAX.Text.Trim(' ');
                    //que.EmployeeId = 1;
                    que.date_register = dkpDateRegister.Value.Date;
                    var result = repository.Update(que);
                    if(!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableBranch + Messages.CodeName +
                                                    txtBranchName.Text.Trim(' ')
                                                    + " " + Messages.SuccessUpdate,
                                                    Messages.TitleSuccessUpdate);

                    unWork.Commit();
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorUpdate + Messages.TableBranch + Messages.ErrorOccurred, Messages.TitleFialedUpdate);
                }
            }
        }

        private void DataDelete()
        {
            var ctrlId = Convert.ToInt32(txtBranchId.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.Id(ctrlId);
                    var result = repository.Delete(query);
                    if (!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableBranch + Messages.CodeName +
                                                    txtBranchName.Text.Trim(' ')
                                                    + " " + Messages.SuccessDelete,
                                                    Messages.TitleSuccessDelete);

                    unWork.Commit();
                }
                catch (Exception)
                {

                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableBranch + Messages.ErrorOccurred, Messages.TitleFialedDelete);
                    
                }
            }
        }

        private void gridBranch_RowClick(object sender, RowClickEventArgs e)
        {
            WhtInput();
            bntCAN.Enabled = true;
        }

      

        private void gridBranch_LostFocus(object sender, EventArgs e)
        {
            DimInput();
        }

        
        private void gridBranch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridBranch.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        BranchId = int.Parse(id);
                        var ent = searchBranchId(BranchId);
                        txtBranchId.Text = ent.branch_id.ToString();
                        txtBranchCode.Text = ent.branch_code;
                        txtBranchName.Text = ent.branch_details;
                        txtBranchBarangay.Text = ent.barangay;
                        txtBranchStreet.Text = ent.street;
                        txtBranchCity.Text = ent.city;
                        cmbProvincialAddress.Text = ent.province;
                        txtBranchCountry.Text = ent.country;
                        txtBranchTel.Text = ent.telephone_number;
                        txtBranchMobile.Text = ent.mobile_number;
                        txtBranchEmail.Text = ent.email_address;
                        txtBranchFax.Text = ent.fax_number;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private ViewBranch searchBranchId(int id)
        {
            return listbranch.FirstOrDefault(Branch => Branch.branch_id == id);
        }

        //INPUT MANIPULATION
        private void txtBAC_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(txtBranchCode, txtBranchName, "Branch Code", Messages.TitleBranch);
        }
        private void txtBAC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchCode, txtBranchName, "Branch Code", Messages.TitleBranch);
            }
        }
        private void txtBAD_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(txtBranchName, txtBranchBarangay, "Branch Name", Messages.TitleBranch);
        }

        private void txtBAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchName, txtBranchBarangay, "Branch Name", Messages.TitleBranch);
            }
        }

        private void txtBAA_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(txtBranchBarangay, cmbProvincialAddress, "Branch Address", Messages.TitleBranch);
        }

        private void txtBAA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchBarangay, cmbProvincialAddress, "Branch Address", Messages.TitleBranch);
            }
        }

       

        private void cmbPRV_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(cmbProvincialAddress, txtBranchTel, "Provincial Address", Messages.TitleBranch);
        }

        private void cmbPRV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(cmbProvincialAddress, txtBranchTel, "Provincial Address", Messages.TitleBranch);
            }
        }


        private void txtBAT_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(txtBranchTel, txtBranchMobile, "Branch Telephone Number", Messages.TitleBranch);
        }
        private void txtBAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchTel, txtBranchMobile, "Branch Telephone Number", Messages.TitleBranch);
            }
        }

      

        private void txtBAM_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(txtBranchMobile, txtBranchFax, "Branch Mobile Number", Messages.TitleBranch);
        }

        private void txtBAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchMobile, txtBranchFax, "Branch Mobile Number", Messages.TitleBranch);
            }
        }

       

        private void txtFAX_Leave(object sender, EventArgs e)
        {
            //InputManipulation.InputEmpLeave(txtBranchFax, cmbHED, "Branch Fax Number", Messages.TitleBranch);
        }

        private void txtFAX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //InputManipulation.InputEmpLeave(txtBranchFax, cmbHED, "Branch Fax Number", Messages.TitleBranch);
            }
        }

        

        private void cmbHED_Leave(object sender, EventArgs e)
        {
            //InputManipulation.InputEmpLeave(cmbHED, dkpDateRegister, "Branch Head", Messages.TitleBranch);
        }

        private void cmbHED_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //InputManipulation.InputEmpLeave(cmbHED, dkpDateRegister, "Branch Head", Messages.TitleBranch);
            }
        }

        private void dkpREG_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputEmpLeave(dkpDateRegister, bntADD, "Date Register", Messages.TitleBranch);
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(dkpDateRegister, bntADD, "Date Register", Messages.TitleBranch);
            }
        }
    }
}
